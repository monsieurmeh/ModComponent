using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using ModComponent.Utils;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public partial class ModGunComponent : ModGenericComponent
{
    public enum ModdedGunType : int
    {
        Revolver = Il2Cpp.GunType.Revolver,
        Rifle = Il2Cpp.GunType.Rifle,
        Camera = Il2Cpp.GunType.Camera,
        Modded,
    }


    ///<summary>
    /// The type of gun item. 
    /// Vanilla options include Revolver, Rifle and Camera. 
    /// A fourth "Modded" category is added through a wrapper enum to indicate that specialty logic should be used instead of the vanilla gun categories.
    /// </summary>
    public ModdedGunType GunType = ModdedGunType.Modded;

    /// <summary>
    /// Vanilla GunType linke to ModdedGunType. Convenience operator.
    /// </summary>
    public GunType VanillaGunType => (GunType)GunType;


    /// <summary>
    /// List of gear item names representing valid ammo references for this gun. 
    /// The name can be preceeded by GEAR_ if desired, or simply left as the actual gear name. 
    /// ModComponent will fetch the gearitemdata from the gear item. 
    /// Linked prefab MUST have an AmmoItem as well or ModComponent will ignore.
    /// </summary>
    public string[] AmmoReferences = [];


    /// <summary>
    /// Addressable asset name for ammo sprite to be displayed on screen. Defaults to rifle ammo sprite.
    /// </summary>
    public string AmmoSpriteName = "RifleSpriteName"; //FIX


    public ModGunComponent(System.IntPtr intPtr) : base(intPtr) { }


    [HideFromIl2Cpp]
    internal override void InitializeComponent(JsonDict jsonDict, string className = "ModGunComponent")
    {
        base.InitializeComponent(jsonDict, className);
        JsonDictEntry entry = jsonDict.GetEntry(className);

        this.GunType = (ModdedGunType)entry.GetInt("GunType");
        this.AmmoReferences = entry.GetArray<string>("AmmoReferences");
        this.AmmoSpriteName = entry.GetString("AmmoSpriteName");


    }
}