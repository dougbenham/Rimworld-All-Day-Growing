using HarmonyLib;
using RimWorld;
using Verse;

namespace AllDayGrowing
{
    [StaticConstructorOnStartup]
    static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = new Harmony("doug.AllDayGrowing");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(CompSchedule), "RecalculateAllowed")]
    public static class CompSchedule_RecalculateAllowed_Patch
    {
        [HarmonyPrefix]
        public static bool RecalculateAllowed(ref CompSchedule __instance)
        {
            if (__instance.parent.def.defName == "SunLamp")
            {
                __instance.Allowed = true;
                return false;
            }

            return true;
        }
    }

    [HarmonyPatch(typeof(Plant), "get_Resting")]
    public static class Plant_Resting_Patch
    {
        [HarmonyPrefix]
        public static bool Resting(ref bool __result)
        {
            __result = false;
            
            return false;
        }
    }
}
