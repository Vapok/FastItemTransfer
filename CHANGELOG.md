# Fast Item Transfer Patchnotes

## 1.1.3 - Valheim & Dependency Maintenance
* Updated to Valheim 0.221.12 references.
* Updated Vapok.Valheim.Common to 2.11.22112.
* Updated Jotunn to 2.29.0.
* Updated YamlDotNet to 16.3.1.
* Fixed: Right-click transfer state was never cleared on success, so the next UseItem (e.g. consuming item, using tool) could be skipped. State is now cleared after transfer and defensive null checks added.

## 1.1.2 - Resolving an item duplication issue.
* This mod was causing an item duplication issue when paired with specific other mods.
  * This has been resolved.
* Updated Dependencies

## 1.1.1 - Fixing Dedicated Server Config Syncing
* A regression issue was introduced when switching to Jotunn preventing servers from dictating configs to clients.
  * This has been resolved.
* Appropriately added the BepInDependency Flags for graceful mod exit if missing dependencies.

## 1.1.0 - Replaces ServerSync for JotunnVL
* Updates to Valheim 0.221.4

## 1.0.5 - Valheim Updates
* Updates to Valheim 0.217.28

## 1.0.4 - Valheim Updates
* Updates to Valheim 0.217.24

## 1.0.3 - Valheim Updates
* Updates to Valheim 0.216.9

## 1.0.2 - Valheim and BepInEx Updates
* Updates to Valheim 0.214.2
* Updates to BepInEx 5.4.21
* Various Clean Up

## 1.0.1 - Module Compatibility
* Reworked Logic to make Fast Item Transfer friendly to other inventory mods.
  * Adds Compatibility to **[Auto Split Stack](https://www.nexusmods.com/valheim/mods/76?tab=files&file_id=7184)**, as well as **[Quick Stack Sort](https://www.nexusmods.com/valheim/mods/2094?tab=description)**
  * May add additional compatibility to other mods not tested.

## 1.0.0 - Initial Release
* Provides Right Click functionality to move items between Player Inventory and Containers
* Lightweight, minimal overhead QoL Module