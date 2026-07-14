# Unity Architecture

The VR application is built in **Unity 6**, leveraging **OpenXR** and the **XR Interaction Toolkit** for cross-compatible VR interactions.

## Key Components

### Scene Management
Scenes are divided to separate the Digital Twin supervision environment from the pedagogical scenarios. This prevents the overhead of running unnecessary scripts when only training modules are required.

### Step Logic (`StepManager`)
A generic script manages the sequence of steps, timers, and audio cues for educational scenarios. The flow is controlled by specialized condition scripts:
- `placementCondition`: Validates if a user places an object in the correct zone.
- `snapCondition`: Handles snapping objects to targets automatically.
- `grabCondition`: Validates when a user successfully grasps the correct tool.
