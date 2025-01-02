using BepInEx.Unity.IL2CPP.Utils;
using BepInEx.Unity.IL2CPP;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using BepInEx.Configuration;
using QuickQuitAndRestart.Plugins;
using UnityEngine;
using System.Collections;

namespace QuickQuitAndRestart
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, QuickQuitAndRestart, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public const string QuickQuitAndRestart = "QuickQuitAndRestart";

        public static Plugin Instance;
        private Harmony _harmony = null;
        public new static ManualLogSource Log;


        public ConfigEntry<bool> ConfigEnabled;
        public ConfigEntry<string> ConfigSongTitleLanguageOverride;
        public ConfigEntry<float> ConfigFlipInterval;

        public static ConfigEntry<bool> configQuickRestart;
        public static ConfigEntry<bool> configQuickQuitSong;

        public override void Load()
        {
            Instance = this;

            Log = base.Log;

            SetupConfig();
            SetupHarmony();
        }

        private void SetupConfig()
        {
            var dataFolder = Path.Combine("BepInEx", "data", QuickQuitAndRestart);

            // Add configurations

            ConfigEnabled = Config.Bind("General",
                "Enabled",
                true,
                "Enables the mod.");

            configQuickRestart = Config.Bind("General.Toggles",
                        "QuickRestart",
                        false,
                        "Hit \"Backspace\" on your keyboard to quickly restart a song.");

            configQuickQuitSong = Config.Bind("General.Toggles",
                        "QuickQuitSong",
                        false,
                        "Hit \"Escape\" on your keyboard to quickly quit a song and return to Song Select.");
        }

        private void SetupHarmony()
        {
            // Patch methods
            _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            if (Plugin.configQuickRestart.Value)
                _harmony.PatchAll(typeof(QuickRestart));

            if (Plugin.configQuickQuitSong.Value)
                _harmony.PatchAll(typeof(QuickQuitSong));

            if (ConfigEnabled.Value)
            {
                bool result = true;
                // If any PatchFile fails, result will become false

                if (result)
                {
                    Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_NAME} is loaded!");
                }
                else
                {
                    Log.LogError($"Plugin {MyPluginInfo.PLUGIN_GUID} failed to load.");
                    // Unload this instance of Harmony
                    // I hope this works the way I think it does
                    _harmony.UnpatchSelf();
                }
            }
            else
            {
                Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_NAME} is disabled.");
            }
        }

        private bool PatchFile(Type type)
        {
            if (_harmony == null)
            {
                _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            }
            try
            {
                _harmony.PatchAll(type);
#if DEBUG
                Log.LogInfo("File patched: " + type.FullName);
#endif
                return true;
            }
            catch (Exception e)
            {
                Log.LogInfo("Failed to patch file: " + type.FullName);
                Log.LogInfo(e.Message);
                return false;
            }
        }

        public static MonoBehaviour GetMonoBehaviour() => TaikoSingletonMonoBehaviour<CommonObjects>.Instance;
        public void StartCoroutine(IEnumerator enumerator)
        {
            GetMonoBehaviour().StartCoroutine(enumerator);
        }
    }
}
