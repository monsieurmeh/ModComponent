global using Newtonsoft.Json;
global using ModComponent.Utils;
global using UnityEngine;
global using HarmonyLib;
global using Il2Cpp;
global using MelonLoader;
global using ModComponent.API.Components;


namespace ModComponent;

internal class Implementation : MelonMod
{

	internal static bool runDeps = true;
	internal static bool isReady = false;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	internal static Implementation instance;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	public Implementation()
	{
		instance = this;
	}

	public override void OnInitializeMelon()
	{
		Logger.LogDebug("Debug Compilation");
		Logger.LogNotDebug("Release Compilation");

		GearSpawner.Settings.instance.AddToModSettings("Gear Spawn Settings");
		CraftingRevisions.Settings.instance.AddToModSettings("Crafting Revisions");
		Settings.instance.AddToModSettings("ModComponent");

		AssetBundleProcessor.Initialize();
	}

	[HarmonyPatch(typeof(GameManager), nameof(GameManager.Awake))]
	internal static class MC_Initialize
	{
		internal static void Prefix()
		{
			if (runDeps)
			{
				// run the dependency checks (once)
				try
				{
					DependencyChecker.RunChecks();
				} catch (Exception e)
				{
					Logger.LogWarning($"DependencyChecker Failed:\n{e}");
				}
				runDeps = false;
			}
		}
	}

	// change to gamemanager awake or sceneload MainMenu ?
	[HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.Initialize))]
	internal static class MC_MapPrefabs
	{
		internal static void Prefix()
		{
			Logger.LogNotDebug("Panel_Crafting_Initialize");
			if (isReady == false)
			{
				AssetBundleProcessor.MapPrefabs();
				isReady = true;
			}
		}
	}


	[HarmonyPatch(typeof(GearItem), nameof(GearItem.SetDamageBlendValue))]
	internal static class gisetdmg
	{
		private static readonly int DamageTextureID = Shader.PropertyToID("_dmg_texture");

		internal static void Prefix(GearItem __instance, float blendVal, ref bool __runOriginal)
		{
			ModBaseComponent modComponent = ModComponent.Utils.ComponentUtils.GetModComponent(__instance);
			if (modComponent != null && !HasUsableDamageTexture(__instance))
			{
				__runOriginal = false;
			}
		}

		private static bool HasUsableDamageTexture(GearItem gearItem)
		{
			if (gearItem.m_MeshRenderers == null || gearItem.m_SkinnedMeshRenderers == null)
			{
				return false;
			}

			bool foundDamageTexture = false;
			foreach (Renderer renderer in GetRenderers(gearItem))
			{
				if (renderer == null)
				{
					continue;
				}
				foreach (Material material in renderer.sharedMaterials)
				{
					if (material == null || !material.HasProperty(DamageTextureID))
					{
						continue;
					}
					if (material.GetTexture(DamageTextureID) == null)
					{
						return false;
					}
					foundDamageTexture = true;
				}
			}
			return foundDamageTexture;
		}

		private static IEnumerable<Renderer> GetRenderers(GearItem gearItem)
		{
			foreach (MeshRenderer renderer in gearItem.m_MeshRenderers)
			{
				yield return renderer;
			}
			foreach (SkinnedMeshRenderer renderer in gearItem.m_SkinnedMeshRenderers)
			{
				yield return renderer;
			}
		}
	}


	public override void OnApplicationQuit()
	{
		AssetBundleProcessor.CleanupTempFolder();
	}

}
