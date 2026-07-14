# Troubleshooting

## Unity & VR Issues
- **Controllers / Hands Not Tracking:** Ensure OpenXR is set as the active runtime in Project Settings. Verify that the Meta Quest Link is active if running over PC VR.
- **Interactions Failing:** Check the `XR Interaction Toolkit` layers and ensure the objects have the correct `XRGrabInteractable` components and colliders attached.

## FastAPI & Networking
- **WebSocket Drops in Unity:** Ensure the FastAPI server is running and accessible on the local network. Check Windows Firewall settings on the host machine to ensure port 8000 is open.
- **No Data from ESP32:** Verify the ESP32 serial monitor for connection errors. Ensure it is on the exact same Wi-Fi subnet as the FastAPI server.
