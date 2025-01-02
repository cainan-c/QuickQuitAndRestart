using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using BepInEx;
using HarmonyLib;

namespace QuickQuitAndRestart.Plugins
{
    [HarmonyPatch]
    public class QuickQuitSong
    {
        [HarmonyPatch(typeof(EnsoGameManager), "ProcExecPause")]
        [HarmonyPrefix]
        static void customProcExecPause()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                TaikoSingletonMonoBehaviour<CommonObjects>.Instance.MySceneManager.ChangeRelayScene("SongSelect", true);
            }
        }
    }
}