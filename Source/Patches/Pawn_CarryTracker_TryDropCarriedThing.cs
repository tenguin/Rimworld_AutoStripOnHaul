using HarmonyLib;
using Verse;
using System;

namespace AutoStripOnHaul
{
    [HarmonyPatch(typeof(Pawn_CarryTracker), "TryDropCarriedThing",
        new Type[] { typeof(IntVec3), typeof(ThingPlaceMode), typeof(Thing), typeof(Action<Thing, int>) },
        new ArgumentType[] { ArgumentType.Normal, ArgumentType.Normal, ArgumentType.Out, ArgumentType.Normal })]
    internal static class Pawn_CarryTracker_TryDropCarriedThing
    {
        [HarmonyPrefix]
        private static void TryDropCarriedThing(ref Pawn_CarryTracker __instance)
        {
            if (Settings.StripAfterHaul)
            {
                Thing thing = __instance.CarriedThing;
                StripUtility.StripAll(ref thing);
            }
        }
    }
}