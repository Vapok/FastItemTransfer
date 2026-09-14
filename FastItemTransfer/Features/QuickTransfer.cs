using System;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using FastItemTransfer.Configuration;
using HarmonyLib;
using UnityEngine;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Shared;

namespace FastItemTransfer.Features;

public static class QuickTransfer
{
    public static bool FeatureInitialized = false;
    public static ConfigEntry<bool> EnableQuickTransfer;

    private static InventoryGui _inventoryGuiInstance;
    private static Inventory _fromInventory;
    private static Inventory _toInventory;

    private static bool _processingRightClick = false;
    private static ConfigEntry<bool> _abpQuickTransferEntry;
    private static bool _abpChecked = false;
    private static bool _hasBlumayeMod = false;
    private static bool _blumayeChecked = false;

    static QuickTransfer()
    {
        ConfigRegistry.Waiter.StatusChanged += (_, _) => RegisterConfigurationFile();
    }

    private static void RegisterConfigurationFile()
    {
        ConfigSyncBase.UnsyncedConfig("Local Config", "Enable Quick Right Click Item Transfer", true,
            new ConfigDescription("When enabled, can move items to/from player inventory to container, by right clicking.",
                null,
                new ConfigurationManagerAttributes { Order = 5 }), ref EnableQuickTransfer);
    }

    private static bool IsHandledByAdventureBackpacks()
    {
        if (!_abpChecked)
        {
            if (Chainloader.PluginInfos.TryGetValue("vapok.mods.adventurebackpacks", out var pluginInfo) && pluginInfo?.Instance != null)
            {
                pluginInfo.Instance.Config.TryGetEntry("Local Config", "Enable Quick Right Click Item Transfer", out _abpQuickTransferEntry);
                _abpChecked = _abpQuickTransferEntry != null;
            }
            else
            {
                _abpChecked = true;
            }
        }

        return _abpQuickTransferEntry != null && _abpQuickTransferEntry.Value;
    }

    private static bool HasBlumayeMod()
    {
        if (!_blumayeChecked)
        {
            _hasBlumayeMod = Chainloader.PluginInfos.ContainsKey("blumaye.quicktransfer");
            _blumayeChecked = true;
            if (_hasBlumayeMod)
            {
                FastItemTransfer.Log.Warning("blumaye.quicktransfer mod is enabled. Fast Item Transfer disabled.");
            }
        }

        return _hasBlumayeMod;
    }

    [HarmonyPatch(typeof(InventoryGui), nameof(InventoryGui.OnRightClickItem))]
    [HarmonyPriority(Priority.First)]
    static class OnRightClickItemPatch
    {
        static void Prefix(InventoryGui __instance, InventoryGrid grid, ItemDrop.ItemData item)
        {
            if (!FeatureInitialized)
                return;
            
            if (Player.m_localPlayer == null || __instance == null || item == null)
                return;

            if (__instance.m_currentContainer == null || !__instance.IsContainerOpen() || !EnableQuickTransfer.Value)
                return;

            if (HasBlumayeMod())
                return;

            if (IsHandledByAdventureBackpacks())
                return;

            if (item.m_equipped)
                return;

            var containerInventory = __instance.m_currentContainer.GetInventory();
            var playerInventory = Player.m_localPlayer.GetInventory();

            if (playerInventory == null || containerInventory == null || grid == null)
                return;

            _inventoryGuiInstance = __instance;
            
            if (grid.m_inventory == containerInventory)
            {
                _fromInventory = containerInventory;
                _toInventory = playerInventory;
            }
            else if (grid.m_inventory == playerInventory)
            {
                _fromInventory = playerInventory;
                _toInventory = containerInventory;
            }
            else
            {
                return;
            }

            _processingRightClick = true;
        }
        
        static void Finalizer(Exception __exception)
        {
            _processingRightClick = false;
            _toInventory = null;
            _fromInventory = null;
            _inventoryGuiInstance = null;
        }
    }
    
    [HarmonyPatch(typeof(Humanoid), nameof(Humanoid.UseItem))]
    [HarmonyPriority(Priority.First)]
    static class UseItemPatch
    {
        static bool Prefix(ItemDrop.ItemData item)
        {
            if (!_processingRightClick)
                return true;

            if (_toInventory == null || _fromInventory == null || _inventoryGuiInstance == null || item == null)
                return true;

            int originalStack = item.m_stack;
            _toInventory.MoveItemToThis(_fromInventory, item);

            if (!_fromInventory.ContainsItem(item) || item.m_stack < originalStack)
            {
                _inventoryGuiInstance.m_moveItemEffects.Create(_inventoryGuiInstance.transform.position, Quaternion.identity);
            }

            return false;
        }
    }

}
