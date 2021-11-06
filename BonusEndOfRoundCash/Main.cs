using MelonLoader;
using Assets.Scripts.Simulation;

[assembly: MelonInfo(typeof(Main.Main), "Add Cash at End of Round", "1.0.0", "Roshi617")]
[assembly: MelonGame("Ninja Kiwi", "Bloons Adventure Time TD")]
namespace Main
{
	public class Main : MelonMod
	{
		// Github API URL used to check if this mod is up to date. For example:
		// public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";

		// As an alternative to a GithubReleaseURL, a direct link to a web-hosted version of the .cs file
		// that has the "MelonInfo" attribute with the version of your mod
		//public override string MelonInfoCsURL => "https://raw.githubusercontent.com/doombubbles/BTD6-Mods/main/MegaKnowledge/Main.cs";

		// The link to your normal GitHub Releases page if you're using those, or a direct link to your dll file
		// public override string LatestURL => "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest ";

		public static double cashIncrease(Simulation __instance)
		{
			Simulation.CashIncreaseReason test = Simulation.CashIncreaseReason.RoundBonus;
			double increaseCashAmount = 10000.0; //change this to your liking
			return __instance.IncreaseCash(increaseCashAmount, test);
			
		}

		public override void OnApplicationStart()
		{
			base.OnApplicationStart();

			// MelonLogger.Msg("1000 Bonus End of Round Cash Mod Loaded!");
			// MelonLogger.Msg("Created by Roshi617. Meant to be used with Bloons Adventure Time TD.");
		}

		[HarmonyLib.HarmonyPatch(typeof(Simulation), nameof(Simulation.GetEndRound))]
		public class SimulationOnRoundEndCompleted_Patch
		{
			[HarmonyLib.HarmonyPostfix]
			public static void PostFix(Simulation __instance)
			{
				cashIncrease(__instance);
            }
		}
	}
}
