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

        private static int smeltableApparelToDrop;
        private static int nonsmeltableApparelToDrop;
        private static bool forbidTaintedSmeltables;
        private static bool forbidTaintedNonSmeltables;
        private static void Initialize()
        {
            smeltableApparelToDrop = DropAll;
            nonsmeltableApparelToDrop = DropAll;
            forbidTaintedSmeltables = false;
            forbidTaintedNonSmeltables = true;
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref smeltableApparelToDrop, "SmeltableApparelToDrop", DropAll);
            Scribe_Values.Look(ref nonsmeltableApparelToDrop, "NonsmeltableApparelToDrop", DropAll);
            Scribe_Values.Look(ref forbidTaintedSmeltables, "ForbidTaintedSmeltables", false);
            Scribe_Values.Look(ref forbidTaintedNonSmeltables, "ForbidTaintedNonSmeltables", true);
        }
        public Settings()
        {
            Initialize();
        }
    }
}
