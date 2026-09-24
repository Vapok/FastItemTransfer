using HarmonyLib;
using Jotunn.Managers;

namespace FastItemTransfer.Patches;

internal static class FejdStartupPatches
{
    [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.Awake))]
    [HarmonyAfter("org.bepinex.helpers.LocalizationManager")]
    [HarmonyBefore("org.bepinex.helpers.ItemManager")]
    internal static class FejdStartupAwakePatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => !GUIManager.IsHeadless();

        private static void Prefix()
        {
            FastItemTransfer.Waiter.ValheimIsAwake(true);
        }
    }
}