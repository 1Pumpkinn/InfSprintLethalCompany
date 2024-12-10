using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using HarmonyLib;

namespace TutorialMod.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControlledBPatch
    {

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void infiniteSprintPatch(ref float ___sprintMeter)
        {
            ___sprintMeter = 1f;
        }


    }
}
