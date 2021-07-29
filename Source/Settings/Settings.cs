using UnityEngine;
using Verse;

namespace AutoStripOnHaul
{
    internal class Settings : ModSettings
    {
        public const int DropAll = 7; //Max drop value: All apparel will be dropped
        public static int NonsmeltableApparelToDrop => nonsmeltableApparelToDrop;

        private static int nonsmeltableApparelToDrop;

        public Settings()
        {
            nonsmeltableApparelToDrop = DropAll;
        }

        internal static void DoWindowContents(Rect inRect)
        {
            //30f for top page description and bottom close button
            Rect viewRect = new Rect(0f, 30f, inRect.width, inRect.height - 30f);

            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.ColumnWidth = viewRect.width;
            listingStandard.Begin(viewRect);
            listingStandard.Gap(5f);
            listingStandard.Label("AutoStripOnHaul_SettingsDescription".Translate());
            listingStandard.Gap(30f);
            if (nonsmeltableApparelToDrop == DropAll)
            {
                listingStandard.Label("AutoStripOnHaul_NonsmeltableApparelToDrop".Translate() + ": " + "AutoStripOnHaul_DropAll".Translate());
            } 
            else
            {
                listingStandard.Label("AutoStripOnHaul_NonsmeltableApparelToDrop".Translate() + ": " + NonsmeltableApparelToDrop);
            }
            nonsmeltableApparelToDrop = Mathf.RoundToInt(listingStandard.Slider(nonsmeltableApparelToDrop, 0, DropAll));

            listingStandard.Gap(30f);
            listingStandard.Label("AutoStripOnHaul_SettingsDescriptionTwo".Translate());
            listingStandard.Gap(150f);
            if (listingStandard.ButtonText("AutoStripOnHaul_ResetAll".Translate()))
            {
                nonsmeltableApparelToDrop = DropAll;
            }
            listingStandard.End();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref nonsmeltableApparelToDrop, "NonsmeltableApparelToDrop");
        }
    }
}
