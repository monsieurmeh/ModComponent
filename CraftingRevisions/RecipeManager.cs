using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Cooking;
using Il2CppTLD.Gear;
using System.Text.RegularExpressions;
using UnityEngine;

namespace CraftingRevisions
{
	[HarmonyPatch]
	public static class RecipeManager
	{
		private static HashSet<string> jsonUserRecipes = new();
		private static List<RecipeData> userRecipes = new();

		public static void AddRecipeFromJson(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new ArgumentException("Recipe text contains no information", nameof(text));
			}

			// add the blueprint to the HasSet
			jsonUserRecipes.Add(text);
		}

		[HarmonyPostfix]
		[HarmonyPatch(typeof(RecipeBook), nameof(RecipeBook.Start))]
		private static void RecipeBook_Start(RecipeBook __instance)
		{

			foreach (string jsonUserRecipe in jsonUserRecipes)
			{
				ModUserRecipe recipe = ModUserRecipe.ParseFromJson(jsonUserRecipe);

				try
				{
					bool isValid = recipe.Validate();

				if (isValid)
				{
					RecipeData newRecipe = recipe.GetRecipeData();

					// store the processed recipe
					__instance.AllRecipes.Add(newRecipe);
					Logger.Log("Added Recipe " + recipe.RecipeName);
				}
				}
				catch (Exception e)
				{
					Logger.LogError("Recipe Exception" + recipe.RecipeName + "\n" + e);
				}
			}

		}

		//Special thanks: Romain
		// [HarmonyPostfix]
		// [HarmonyPatch(typeof(CookableListItem), nameof(CookableListItem.SetCookable))]
		// private static void CookableListItem_SetCookable(CookableListItem __instance, CookableItem cookableItem, CookingPotItem cookingPot)
		// {
		// 	if (cookableItem.m_GearItem.GetComponent<Cookable>().m_CookedPrefab != null)
		// 	{
		// 		__instance.m_ItemIcon.mainTexture = cookableItem.m_GearItem.GetComponent<Cookable>().m_CookedPrefab.GetInventoryIconTexture();
		// 		__instance.gameObject.GetComponentInChildren<UITexture>().enabled = true;
		// 	}
		// }

		[HarmonyPatch(typeof(Panel_Cooking), "Update")]
		internal static class Panel_Cooking_Update_Patch
		{
			private static void Postfix(Panel_Cooking __instance)
			{
				if (__instance == null || !__instance.IsEnabled() || __instance.m_ActiveCookingDetails == null || !__instance.m_ActiveCookingDetails.activeInHierarchy)
				{
					return;
				}

				CookableItem selectedItem = __instance.GetSelectedCookableItem();
				if (selectedItem.m_GearItem == null) return;

				var cookableComp = selectedItem.m_GearItem.GetComponent<Cookable>();
				if (cookableComp == null || cookableComp.m_CookedPrefab == null) return;

				var cookedTexture = cookableComp.m_CookedPrefab.GetInventoryIconTexture();
				if (cookedTexture == null) return;

				if (__instance.m_Texture_CookedItem != null)
				{
					if (__instance.m_Texture_CookedItem.mainTexture != cookedTexture)
					{
						__instance.m_Texture_CookedItem.mainTexture = cookedTexture;
						__instance.m_Texture_CookedItem.enabled = true;
					}
				}
			}
		}
	}
}