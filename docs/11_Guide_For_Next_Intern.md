# 🚀 Guide for the Next Intern

Welcome to the HESTIM Smart Factory VR Project! If you are reading this, you are likely taking over the development of the Digital Twin. This document is a structured roadmap designed specifically to get you up to speed quickly.

## The "Start Here" Checklist
Do not try to write code on Day 1. Follow this checklist to understand the architecture:
- [ ] **Clone the repository** and make sure you have the correct Unity version (Unity 6) installed.
- [ ] **Read the Architecture documentation** (`02_System_Architecture.md`, `03_Unity_Architecture.md`, `04_FastAPI.md`).
- [ ] **Run the Unity project** in the Editor. Navigate through the Main Menu and try the Timed Labeling scenario.
- [ ] **Verify FastAPI communication**: Start the Python server, use an API testing tool (like Postman or cURL) to send a fake temperature payload, and watch it update in Unity.
- [ ] **Test the labeling scenario in VR** using the Meta Quest 3.
- [ ] **Review the known issues** in the `09_Troubleshooting.md` file.

## Suggested Roadmap (Your First Month)

### Week 1: Understanding Unity & VR
*   Familiarize yourself with the **XR Interaction Toolkit**. Learn how grabbing and raycasting work.
*   Examine the `StepManager` script in Unity. Look at the Inspector to see how the labeling scenario steps are linked together.
*   **Goal:** Successfully run the VR app and understand how the 3D models are structured.

### Week 2: Mastering the IoT Data Pipeline
*   Study the **FastAPI** code. Understand how WebSockets differ from standard HTTP requests.
*   Look at the **ESP32** C++ code. Learn how it connects to Wi-Fi and sends JSON data.
*   **Goal:** Add a "fake" sensor in the FastAPI code and make it update a visual element (like a UI text panel) inside Unity.

### Week 3: Tackling Multiplayer (Unity Netcode)
*   The highest priority future work is the Collaborative Factory Layout scenario.
*   Study **Unity Netcode for GameObjects**. Understand the concepts of "Host", "Client", and "NetworkVariables".
*   **Goal:** Create a simple test scene where two users can see each other's avatars and move a shared 3D box.

### Week 4: Integration and Testing
*   Integrate your multiplayer logic into the main Smart Factory environment.
*   Conduct tests with your supervisors or fellow students.
*   **Goal:** Have a working prototype of the collaborative layout mode.

## Final Advice
You are working with three completely different environments: C# (Unity), Python (FastAPI), and C++ (ESP32). **Do not try to debug everything at once.** 
If data isn't showing up in VR, trace it step-by-step:
1. Is the ESP32 printing the data to its Serial Monitor?
2. Is the FastAPI server logging an incoming request?
3. Is Unity throwing a WebSocket error in the Console?

Good luck!
