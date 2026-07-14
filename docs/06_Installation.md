# Installation Guide

## Prerequisites
- **Unity 6** with Android/OpenXR build support.
- **Meta Quest 3** (configured for PC VR via Link or standalone build).
- **Python 3.9+** (for FastAPI backend).
- **Arduino IDE or ESP-IDF** (for ESP32 firmware).

## Setup Steps

### 1. Unity Project
1. Open Unity Hub and add the `Unity` folder from this repository.
2. Resolve any missing package dependencies.
3. Open `MAIN_scene` (or the respective tutorial scene) to test in the editor.

### 2. FastAPI Server
1. Navigate to the `FastAPI` directory in your terminal.
2. Install dependencies: `pip install -r requirements.txt`
3. Run the server: `uvicorn main:app --host 0.0.0.0 --port 8000`

### 3. ESP32
1. Open the `.ino` or `.cpp` file in your ESP32 IDE.
2. Update the Wi-Fi credentials and FastAPI server IP address in the code.
3. Compile and flash to the board.
