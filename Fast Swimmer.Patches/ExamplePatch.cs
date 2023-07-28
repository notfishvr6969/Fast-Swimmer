using System;
using GorillaLocomotion;
using HarmonyLib;

namespace FastSwimmer.Patches;

[HarmonyPatch(typeof(Player))]
[HarmonyPatch(/*Could not decode attribute arguments.*/)]
internal class ExamplePatch
{
	private static void Postfix(Player __instance)
	{
		Console.WriteLine(__instance.maxJumpSpeed);
	}
}
