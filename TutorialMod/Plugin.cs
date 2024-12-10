using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TutorialMod.Patches;

namespace TutorialMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TutorialModBase : BaseUnityPlugin
    {
        private const string modGUID = "Poseidon.TutorialMod";
        private const string modName = "Tutorial Mod";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);


        private static TutorialModBase Instance;

        internal ManualLogSource nls;



        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            nls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            nls.LogInfo("The test mod has awaken :)");

            harmony.PatchAll(typeof(TutorialModBase));
            harmony.PatchAll(typeof(PlayerControlledBPatch));
            harmony.PatchAll(typeof(SprintMultiplierPatch));


        }
    }
}
