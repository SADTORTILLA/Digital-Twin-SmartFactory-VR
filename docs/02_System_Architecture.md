# System Architecture

The architecture connects the physical and virtual worlds using four distinct layers:

1. **Physical Layer:** The real-world machines, sensors, and the actual SFC production line.
2. **Communication Layer:** ESP32 microcontrollers read physical states and send data via Wi-Fi to a FastAPI server over HTTP. The server then relays it to Unity via WebSockets.
3. **Virtual Layer:** 3D models and Unity logic replicating the factory and its behaviors.
4. **Visualization Layer:** Meta Quest 3 VR headset providing immersive interaction and real-time UI dashboards.

This separation ensures a scalable infrastructure where the VR environment and the physical factory remain decoupled, communicating strictly through the FastAPI mediation layer.
