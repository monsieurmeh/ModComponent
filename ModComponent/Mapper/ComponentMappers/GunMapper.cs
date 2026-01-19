using Il2Cpp;
using Il2CppTLD.Gear;
using ModComponent.API.Components;
using ModComponent.Utils;
using UnityEngine.AddressableAssets;

namespace ModComponent.Mapper.ComponentMappers;

internal static class GunMapper
{
    internal static void Configure(ModBaseComponent modComponent)
    {
        ModGunComponent? modGunComponent = modComponent.TryCast<ModGunComponent>();
        if (modGunComponent == null)
        {
            return;
        }

        GearItem? gearItem = modGunComponent.gameObject.GetComponent<GearItem>();
        if (gearItem == null)
        {
            return;
        }

        GunItem gunItem = ComponentUtils.GetOrCreateComponent<GunItem>(modGunComponent);
        gunItem.m_GearItem = gearItem;
        gearItem.m_GunItem = gunItem;

        if (!ConfigureCasingReference(modGunComponent, gunItem)) return;
        ConfigureAmmoReferences(modGunComponent, gunItem);
        ConfigureAudioReferences(modGunComponent, gunItem);
        ConfigureSpriteReferences(modGunComponent, gunItem);
        ConfigureDetails(modGunComponent, gunItem);
    }

    private static bool ConfigureCasingReference(ModGunComponent modGunComponent, GunItem gunItem)
    {
        try
        {
            GameObject casingPrefab = Addressables.LoadAssetAsync<GameObject>(modGunComponent.CasingReference).WaitForCompletion();
            if (casingPrefab == null)
            {
                MelonLogger.Error($"Could not configure GunItem.m_CasingData during GunMapper.Configure: No asset found with name {modGunComponent.CasingReference}");
                return false;
            }

            GearItem casingGearItem = casingPrefab.GetComponent<GearItem>();
            if (casingGearItem == null)
            {
                MelonLogger.Error($"Could not configure GunItem.m_CasingData during GunMapper.Configure: Could not get GearItem from prefab fetched by asset name {modGunComponent.CasingReference}");
                return false;
            }

            GearItemData casingGearItemData = casingGearItem.m_GearItemData;
            if (casingGearItemData == null)
            {
                MelonLogger.Error($"Could not configure GunItem.m_CasingData during GunMapper.Configure: Could not get GearItemData from GearItem attached to prefab fetched by asset name {modGunComponent.CasingReference}");
                return false;
            }

            gunItem.m_CasingData = casingGearItemData;
            return true;
        }
        catch (Exception e)
        {
            MelonLogger.Error($"Could not configure GunItem.m_CasingData during GunMapper.Configure: {e}");
            return false;
        }
    }


    private static void ConfigureAmmoReferences(ModGunComponent modGunComponent, GunItem gunItem)
    {
        gunItem.m_AmmoReferences = new Il2CppSystem.Collections.Generic.List<AssetReferenceT<Il2CppTLD.Gear.GearItemData>>();
        foreach (string ammoRef in modGunComponent.AmmoReferences)
        {
            gunItem.m_AmmoReferences.Add(new AssetReferenceT<Il2CppTLD.Gear.GearItemData>(GearNameToModdedGearItemDataName(ammoRef)));
        }
    }


    private static void ConfigureAudioReferences(ModGunComponent modGunComponent, GunItem gunItem)
    {
        gunItem.m_CasingAudio = modGunComponent.CasingAudio;
        gunItem.m_DryFireAudio = modGunComponent.DryFireAudio;
        gunItem.m_FireAudio = ModUtils.MakeAudioEvent(modGunComponent.FireAudio);
        gunItem.m_ImpactAudio = modGunComponent.ImpactAudio;
        gunItem.m_UncockAudio = modGunComponent.UncockAudio;
        gunItem.m_AimingStaminaExhaustedSound = modGunComponent.AimingStaminaExhaustedSound;
    }


    private static void ConfigureSpriteReferences(ModGunComponent modGunComponent, GunItem gunItem)
    {
        gunItem.m_AmmoSpriteName = modGunComponent.AmmoSpriteName;
    }


    private static void ConfigureDetails(ModGunComponent modGunComponent, GunItem gunItem)
    {
        gunItem.m_ClipSize = modGunComponent.ClipSize;
        gunItem.m_RoundsToReloadPerClip = modGunComponent.RoundsToReloadPerClip;
        gunItem.m_DamageHP = modGunComponent.DamageHP;
        gunItem.m_AccuracyRange = modGunComponent.AccuracyRange;
        gunItem.m_MinDistanceForAimAssist = modGunComponent.MinDistanceForAimAssist;
        gunItem.m_MuzzleFlash_FlashDelay = modGunComponent.MuzzleFlash_FlashDelay;
        gunItem.m_MuzzleFlash_SmokeDelay = modGunComponent.MuzzleFlash_SmokeDelay;
        gunItem.m_SwayValueMaxFatigue = modGunComponent.SwayValueMaxFatigue;
        gunItem.m_SwayIncreasePerSecond = modGunComponent.SwayIncreasePerSecond;
        gunItem.m_SwayDecreasePerSecond = modGunComponent.SwayDecreasePerSecond;
    }


    /// <summary>
    /// WIP: This should be a universal handler somwhere in utils instead, but im currently only using it here - ill need to use it in ammo as well.
    /// Ensures that a valid gear item name or prefab name is turned into a valid modded gear item data ref
    /// </summary>
    /// <param name="ammoRef"></param>
    /// <returns></returns>
    private static string GearNameToModdedGearItemDataName(string ammoRef)
    { 
        if (ammoRef.StartsWith("GEAR_"))
        {
            ammoRef = ammoRef.Substring(5);
        }
        return $"ModdedGearItemData_{ammoRef}";
    }
}