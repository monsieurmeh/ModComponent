using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using ModComponent.Utils;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public class ModAmmoComponent : ModBaseComponent
{

	public ModAmmoComponent(IntPtr intPtr) : base(intPtr) { }


    /// <summary>
    /// The type of gun this bullet is compatible with using modded wrapper type.
    /// </summary>
    public ModGunComponent.ModdedGunType AmmoForModdedGunType;

    /// <summary>
    /// (Il2Cpp.GunType) The type of gun this bullet is compatible with.
    /// UPDATED: READ ONLY - Assign your gun type as ModdedGunType to include option for new gun types!
    /// </summary>
    public GunType AmmoForGunType => (GunType)AmmoForModdedGunType;


    /// <summary>
    /// Sprite to be used for "loaded" ammo on HUD
    /// </summary>
    public string LoadedHudIconSpriteName;


    /// <summary>
    /// Sprite to be used for "Unloaded" ammo on HUD
    /// </summary>
    public string EmptyHudIconSpriteName;


    void Awake()
    {
        CopyFieldHandler.UpdateFieldValues(this);
    }

    [HideFromIl2Cpp]
    internal override void InitializeComponent(JsonDict jsonDict, string className = "ModAmmoComponent")
    {
        base.InitializeComponent(jsonDict, className);
		JsonDictEntry entry = jsonDict.GetEntry(className);

        AmmoForModdedGunType = entry.GetEnum<ModGunComponent.ModdedGunType>("AmmoForModdedGunType");
        LoadedHudIconSpriteName = entry.GetString("LoadedHudIconSpriteName");
        EmptyHudIconSpriteName = entry.GetString("EmptyHudIconSpriteName");
    }
}