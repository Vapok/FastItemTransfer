# Fast Item Transfer Patchnotes

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