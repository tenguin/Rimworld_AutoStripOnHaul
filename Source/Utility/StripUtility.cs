using System.Collections.Generic;
using Verse;
using RimWorld;

namespace AutoStripOnHaul
{
    internal class StripUtility
    {
        public static void StripAll(ref Thing thing)
        {
            if (thing as IStrippable == null || !(thing as IStrippable).AnythingToStrip())
            {
                return;
            }
            Corpse corpse = thing as Corpse;
            if (corpse?.InnerPawn != null)
            {
                Pawn innerPawn = corpse.InnerPawn;
                if (innerPawn.Faction != null && innerPawn.Faction.IsPlayer) //Don't strip own faction
                {
                    return;
                }
                if (innerPawn.equipment != null)
                {
                    innerPawn.equipment.DropAllEquipment(corpse.PositionHeld, forbid: Settings.ForbidEquipment);
                }
                if (innerPawn.inventory != null)
                {
                    innerPawn.inventory.DropAllNearPawn(corpse.PositionHeld, forbid: Settings.ForbidInventory);
                }
                if (innerPawn.apparel != null)
                {
                    DropAllApparel(innerPawn.apparel, corpse.PositionHeld, innerPawn.Destroyed);
                }
            }
        }

        //Drops all smeltable apparel & a configurable amount of non-smeltable apparel
        private static void DropAllApparel(Pawn_ApparelTracker apparelTracker, IntVec3 pos, bool dropLocked = true)
        {
            int nonsmeltablesDropped = 0;
            int smeltablesDropped = 0;
            List<Apparel> dropList = new List<Apparel>();
            for (int i = 0; i < apparelTracker.WornApparel.Count; i++)
            {
                if (dropLocked || !apparelTracker.IsLocked(apparelTracker.WornApparel[i]))
                {
                    if (!apparelTracker.WornApparel[i].WornByCorpse)
                    {
                        dropList.Add(apparelTracker.WornApparel[i]);
                    }
                    else if (apparelTracker.WornApparel[i].Smeltable &&
                        (Settings.SmeltableApparelToDrop == Settings.DropAll || smeltablesDropped < Settings.SmeltableApparelToDrop))
                    {
                        smeltablesDropped++;
                        dropList.Add(apparelTracker.WornApparel[i]);
                    }
                    else if (Settings.NonsmeltableApparelToDrop == Settings.DropAll || nonsmeltablesDropped < Settings.NonsmeltableApparelToDrop)
                    {
                        nonsmeltablesDropped++;
                        dropList.Add(apparelTracker.WornApparel[i]);
                    }
                }
            }
            for (int j = 0; j < dropList.Count; j++)
            {
                if ((Settings.ForbidTaintedNonSmeltables && !dropList[j].Smeltable && dropList[j].WornByCorpse) ||
                    (Settings.ForbidTaintedSmeltables && dropList[j].Smeltable && dropList[j].WornByCorpse))
                {
                    apparelTracker.TryDrop(dropList[j], out Apparel _, pos, forbid: true);
                }
                else if (Settings.ForbidEquipment && !dropList[j].WornByCorpse)
                {
                    apparelTracker.TryDrop(dropList[j], out Apparel _, pos, forbid: true);
                }
                else
                {
                    apparelTracker.TryDrop(dropList[j], out Apparel _, pos, forbid: false);
                }
            }
            if(Settings.AutoDestroy)
                apparelTracker.DestroyAll();
        }
    }
}
