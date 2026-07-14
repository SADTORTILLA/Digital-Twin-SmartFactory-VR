# Immersive Digital Twin for a Smart Factory

> Development of an immersive Digital Twin of a PEHD bottle production line for industrial supervision and educational training at HESTIM.

![Unity](https://img.shields.io/badge/Unity-6-black)
![VR](https://img.shields.io/badge/VR-Meta%20Quest%203-blue)
![FastAPI](https://img.shields.io/badge/FastAPI-green)
![ESP32](https://img.shields.io/badge/ESP32-IoT-red)
![Status](https://img.shields.io/badge/Status-In%20Development-orange)

---

## 1. Project Overview

This repository contains the complete development of an immersive Digital Twin of a PEHD (High-Density Polyethylene) bottle production line, developed within the Smart Factory Connected (SFC) at the H-FAB laboratory of HESTIM. 

The primary goal of this project is to bridge the gap between physical industrial systems and immersive virtual reality by creating a platform that serves both as an **educational training tool** and as a **proof of concept for connected industrial supervision**. 

Unlike a standard 3D simulation, this environment is built to be a true Digital Twin. It incorporates an IoT data pipeline that connects the physical factory to the Unity VR environment in real-time, starting with the extrusion-blow molding machine's temperature.

---

## 2. Project Objectives

The project is driven by the need to safely and effectively train students and operators on complex Industry 4.0 systems, while also addressing the challenges of physical machine availability. The core objectives are:

### General Objective
To develop an immersive Digital Twin of the HESTIM Smart Factory PEHD bottle production line, providing a pedagogical simulation platform and a first proof of concept for VR-based connected supervision.

### Specific Objectives
*   **3D Modeling & Virtual Environment:** Create highly accurate, optimized 3D representations of the industrial equipment (using CATIA V5, FreeCAD, and Blender) and assemble a faithful VR replica of the factory in Unity.
*   **Machine Logic & Animation:** Develop the functional behaviors, physics, and animations for each workstation to reflect the real-world manufacturing flow.
*   **Pedagogical Scenarios:** Implement structured, offline VR training scenarios—specifically a timed labeling task—to evaluate user performance, learning progression, and the effectiveness of progressive VR guidance.
*   **Connected Supervision (IoT Pipeline):** Design and implement a robust communication architecture using ESP32 microcontrollers to capture physical machine data, a FastAPI server to process it, and Unity to visualize it in real-time.
*   **Multiplayer / Collaborative Readiness:** Lay the technical groundwork (using Unity Netcode) for future collaborative scenarios, such as the collaborative planning and layout of production systems.

---

## 3. Smart Factory Overview

The HESTIM Smart Factory Connected (SFC) is a miniaturized, automated production line designed for educational and experimental purposes. It reproduces the complete lifecycle of a PEHD bottle, allowing students in industrial engineering to train on Industry 4.0 technologies.

**Production Flow:**
1.  **Extrusion Blow Molding:** Transformation of plastic granules into bottles.
2.  **Decarottage (Trimming):** Removal of excess plastic from the molded bottles.
3.  **Filling & Capping:** Automated dosing of liquid and manual capping of the bottles.
4.  **Labeling:** Manual application of identifying labels.
5.  **Quality Control:** Visual and documentary inspection of the final product.
6.  **Packaging & Storage:** Boxing, palletizing (using a robotic arm), and final storage.

---

## 4. Production Line Workstations

### 1. Extrusion Blow Molding
*   **Purpose:** Manufactures the PEHD bottles from raw plastic granules.
*   **Operation:** Automated cycle. Outputs bottles with a lower "carrot" (excess plastic) that needs trimming.
*   **Supervision:** Temperature data from this machine is currently captured by the ESP32 and transmitted to the VR Digital Twin.

### 2. Decarottage (Trimming)
*   **Purpose:** Removes the excess plastic generated during extrusion.
*   **Operation:** Automated machine with manual positioning of the bottle.

### 3. Filling & Capping
*   **Purpose:** Doses the product into the bottles and seals them.
*   **Operation:** Automated filling via a conveyor belt system, followed by manual capping and self-inspection.

### 4. Labeling (Pedagogical Focus)
*   **Purpose:** Application of the product label to the smooth face of the bottle.
*   **Current VR Implementation:** This is the primary interactive training scenario in the VR environment. It requires the user to fetch boxes, handle the bottle, apply the label accurately, and manage the finished products. 

### 5. Quality Control
*   **Purpose:** Verification of label alignment, adhesion, and overall packaging integrity before final boxing.

### 6. Packaging & Storage
*   **Purpose:** Grouping the finished bottles into boxes and palletizing them.
*   **Operation:** Assisted by a robotic arm equipped with a vision camera to automatically pick and place bottles into boxes.

---

## 5. System Architecture

The architecture relies on a clear separation between the physical layer, the communication middleware, and the immersive virtual layer.

```text
[ Physical Factory ]        [ Communication Layer ]          [ Immersive Platform ]

  Extrusion Machine                 FastAPI Server                  Unity Engine 6
        │                                 │                               │
        ▼                                 ▼                               ▼
      ESP32   ────────(Wi-Fi)───────► HTTP API  ─────(WebSocket)────► Meta Quest 3
 (Data Acquisition)                 (Data Processing)               (VR Visualization)
```

*   **ESP32:** Captures real-time sensor data (e.g., machine temperature).
*   **FastAPI:** Acts as the central hub, receiving data via HTTP POST requests and exposing it to Unity via WebSockets.
*   **Unity (Meta Quest 3):** Renders the Digital Twin, manages the pedagogical scenarios, and visualizes the live IoT data in the VR space.

---

## 6. Software Stack

| Software / Technology | Purpose |
|-----------------------|----------------------------------------------------|
| **Unity 6** | Core VR development, logic, and rendering engine. |
| **OpenXR & XR Toolkit**| VR interaction management. |
| **CATIA V5** | Primary mechanical 3D CAD modeling. |
| **FreeCAD** | CAD conversion and adaptation. |
| **Blender** | 3D optimization, material setup, and robotic arm rigging. |
| **FastAPI (Python)** | Backend server for IoT data mediation. |
| **C/C++ (ESP32)** | Microcontroller firmware for data acquisition. |

---

## 7. Educational Scenarios

### Implemented: Timed Labeling Scenario
This scenario is fully operational and used for experimental research on VR learning.
*   **Objective:** Train users on the precise sequence of the manual labeling workstation.
*   **Sessions:** 
    1.  *Guided:* Full audio/visual assistance.
    2.  *Autonomous:* No assistance, relies on memory.
    3.  *Stress Test:* Introduces unexpected events (e.g., missing labels).
*   **Evaluation:** Tracks completion time, accuracy, and manipulation errors to analyze learning progression.

### In Development: Collaborative Factory Layout
*   **Objective:** A multiplayer scenario where several users share the VR space to discuss and rearrange the layout of the factory machines to optimize production flow.
*   **Technology:** Built using Unity Netcode for GameObjects.

---

## 8. Current Implementation Status

*   ✔ **3D Modeling:** Complete for all primary machines.
*   ✔ **VR Environment:** Assembled and optimized for Meta Quest 3.
*   ✔ **Machine Logic:** Animations and flow logic integrated.
*   ✔ **Connected Supervision:** End-to-end pipeline validated (ESP32 -> FastAPI -> Unity) for extrusion temperature.
*   ✔ **Pedagogical Scenarios:** Timed Labeling scenario fully functional with data tracking.
*   ❌ **Multiplayer:** In active development for the factory layout scenario.
*   ❌ **Full Synchronization:** Currently limited to temperature; requires further hardware integration for full PLC data mirroring.

---

## 9. Future Work

**High Priority:**
*   Finalize the multiplayer/collaborative architecture (Unity Netcode) for the factory layout scenario.
*   Expand the IoT pipeline to capture more data points (e.g., machine states, conveyor speeds, fault alerts).

**Medium Priority:**
*   Implement VR scenarios for robotic arm teaching and AGV (Automated Guided Vehicle) management.
*   Dynamic production modification (allowing the VR user to send commands back to the factory to alter production speed).

**Long Term:**
*   Integrate an analytics dashboard within the VR space for real-time production KPI monitoring.
*   Implement predictive maintenance visualizations.

---

## 10. Research Work

This Digital Twin serves as the experimental foundation for academic research into immersive industrial training. The data collected from the Timed Labeling scenario (via `UserSessionData.csv` and the NASA-TLX workload index) is currently being analyzed for a research paper: 

> *Progressive Guidance and Autonomous Learning in VR-Based Industrial Training: A System Design and Experimental Protocol for the HESTIM Smart Factory Connected.*

---

## 11. Contributors

*   **Developer/Researcher:** Saad Joual
*   **Academic Supervisor:** M. Mourad Zegrari
*   **Industrial Supervisor:** M. Adonko Carlos Koffi
*   **SFC Manager:** Mme. Sokhna Gueye
*   **Institution:** ENSAM Casablanca & HESTIM Engineering & Business School

---

## 12. License

MIT License