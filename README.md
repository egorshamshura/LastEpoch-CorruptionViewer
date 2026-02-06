# CorruptionViewer Mod for Last Epoch

[![Nexus Mods Version](https://img.shields.io/badge/Version-1.0.3-blue)](https://www.nexusmods.com/lastepoch/mods/13)
[![Requires MelonLoader](https://img.shields.io/badge/Requires-MelonLoader-orange)](https://melonwiki.xyz/#/)

The **CorruptionViewer** mod allows you to view the current corruption value of monoliths in Last Epoch directly on the world map, eliminating the need to log into Echoweb each time. Values are automatically logged to a file every time you enter an Echoweb.

---

## Installation

### 1. Install MelonLoader
This mod requires **MelonLoader**, a universal mod loader for Unity games.
1.  Download **[MelonLoader.Installer.exe](https://github.com/HerpDerpinstine/MelonLoader/releases/latest/download/MelonLoader.Installer.exe)**.
2.  Run the installer.
3.  Click the **SELECT** button and browse to your game's executable (`Last Epoch.exe`).
4.  **Important:** From the version drop-down list, select **MelonLoader v0.6.1**. Version 0.6.2 has a known bug that can sometimes prevent the game from starting.
5.  Click the **INSTALL** or **RE-INSTALL** button.

For more detailed instructions, including Linux installation, please refer to the [official MelonLoader wiki](https://melonwiki.xyz/#/).

### 2. Install the CorruptionViewer Mod
1.  Launch your game once to allow MelonLoader to generate the necessary folders.
2.  Download the latest `CorruptionViewer.dll` file from the [Nexus Mods page](https://www.nexusmods.com/lastepoch/mods/13).
3.  Place the downloaded `.dll` file into the `Mods` folder within your Last Epoch game directory. The path should look similar to this:
    `...\Steam\steamapps\common\Last Epoch\Mods\`

---

## How to Use

Once installed, the mod works automatically:
1.  Open your world map.
2.  **Click on a monolith island** to select its waypoint.
3.  The island's name will update to display the corruption value in parentheses.
    *   **Example:** `The Stolen Lance (Corruption: 125)`

### How It Works & First-Time Setup
- The mod reads and caches corruption values each time you enter an **Echoweb**.
- **On first use, values may show as 0.** To populate the data:
    1.  Travel to a monolith island.
    2.  Enter its Echoweb once.
    3.  The mod will record the value, and it will now display correctly on the map for that character.

> **Note for Version 1.0.0:** This version does not support sharing corruption data between different characters. Data is stored per character.

---

## Links & Source
- **Download and endorse the mod on:** [Nexus Mods](https://www.nexusmods.com/lastepoch/mods/13)
- **Source Code & Releases:** [GitHub Repository](https://github.com/egorshamshura/LastEpoch-CorruptionViewer/releases)
- **MelonLoader Wiki:** [MelonLoader.xyz](https://melonwiki.xyz/#/)

---

## Troubleshooting
- **Game fails to start after mod installation:** Ensure you installed **MelonLoader v0.6.1** and not a newer, potentially buggy version.
- **No corruption values appear:** Make sure you have entered an Echoweb on the monolith island at least once with your current character.
- **Values are incorrect or outdated:** Re-enter an Echoweb to force the mod to fetch the latest data.

