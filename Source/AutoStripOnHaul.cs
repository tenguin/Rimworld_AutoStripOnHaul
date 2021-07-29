using HarmonyLib;
using UnityEngine;
using Verse;

namespace AutoStripOnHaul
{
	public class AutoStripOnHaul : Mod
	{
		public AutoStripOnHaul(ModContentPack content) : base(content)
		{
			Harmony harmony = new Harmony(content.PackageId);
			harmony.PatchAll();
			GetSettings<Settings>();
		}

		public override string SettingsCategory()
		{
			return "AutoStripOnHaul_Title".Translate();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			Settings.DoWindowContents(inRect);
		}
	}
}
