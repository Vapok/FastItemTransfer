/* FastItemTransfer by Vapok */
using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using FastItemTransfer.Configuration;
using FastItemTransfer.Features;
using Jotunn.Managers;
using Vapok.Common.Abstractions;
using Vapok.Common.Managers;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Managers.LocalizationManager;
using Vapok.Common.Managers.Splash;
using Vapok.Common.Tools;

namespace FastItemTransfer
{
    [BepInPlugin(_pluginId, _displayName, _version)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [BepInDependency("com.ValheimModding.YamlDotNetDetector")]
    public class FastItemTransfer : BaseUnityPlugin, IPluginInfo
    {
        //Module Constants
        private const string _pluginId = "vapok.mods.fastitemtransfer";
        private const string _displayName = "Fast Item Transfer";
        private const string _version = "2.0.4";
        
        //Interface Properties
        public string PluginId => _pluginId;
        public string DisplayName => _displayName;
        public string Version => _version;
        public BaseUnityPlugin Instance => _instance;
        
        //Class Properties
        public static ILogIt Log => _log;
        public static bool ValheimAwake = false;
        public static Waiting Waiter;
        
        //Class Privates
        private static FastItemTransfer _instance;
        private static ConfigSyncBase _config;
        private static ILogIt _log;
        private Harmony _harmony;
        
        // This the main function of the mod. BepInEx will call this.
        private void Awake()
        {
            //I'm awake!
            _instance = this;
            
            //Waiting For Startup
            Waiter = new Waiting();
            
            //Jotunn Localization
            var localization = LocalizationManager.Instance.GetLocalization();

            //Register Logger
            LogManager.Init(PluginId,out _log);

            //Initialize Managers
            Initializer.LoadManagers(localization);

            //Register Configuration Settings
            _config = new ConfigRegistry(_instance);

            ModSplashManager.Register(new ModSplashDossier(_instance)
            {
                Tagline = "Fast one-click inventory and container item transfers for seamless chest management.",
                ShowOnStartup = ConfigRegistry.ShowSplashOnStartup,
                EnableTelemetry = ConfigRegistry.EnableTelemetry,
            });

            Localizer.Waiter.StatusChanged += InitializeModule;
            
            //Register Features
            QuickTransfer.FeatureInitialized = true;
            
            //Patch Harmony
            _harmony = new Harmony(Info.Metadata.GUID);
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            //???

            //Profit
        }

        public void InitializeModule(object send, EventArgs args)
        {
            if (ValheimAwake)
                return;
            
            ConfigRegistry.Waiter.ConfigurationComplete(true);

            ValheimAwake = true;
        }
        
        private void OnDestroy()
        {
            _instance = null;
            _harmony?.UnpatchSelf();
        }

        public class Waiting
        {
            public void ValheimIsAwake(bool awakeFlag)
            {
                if (awakeFlag)
                    StatusChanged?.Invoke(this, EventArgs.Empty);
            }
            public event EventHandler StatusChanged;            
        }
    }
}
