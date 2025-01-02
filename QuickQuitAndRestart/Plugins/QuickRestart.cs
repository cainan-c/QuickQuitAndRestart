using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using BepInEx;
using HarmonyLib;

namespace QuickQuitAndRestart.Plugins
{
    [HarmonyPatch]
    public class QuickRestart
    {
        [HarmonyPatch(typeof(EnsoGameManager), "ProcExecPause")]
        [HarmonyPrefix]
        static void customProcExecPause()
        {
            if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            {
                TaikoSingletonMonoBehaviour<CommonObjects>.Instance.MySceneManager.ChangeRelayScene("Enso", true);
            }
        }
    }
 }
