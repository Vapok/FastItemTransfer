# Fast Item Transfer Patchnotes

## 2.0.0 - Valheim 1.0 Release & Cross-Mod Compatibility
* **Valheim 1.0 Support**: Fully updated and verified for Valheim 1.0 and .NET 4.8.
* **AdventureBackpacks Dynamic Compatibility**: Automatically detects if AdventureBackpacks is installed and active; defers right-click transfers when AdventureBackpacks has Quick Transfer enabled to prevent duplicate operations or conflicts.
* **Third-Party Inventory Safety**: Added explicit inventory grid validation to safely ignore custom and third-party mod inventory grids (e.g. equipment slots, jewelcrafting).
* **Competing Mod Optimization**: Cached detection for competing quick transfer mods (`blumaye.quicktransfer`) to eliminate per-click lookups and log flooding.
* **Audio & Visual Polish**: Transfer effects only trigger when an item or stack is successfully transferred.
* **Performance Optimizations**: Removed empty per-frame update loop on the main plugin component.
* **Updated Framework**: Migrated to Jotunn 2.30.0 and Vapok.Valheim.Common 3.2.1012.

<details>
<summary><b>Changelog History</b> (<i>click to expand</i>)</summary>

### 1.0.3 - Valheim Updates
* Updates to Valheim 0.216.9

### 1.0.2 - Valheim and BepInEx Updates
* Updates to Valheim 0.214.2
* Updates to BepInEx 5.4.21
* Various Clean Up

### 1.0.1 - Module Compatibility
* Reworked Logic to make Fast Item Transfer friendly to other inventory mods.
  * Adds Compatibility to **[Auto Split Stack](https://www.nexusmods.com/valheim/mods/76?tab=files&file_id=7184)**, as well as **[Quick Stack Sort](https://www.nexusmods.com/valheim/mods/2094?tab=description)**
  * May add additional compatibility to other mods not tested.

### 1.0.0 - Initial Release
* Provides Right Click functionality to move items between Player Inventory and Containers
* Lightweight, minimal overhead QoL Module

</details>
