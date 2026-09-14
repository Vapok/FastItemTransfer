# Fast Item Transfer by Vapok

**Fast Item Transfer** is a lightweight, seamless quality-of-life mod for Valheim that enables instant item movement between the player's inventory and open containers (chests, carts, ships, etc.) using a simple right-click.

Designed with performance and compatibility in mind, it provides smooth, responsive inventory management with zero per-frame overhead and smart cross-mod detection.

---

## ✨ Features

* **Instant One-Click Transfer**: Right-click any unequipped item in your player inventory while a container is open to instantly send it to the container. Right-click an item in a container to instantly send it to your player inventory.
* **Smart Stacking**: Items automatically merge into existing matching stacks in the target inventory or populate the first available slot.
* **Audio & Visual Feedback**: Plays vanilla item transfer sounds and particle effects upon successful item moves.
* **Zero Performance Impact**: Operates strictly on user interaction without any per-frame update loops or polling overhead.
* **Real-Time Configuration**: Toggle the mod on or off on the fly using the in-game [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager) (default hotkey: `F1`).

---

## 🧩 Cross-Mod Compatibility & Integrations

Fast Item Transfer is built to play nicely with your modded Valheim setup:

* **🎒 [AdventureBackpacks](https://valheim.thunderstore.io/package/Vapok/AdventureBackpacks/)**:
  * **Dynamic Coexistence**: Fast Item Transfer includes built-in live detection for AdventureBackpacks. If AdventureBackpacks is installed and its *Quick Transfer* configuration is active, Fast Item Transfer will automatically defer and let AdventureBackpacks handle right-click transfers without conflicts or double-moves. If AdventureBackpacks has Quick Transfer disabled, Fast Item Transfer will seamlessly handle transfers as normal.
* **📦 Quick Stack, Store & Sort Mods**:
  * Compatible with mods such as **Quick Stack Store**, **Auto Split Stack**, and **Quick Stack Sort**.
* **🛡️ Custom Inventory & Equipment Slot Mods**:
  * Explicit grid-validation safeguards prevent unintended interactions with custom inventory grids or special slot extensions (e.g., Jewelcrafting, Equipment and Quick Slots).
* **⚠️ Conflicting Standalone Mods**:
  * Automatically detects and gracefully yields if conflicting legacy plugins (such as `blumaye.quicktransfer`) are detected in your load order.

---

## 📦 Installation

### Automatic Installation (Recommended)
Install using your preferred mod manager (e.g., [r2modman](https://valheim.thunderstore.io/package/ebkr/r2modman/) or [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager)).

### Manual Installation
1. Ensure [BepInEx Pack for Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/) and [Jötunn, the Valheim Library](https://valheim.thunderstore.io/package/ValheimModding/Jotunn/) are installed.
2. Download the latest release package from [Thunderstore](https://valheim.thunderstore.io/package/Vapok/FastItemTransfer/) or [GitHub Releases](https://github.com/Vapok/FastItemTransfer/releases).
3. Extract `FastItemTransfer.dll` into your `Valheim/BepInEx/plugins/` directory (or create a `FastItemTransfer` subfolder).

---

## 📋 Patch Notes
See the full changelog in [CHANGELOG.md](https://github.com/Vapok/FastItemTransfer/blob/main/CHANGELOG.md) or on [Thunderstore](https://thunderstore.io/c/valheim/p/Vapok/FastItemTransfer/changelog/).

---

## 👥 Credits & Contact

![Vapok Gaming](https://avatars.githubusercontent.com/u/1264136?s=180&v=4)

* **Mod Author**: [Vapok](https://github.com/Vapok)
* **Source Code**: [GitHub Repository](https://github.com/Vapok/FastItemTransfer)
* **Discord Community**: [Vapok's Mod Community](https://discord.gg/5YAJkRFBXt)
