using Verse;

namespace AutoStripOnHaul
{
    internal partial class Settings : ModSettings
    {
        public const int DropAll = 7; //Max drop value: All apparel will be dropped
        public static int SmeltableApparelToDrop => smeltableApparelToDrop;
        public static int NonsmeltableApparelToDrop => nonsmeltableApparelToDrop;
        public static bool ForbidTaintedSmeltables => forbidTaintedSmeltables;
        public static bool ForbidTaintedNonSmeltables => forbidTaintedNonSmeltables;
        public static bool ForbidEquipment => forbidEquipment;
        public static bool ForbidInventory => forbidInventory;
        public static bool AutoDestroy => autoDestroy;
        public static bool StripAfterHaul => stripAfterHaul;

        private static int smeltableApparelToDrop;
        private static int nonsmeltableApparelToDrop;
        private static bool forbidTaintedSmeltables;
        private static bool forbidTaintedNonSmeltables;
        private static bool forbidEquipment;
        private static bool forbidInventory;
        private static bool autoDestroy;
        private static bool stripAfterHaul;
        private static void Initialize()
        {
            smeltableApparelToDrop = DropAll;
            nonsmeltableApparelToDrop = 0;
            forbidTaintedSmeltables = false;
            forbidTaintedNonSmeltables = true;
            forbidEquipment = false;
            forbidInventory = true;
            autoDestroy = false;
            stripAfterHaul = false;
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref smeltableApparelToDrop, "SmeltableApparelToDrop", DropAll);
            Scribe_Values.Look(ref nonsmeltableApparelToDrop, "NonsmeltableApparelToDrop", 0);
            Scribe_Values.Look(ref forbidTaintedSmeltables, "ForbidTaintedSmeltables", false);
            Scribe_Values.Look(ref forbidTaintedNonSmeltables, "ForbidTaintedNonSmeltables", true);
            Scribe_Values.Look(ref forbidEquipment, "ForbidEquipment", false);
            Scribe_Values.Look(ref forbidInventory, "ForbidInventory", true);
            Scribe_Values.Look(ref autoDestroy, "AutoDestroy", false);
            Scribe_Values.Look(ref stripAfterHaul, "StripAfterHaul", false);
        }
        public Settings()
        {
            Initialize();
        }
    }
}
