from fastapi import FastAPI, Header, HTTPException
from pydantic import BaseModel, Field
from sqlalchemy import create_engine, Column, Float, String, Integer, Boolean, BigInteger
from sqlalchemy.orm import declarative_base, sessionmaker
from typing import Optional
import uuid, time

app = FastAPI()

# ── Auth ──
API_KEY = "ESP_SECRET"

def check_key(x_api_key: str = Header(...)):
    if x_api_key != API_KEY:
        raise HTTPException(status_code=401, detail="Invalid API key")

# ── Database ──
engine  = create_engine("sqlite:///factory.db")
Base    = declarative_base()
Session = sessionmaker(bind=engine)

class Simulation(Base):
    __tablename__ = "simulations"
    id          = Column(String,  primary_key=True)
    name        = Column(String)
    description = Column(String)
    device      = Column(String)
    active      = Column(Boolean, default=True)
    started_at  = Column(BigInteger)

class SensorRecord(Base):
    __tablename__ = "sensor_records"
    id            = Column(Integer, primary_key=True, autoincrement=True)
    simulation_id = Column(String)
    timestamp     = Column(BigInteger)
    sensor_name   = Column(String)
    temperature   = Column(Float,  nullable=True)
    position      = Column(Float)

Base.metadata.create_all(engine)

# ── Pydantic models ──
class SimulationStartRequest(BaseModel):
    name:        str
    description: str = ""
    device:      str = ""

class SensorReading(BaseModel):
    name:        str
    temperature: Optional[float] = None
    position:    float

class DataPayload(BaseModel):
    simulation_id: str
    timestamp:     int
    sensors:       list[SensorReading]

# ─────────────────────────────────────
# ESP32 endpoints
# ─────────────────────────────────────

@app.post("/simulation/start")
def start_simulation(body: SimulationStartRequest,
                     x_api_key: str = Header(...)):
    check_key(x_api_key)

    db  = Session()
    sim = Simulation(
        id          = "SIM_" + str(uuid.uuid4())[:8].upper(),
        name        = body.name,
        description = body.description,
        device      = body.device,
        active      = True,
        started_at  = int(time.time())
    )
    db.add(sim)
    db.commit()
    sim_id = sim.id
    db.close()

    return { "status": "started", "simulation_id": sim_id }


@app.post("/data")
def receive_data(body: DataPayload,
                 x_api_key: str = Header(...)):
    check_key(x_api_key)

    db  = Session()

    # check simulation exists and is active
    sim = db.query(Simulation).filter(Simulation.id == body.simulation_id).first()
    if not sim or not sim.active:
        db.close()
        return { "status": "error", "detail": "inactive simulation" }

    # save each sensor reading as a row
    for s in body.sensors:
        record = SensorRecord(
            simulation_id = body.simulation_id,
            timestamp     = body.timestamp,
            sensor_name   = s.name,
            temperature   = s.temperature,
            position      = s.position
        )
        db.add(record)

    db.commit()
    db.close()

    return { "status": "ok" }

# ─────────────────────────────────────
# Unity endpoints
# ─────────────────────────────────────

@app.get("/extrusion-soufflage/latest")
def get_latest():
    db = Session()

    # get the latest timestamp across all sensors
    latest = db.query(SensorRecord)\
               .order_by(SensorRecord.timestamp.desc())\
               .first()

    if not latest:
        db.close()
        return { "error": "no data found" }

    # get all 3 sensors at that timestamp
    records = db.query(SensorRecord)\
                .filter(SensorRecord.timestamp == latest.timestamp)\
                .all()
    db.close()

    result = {
        "timestamp":  latest.timestamp,
        "temp_zone_1": None,
        "temp_zone_2": None,
        "temp_zone_3": None
    }

    for r in records:
        if r.sensor_name == "Zone_1": result["temp_zone_1"] = r.temperature
        if r.sensor_name == "Zone_2": result["temp_zone_2"] = r.temperature
        if r.sensor_name == "Zone_3": result["temp_zone_3"] = r.temperature

    return result


@app.get("/extrusion-soufflage/history")
def get_history(limit: int = 100):
    db = Session()

    # get distinct timestamps in order
    records = db.query(SensorRecord)\
                .order_by(SensorRecord.timestamp.desc())\
                .limit(limit * 3)\
                .all()
    db.close()

    # group by timestamp
    grouped = {}
    for r in records:
        ts = r.timestamp
        if ts not in grouped:
            grouped[ts] = { "timestamp": ts, "temp_zone_1": None, "temp_zone_2": None, "temp_zone_3": None }
        if r.sensor_name == "Zone_1": grouped[ts]["temp_zone_1"] = r.temperature
        if r.sensor_name == "Zone_2": grouped[ts]["temp_zone_2"] = r.temperature
        if r.sensor_name == "Zone_3": grouped[ts]["temp_zone_3"] = r.temperature

    return list(grouped.values())[:limit]


@app.get("/simulations")
def list_simulations():
    db   = Session()
    sims = db.query(Simulation).order_by(Simulation.started_at.desc()).all()
    db.close()
    return [{ "id": s.id, "name": s.name, "device": s.device, "active": s.active } for s in sims]