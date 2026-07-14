# Immersive Digital Twin for a Smart Factory

> Development of an immersive Digital Twin of a PEHD bottle production line for industrial supervision and educational training.

![Unity](https://img.shields.io/badge/Unity-6-black)
![VR](https://img.shields.io/badge/VR-Meta%20Quest%203-blue)
![FastAPI](https://img.shields.io/badge/FastAPI-green)
![ESP32](https://img.shields.io/badge/ESP32-IoT-red)
![Status](https://img.shields.io/badge/Status-In%20Development-orange)

---

# Table of Contents

1. Project Overview
2. Objectives
3. Smart Factory Overview
4. Production Line Description
5. System Architecture
6. Repository Structure
7. Software Stack
8. Hardware Requirements
9. Installation Guide
10. Running the Project
11. Educational Scenarios
12. Current Implementation
13. Current Limitations
14. Future Work
15. How to Continue the Project
16. Research Work
17. Troubleshooting
18. Contributors
19. License

---

# 1. Project Overview

This repository contains the complete development of an immersive Digital Twin of a PEHD bottle production line developed during a Master's internship at HESTIM.

The objective is to reproduce the Smart Factory inside a Virtual Reality environment while allowing real-time visualization of data coming from the physical production line.

The project has two major purposes:

- Industrial supervision
- Educational and training scenarios

Unlike a simple VR simulation, this project is intended to become a Digital Twin through synchronization between the physical production line and its virtual counterpart.

---

# 2. Objectives

Main objectives include:

- Create a faithful virtual replica of the Smart Factory.
- Develop an immersive VR environment.
- Synchronize industrial data with Unity.
- Provide educational scenarios.
- Evaluate user performance.
- Prepare a collaborative Digital Twin architecture.

---

# 3. Smart Factory Overview

Describe the Smart Factory platform.

Explain:

- educational purpose
- machines
- production flow
- industrial context

Insert photos here.

---

# 4. Production Line

Describe every workstation.

## Extrusion Blow Molding

Purpose

Inputs

Outputs

Operation

---

## Manual Labeling

Purpose

Current implementation

Timer scenario

---

## Robot Manipulator

...

Continue for every workstation.

---

# 5. System Architecture

Explain the complete architecture.

```text
Mini Factory
      │
      ▼
ESP32
      │ WiFi
      ▼
FastAPI
      │ HTTP/WebSocket
      ▼
Unity
      │
      ▼
Meta Quest 3
```

Explain each block individually.

---

# 6. Repository Structure

Explain every folder.

```
Unity/
```

Contains the Unity project.

```
FastAPI/
```

Contains backend code.

```
ESP32/
```

Contains firmware.

etc...

---

# 7. Software Stack

| Software | Purpose |
|------------|----------------|
| Unity 6 | VR Development |
| Blender | Asset Optimization |
| CATIA V5 | CAD Modeling |
| FreeCAD | File Conversion |
| FastAPI | Backend |
| ESP32 | Data Acquisition |

---

# 8. Hardware

List everything required.

- Meta Quest 3
- ESP32
- WiFi
- Smart Factory
- PC specifications

---

# 9. Installation Guide

## Clone

```bash
git clone ...
```

## Install Unity

Version

Packages

XR plugins

...

## Install Python

...

## Flash ESP32

...

---

# 10. Running the Project

Step-by-step.

1.
2.
3.
4.

---

# 11. Educational Scenarios

## Implemented

### Timed Labeling

Objectives

Rules

Evaluation

Data collected

---

## Planned

Factory Layout

Robot Programming

AGV

etc.

---

# 12. Current Implementation

✔ 3D Models

✔ VR Environment

✔ Machine Logic

✔ FastAPI

✔ ESP32 Communication

✔ Timed Labeling

❌ Multiplayer

❌ Full Synchronization

❌ Analytics Dashboard

---

# 13. Current Limitations

Explain honestly.

Examples:

Only one industrial variable is synchronized.

Only one scenario is complete.

Multiplayer architecture not implemented.

Limited experimental validation.

No PLC communication.

---

# 14. Future Work

This is probably the most important section.

Divide into priorities.

## High Priority

Implement multiplayer.

Complete synchronization.

Improve UI.

---

## Medium Priority

Factory layout scenario.

AGV.

Robot teaching.

---

## Long Term

Digital Twin analytics.

AI assistant.

Predictive maintenance.

Cloud synchronization.

---

# 15. Guide for the Next Intern

This section should answer:

If I had one month to continue this project, what should I do?

Suggested roadmap:

Week 1

Understand Unity architecture.

Read documentation.

Run project.

Week 2

Understand FastAPI.

Understand communication.

Week 3

Implement multiplayer.

Week 4

Testing.

...

Include a "Start Here" checklist:

- Clone the repository.
- Read the architecture documentation.
- Run the Unity project.
- Verify FastAPI communication.
- Test the labeling scenario.
- Review the known issues.
- Choose a roadmap item.

---

# 16. Research

Describe

- conference paper
- experiments
- questionnaires

Provide citation.

---

# 17. Troubleshooting

Examples.

Unity package errors.

XR problems.

ESP32 connection.

WebSocket issues.

Missing assets.

Quest deployment.

---

# 18. Contributors

Name

Role

Contact

Supervisor

Institution

---

# 19. License

MIT