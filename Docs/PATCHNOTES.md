# 2.0.8 - Internalized Library & Dependency Updates
* **Shutdown Cleanliness (`FastItemTransfer.cs`)**:
  * Removed `_harmony?.UnpatchSelf()` from `OnDestroy()` to avoid Mono dynamic method inspection `InvalidOperationException` during application exit under Unity 6.
* **Dependency Updates**:
  * Updated internalized `Vapok.Valheim.Common` to 3.19.1015.
  * Updated `JotunnLib` dependency to 2.30.2.
* **Stability & Verification**:
  * Confirmed headless dedicated server isolation and verified UI compatibility.

# 2.0.7 - Headless Dedicated Server Bypass & Valheim 1.0.15 Alignment
* **Dedicated Server Safety**:
  * In `FastItemTransfer.cs`, added `SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null` bypass at the start of `Awake()`, completely preventing client GUI patches from executing on headless dedicated servers.
* **Valheim 1.0.15 Game Reference Alignment**:
  * Updated game assembly bindings to target Valheim `1.0.15`.
  * Internalized `Vapok.Valheim.Common` v3.13.1015.

# 2.0.6 - Splash Window Updates & Valheim 1.0.14 Alignment
* **Splash Window Updates**:
  * Updated telemetry default to unchecked on first launch (Opt-In).
  * Added Send Error Logs toggle (Opt-Out) to capture anonymous crash diagnostics and error reports.
  * Added in-game scrollable Privacy Policy overlay with responsive mouse wheel support.
  * Added interactive tooltip data disclaimers on checkbox hover.
* **Valheim 1.0.14 Alignment**:
  * Aligned publicized game assembly and UnityEngine references to Valheim 1.0.14.
  * Updated internalized  dependency to 3.12.1014.

# 2.0.5 - Jewelcrafting Font Compatibility
* **Compatibility Fix**: Fixed issue where Jewelcrafting packages its own font which was overriding part of a vanilla font, causing the Splash screen to appear blank.
* **Vapok.Common Dependency Bump**: Updated internalized dependency to `Vapok.Valheim.Common` 3.11.1012.

# 2.0.4 - Updated README with Telemetry Information
* **Documentation Update**: Updated the README.md with Anonymous Telemetry and Privacy section per request of mod stores.
* **Vapok.Common Dependency Bump**: Updated internalized dependency to `Vapok.Valheim.Common` 3.9.1012.

# 2.0.3 - Unified Splash Screen & Telemetry Controls
* **Unified Startup Splash Screen & Telemetry**:
  * Updated `Vapok.Valheim.Common` dependency reference to `v3.5.1012`.
  * Registered mod metadata with centralized `ModSplashManager`.
  * Added `ShowSplashOnStartup` and `Enable Anonymous Telemetry` configuration bindings to `ConfigRegistry`.

# 2.0.1 - Dependency & Compatibility Maintenance
* **Runtime & Dependency Updates**:
  * Synchronized package manifest and project references with Jotunn `2.30.0` and BepInEx `5.4.2350`.
  * Verified build pipeline and ILRepack bundling with `Vapok.Valheim.Common` `3.2.1012`.
* **Compatibility & Documentation**:
  * Validated fast item transfer mechanics and right-click intercept hooks against current Valheim 1.0 builds.
  * Standardized mod documentation, changelog tiers, and Thunderstore release staging.

# 2.0.0 - Valheim 1.0 Release & Cross-Mod Compatibility
* **Valheim 1.0 Compatibility & Core Updates**:
  * Updated assembly references for Valheim 1.0 (`1.0.12`), BepInEx 5.4.2350, and Jotunn 2.30.0.
  * Rebuilt on .NET Framework 4.8.
  * Bundled `Vapok.Valheim.Common` 3.2.1012 via ILRepack.
* **AdventureBackpacks Dynamic Coexistence**:
  * Implemented dynamic reflection and state inspection for AdventureBackpacks.
  * When AdventureBackpacks is present with its *Quick Transfer* configuration active, Fast Item Transfer automatically defers right-click handling to prevent duplicate move operations or conflicting sound effects.
* **Third-Party Inventory Grid Validation**:
  * Added explicit `InventoryGrid` validation checks to safely ignore custom modded inventory panels (e.g., Equipment & Quick Slots, Jewelcrafting sockets, custom bag grids) during container transfer processing.
* **Competing Mod Optimization**:
  * Cached mod presence lookups for competing transfer mods (such as `blumaye.quicktransfer`) to eliminate per-interaction plugin queries and avoid log spam.
* **Audio, Visual & Performance Polish**:
  * Restructured item transfer hooks so that particle effects and audio feedback trigger strictly upon confirmed item movements.
  * Removed empty `Update()` lifecycle loops on plugin components to eliminate idle CPU cycles.

# 1.0.3 - Valheim 0.216.9 Maintenance
* Updated references for Valheim 0.216.9 compatibility.

# 1.0.2 - Valheim 0.214.2 & BepInEx Updates
* Updated for Valheim 0.214.2 and BepInEx 5.4.21.
* General code cleanup and stability improvements.

# 1.0.1 - Inventory Mod Compatibility Rework
* Reworked transfer intercept logic to ensure compatibility with `Auto Split Stack` and `Quick Stack Sort`.
* Added defensive null checks across container inventory queries.

# 1.0.0 - Initial Release of Fast Item Transfer
* Initial release of right-click fast item transfer mechanics between player inventory and open containers.
