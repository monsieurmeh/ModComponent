using Il2Cpp;
using ModComponent.API.Components;
using ModComponent.Utils;

namespace ModComponent.Mapper.ComponentMappers;

internal static class AmmoMapper
{
    internal static void Configure(ModBaseComponent modComponent)
    {
        ModAmmoComponent? modAmmoComponent = modComponent.TryCast<ModAmmoComponent>();
        if (modAmmoComponent == null)
        {
            return;
        }

        AmmoItem ammoItem = ComponentUtils.GetOrCreateComponent<AmmoItem>(modAmmoComponent);
        GearItem gearItem = ammoItem.gameObject.GetComponent<GearItem>();
        if (gearItem == null)
        {
            MelonLogger.Error("Could not get gear item from ammo item!");
            return;
        }

        gearItem.m_AmmoItem = ammoItem;
        ammoItem.m_AmmoForGunType = modAmmoComponent.AmmoForGunType;
        ammoItem.m_LoadedHudIconSpriteName = modAmmoComponent.LoadedHudIconSpriteName;
        ammoItem.m_EmptyHudIconSpriteName = modAmmoComponent.EmptyHudIconSpriteName;
        CustomAddressablesPatch.customAddressablePaths[$"ModdedGearItemData_{NameUtils.RemoveGearPrefix(gearItem.m_GearItemData.name)}"] = gearItem.m_GearItemData;
    }
}