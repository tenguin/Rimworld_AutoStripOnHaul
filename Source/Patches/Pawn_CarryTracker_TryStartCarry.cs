using HarmonyLib;
using Verse;

namespace AutoStripOnHaul
{
    [HarmonyPatch(typeof(Pawn_CarryTracker), "TryStartCarry", new System.Type[] { typeof(Thing), typeof(int), typeof(bool) })]
    internal static class Pawn_CarryTracker_TryStartCarry
    {
        [HarmonyPrefix]
        private static void TryStartCarry(ref Thing item)
        {
            if (!Settings.StripAfterHaul)
            {
                StripUtility.StripAll(ref item);
            }
        }
    }
}