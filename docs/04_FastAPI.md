# FastAPI Server

The FastAPI server acts as the mediation layer between the physical factory (ESP32) and the virtual environment (Unity).

## Role in the Pipeline
- **Data Ingestion (HTTP POST):** Exposes endpoints to receive sensor data (e.g., temperature) from the ESP32.
- **Data Streaming (WebSocket):** Maintains an active WebSocket connection with the Unity client to push real-time updates seamlessly.
- **State Management:** Keeps track of the current machine states so newly connected Unity clients can retrieve the latest available data immediately upon joining.
