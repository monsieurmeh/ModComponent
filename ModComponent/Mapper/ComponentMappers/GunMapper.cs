using Il2Cpp;
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

        GunItem gunItem = ComponentUtils.GetOrCreateComponent<GunItem>(modGunComponent);

        gunItem.m_GunType = modGunComponent.VanillaGunType;
        ConfigureAmmoReferences(modGunComponent, gunItem);
        gunItem.m_AmmoSpriteName = modGunComponent.AmmoSpriteName;
    }


    private static void ConfigureAmmoReferences(ModGunComponent modGunComponent, GunItem gunItem)
    {
        gunItem.m_AmmoReferences = new Il2CppSystem.Collections.Generic.List<AssetReferenceT<Il2CppTLD.Gear.GearItemData>>();
        foreach (string ammoRef in modGunComponent.AmmoReferences)
        {
            gunItem.m_AmmoReferences.Add(new AssetReferenceT<Il2CppTLD.Gear.GearItemData>(GearNameToModdedGearItemDataName(ammoRef)));
        }
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