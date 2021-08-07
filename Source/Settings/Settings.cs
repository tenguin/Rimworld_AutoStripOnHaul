using UnityEngine;
using Verse;

namespace AutoStripOnHaul
{
    internal partial class Settings : ModSettings
    {
        internal static void DoWindowContents(Rect inRect)
        {
            //30f for top page description and bottom close button
            Rect viewRect = new Rect(0f, 30f, inRect.width, inRect.height - 30f);

            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.ColumnWidth = viewRect.width;
            listingStandard.Begin(viewRect);
            listingStandard.Gap(5f);
            listingStandard.Label("AutoStripOnHaul_SettingsDescription".Translate());
            listingStandard.Gap(15f);
            listingStandard.Label("AutoStripOnHaul_SettingsDescriptionTwo".Translate());
            listingStandard.Gap(15f);

            //Smeltable Drop Slider
            if (smeltableApparelToDrop == DropAll)
            {
                listingStandard.Label("AutoStripOnHaul_SmeltableApparelToDrop".Translate() + ": " + "AutoStripOnHaul_DropAll".Translate());
            }
            else
            {
                listingStandard.Label("AutoStripOnHaul_SmeltableApparelToDrop".Translate() + ": " + smeltableApparelToDrop);
            }
            smeltableApparelToDrop = Mathf.RoundToInt(listingStandard.Slider(smeltableApparelToDrop, 0, DropAll));

            //NonSmeltable Drops Slider
            if (nonsmeltableApparelToDrop == DropAll)
            {
                listingStandard.Label("AutoStripOnHaul_NonsmeltableApparelToDrop".Translate() + ": " + "AutoStripOnHaul_DropAll".Translate());
            }
            else
            {
                listingStandard.Label("AutoStripOnHaul_NonsmeltableApparelToDrop".Translate() + ": " + NonsmeltableApparelToDrop);
            }
            nonsmeltableApparelToDrop = Mathf.RoundToInt(listingStandard.Slider(nonsmeltableApparelToDrop, 0, DropAll));

            //Warning Notice
            if(nonsmeltableApparelToDrop != DropAll || smeltableApparelToDrop != DropAll)
            {
                listingStandard.Label("AutoStripOnHaul_SettingsDescriptionThree".Translate());
            }
            else
            {
                listingStandard.Gap(24f);
            }


            //Forbid Checkboxes
            listingStandard.Gap(30f);
            listingStandard.CheckboxLabeled("AutoStripOnHaul_ForbidTaintedSmeltables".Translate() + ":", ref forbidTaintedSmeltables);
            listingStandard.CheckboxLabeled("AutoStripOnHaul_ForbidTaintedNonSmeltables".Translate() + ":", ref forbidTaintedNonSmeltables);
            listingStandard.CheckboxLabeled("AutoStripOnHaul_ForbidEquipment".Translate() + ":", ref forbidEquipment);

            //Drop On/After Haul
            listingStandard.Gap(15f);
            listingStandard.CheckboxLabeled("AutoStripOnHaul_StripAfterHaul".Translate() + ":", ref stripAfterHaul);


            listingStandard.Gap(170f);
            if (listingStandard.ButtonText("AutoStripOnHaul_ResetAll".Translate()))
            {
                Initialize();
            }
            listingStandard.End();
        }
    }
}
