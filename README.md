Local Multiplayer Chat System - Unity
A simple local multiplayer chat system built with Unity's Netcode for GameObjects (NGO) and Unity Transport, allowing players to connect over the same Wi-Fi network and exchange messages in real-time.

📌 Features
✅ Local Multiplayer Connection – Players can discover and connect over the same Wi-Fi network.
✅ Real-Time Messaging – Send and receive text messages instantly across all connected players.
✅ No Internet Required – Works entirely offline using LAN-based networking.
✅ Simple UI – Displays connected players and chat messages in a clean interface.

🛠️ Technologies Used
Unity 2021.3+ (LTS recommended)

Netcode for GameObjects (NGO) – For networking logic

Unity Transport – Handles LAN/Wi-Fi communication

TextMeshPro – For UI text rendering

🚀 Installation & Setup
1. Clone the Repository
bash
Copy
git clone https://github.com/NaviKumar-h/Local-Multiplayer-Chat-System.git
cd local-multiplayer-chat
2. Open in Unity
Use Unity 2021.3 or later (LTS version recommended).

Open the project folder in Unity Hub.

3. Install Required Packages
Ensure these packages are installed via Package Manager (Window > Package Manager):

Netcode for GameObjects (com.unity.netcode.gameobjects)

Unity Transport (com.unity.transport)

4. Run the Project
Open the main scene (Scenes/Main.unity).

Host Mode: Click "Host" to create a game.

Client Mode: Click "Client" to join an existing game.

Send Messages: Type in the input field and press Enter or click Send.

🎮 How It Works
Network Setup

Uses Unity Transport for LAN-based communication.

Host acts as the server, Clients connect to it.

Player Connection

Players are assigned unique IDs.

The UI updates dynamically when players join/leave.

Messaging System

Messages are sent via ServerRpc and broadcast using ClientRpc.

All players see messages in real-time.

📂 Project Structure
Copy
Assets/
├── Scripts/
│   ├── NetworkManagerScript.cs  // Handles host/client setup
│   ├── PlayerController.cs      // Manages player networking
│   └── ChatUIManager.cs         // Handles UI & messaging
├── Prefabs/
│   ├── Player.prefab            // Networked player object
│   ├── PlayerListItem.prefab    // UI element for player list
│   └── ChatMessage.prefab       // UI element for messages
└── Scenes/
    └── Main.unity               // Main game scene
🔧 Troubleshooting
❌ Clients can't connect?

Ensure all devices are on the same Wi-Fi network.

Check firewall settings (allow Unity traffic).

❌ Messages not appearing?

Verify NetworkManager and Unity Transport are properly configured.

Ensure ChatUIManager has all UI references assigned.

❌ Build not working?

Test in Editor first, then build for the same platform (Windows/macOS).

📜 License
This project is open-source under the MIT License.

📬 Contact
For questions or improvements, feel free to reach out:
📧 Email: nknavekumar@gmail.com


