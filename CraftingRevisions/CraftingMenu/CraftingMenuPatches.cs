using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.AddressableAssets;
using Il2CppTLD.Gear;
using MelonLoader;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CraftingRevisions.CraftingMenu
{
	internal static class CraftingMenuPatches
	{
		[HarmonyPatch(typeof(Panel_Crafting), "OnCategoryChanged")]
		internal static class Panel_Crafting_OnCategoryChanged
		{
			private static bool Prefix(Panel_Crafting __instance, int index)
			{
				if (index < 0) return false;
				__instance.m_CurrentCategory = (Panel_Crafting.Category)index;
				__instance.ApplyFilter();
				return false;
			}
		}

		[HarmonyPatch(typeof(Panel_Crafting), "ItemPassesFilter")]
		internal static class Panel_Crafting_ItemPassesFilter
		{
			private static bool Prefix(Panel_Crafting __instance, BlueprintData bpi, ref bool __result, ref bool __runOriginal)
			{
				if (!__runOriginal)
					MelonLogger.Error("Another mod tried to disable Panel_Crafting.ItemPassesFilter");
				__result = MethodReplacements.ItemPassesFilter(__instance, bpi);
				return false;
			}
		}

		//[HarmonyPatch(typeof(Panel_Crafting), "HandleInput")]
		//internal static class Panel_Crafting_HandleInput
		//{
		//	private static bool Prefix(Panel_Crafting __instance, ref bool __runOriginal)
		//	{
		//		if (!__runOriginal)
		//			MelonLogger.Error("Another mod tried to disable Panel_Crafting.HandleInput");
		//		MethodReplacements.HandleInput(__instance);
		//		return false;
		//	}
		//}
		[HarmonyPatch(typeof(Panel_Crafting), "Update")]
		internal static class Panel_Crafting_Update_Patch
		{
			private static bool _hasInjected = false;

			private static void Prefix(Panel_Crafting __instance)
			{
				if (_hasInjected) return;

				if (__instance.m_CategoryNavigation == null) return;

				var buttonList = __instance.m_CategoryNavigation.m_NavigationButtons;
				
				if (buttonList == null || buttonList.Count < 3) return;

				foreach (var btn in buttonList)
				{
					if (btn != null && btn.name == "Button_Material")
					{
						_hasInjected = true;
						return;
					}
				}

				try 
				{
					DoInjection(__instance);
					_hasInjected = true; 
					MelonLogger.Msg("Injection Successful via Update Hook.");
				}
				catch (System.Exception ex)
				{
					// If it fails, we don't set _hasInjected so it can try again next frame
					MelonLogger.Error($"Injection failed: {ex}");
				}
			}

			private static void DoInjection(Panel_Crafting panel)
			{
				var categoryNavigation = panel.m_CategoryNavigation;
				var buttonList = categoryNavigation.m_NavigationButtons;

				UIButton toolsButton = null;
				foreach (var button in buttonList)
				{
					if (button != null && button.name.ToLower().Contains("deco"))
					{
						toolsButton = button;
						break;
					}
				}

				if (toolsButton == null) return;

				GameObject materialObj = UnityEngine.Object.Instantiate(toolsButton.gameObject, toolsButton.transform.parent);
				materialObj.name = "Button_Material";
				
				GameObject foodObj = UnityEngine.Object.Instantiate(toolsButton.gameObject, toolsButton.transform.parent);
				foodObj.name = "Button_Food";

				UIButton materialButton = materialObj.GetComponent<UIButton>();
				UIButton foodButton = foodObj.GetComponent<UIButton>();

				EventDelegate.Set(materialButton.onClick, new System.Action(() => categoryNavigation.OnNavigationChanged(materialButton)));
				EventDelegate.Set(foodButton.onClick, new System.Action(() => categoryNavigation.OnNavigationChanged(foodButton)));

				materialButton.transform.localPosition = toolsButton.transform.localPosition + new Vector3(0, -62, 0);
				foodButton.transform.localPosition = toolsButton.transform.localPosition + new Vector3(0, -124, 0);

				materialButton.SetSpriteName("ico_crafting");
				foodButton.SetSpriteName("ico_Radial_food");

				buttonList.Add(materialButton);
				buttonList.Add(foodButton);
			}
		}

		//Purely a bugfix // Well .... maybe its not needed anymore. DZ was here :D
		/*
		[HarmonyPatch(typeof(CraftingRequirementQuantitySelect), "Enable")]
		internal static class CraftingRequirementQuantitySelect_Enable
		{
			private static void Postfix(CraftingRequirementQuantitySelect __instance, BlueprintData bp)
			{
				float keroseneNeeded = bp.m_RequiredLiquid[0].m_Volume.m_Units;
				float gunpowderNeeded = bp.m_RequiredPowder[0].m_Quantity.m_Units;
				if (keroseneNeeded > 0)
				{
					LiquidType kerosene = Addressables.LoadAssetAsync<LiquidType>("LIQUID_Kerosene").WaitForCompletion();
					int maxKeroseneUnits = (int)(GameManager.GetPlayerManagerComponent().GetTotalLiters(kerosene) / keroseneNeeded);
					if (__instance.m_Maximum > maxKeroseneUnits) __instance.m_Maximum = maxKeroseneUnits;
				}
				//if (gunpowderNeeded > 0)
				//{
				//	int maxGunpowderUnits = (int)(GameManager.GetPlayerManagerComponent().GetTotalPowderWeight(GearPowderType.Gunpowder) / gunpowderNeeded);
				//	if (__instance.m_Maximum > maxGunpowderUnits) __instance.m_Maximum = maxGunpowderUnits;
				//}
			}
		}*/

	}
}
