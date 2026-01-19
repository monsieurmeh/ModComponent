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
    public string AmmoSpriteName = "RifleSpriteName"; //WIP


    /// <summary>
    /// Addressable asset name for casing gear prefab to be dropped on the ground. Defaults to rifle casing name.
    /// </summary>
    public string CasingReference = "RifleCasingName"; //WIP


    /// <summary>
    /// Sound ID for Casing audio. Defaults to rifle audio.
    /// </summary>
    public string CasingAudio = "RifleCasingAudo"; //WIP


    /// <summary>
    /// Sound ID for dry fire audio. Defaults to rifle audio.
    /// </summary>
    public string DryFireAudio = "RifleDryFireAudio"; //WIP


    /// <summary>
    /// Sound ID for fire audio. Defaults to rifle audio.
    /// </summary>
    public string FireAudio = "RifleFireAudio"; //WIP


    /// <summary>
    /// Sound ID for projectile impact audio. Defaults to rifle audio.
    /// </summary>
    public string ImpactAudio = "RifleImpactAudio"; //WIP


    /// <summary>
    /// Sound ID for uncock audio. Defaults to rifle audio.
    /// </summary>
    public string UncockAudio = "RifleUncockAudio"; //WIP


    /// <summary>
    /// Sound ID for out-of-stamina soundbite while aiming. Defaults to rifle audio.
    /// </summary>
    public string AimingStaminaExhaustedSound = "RifleAimingStaminaExhaustedSound"; //WIP


    public ModGunComponent(System.IntPtr intPtr) : base(intPtr) { }


    [HideFromIl2Cpp]
    internal override void InitializeComponent(JsonDict jsonDict, string className = "ModGunComponent")
    {
        base.InitializeComponent(jsonDict, className);
        JsonDictEntry entry = jsonDict.GetEntry(className);

        this.GunType = (ModdedGunType)entry.GetInt("GunType");
        this.AmmoReferences = entry.GetArray<string>("AmmoReferences");
        this.AmmoSpriteName = entry.GetString("AmmoSpriteName");
        this.CasingReference = entry.GetString("CasingReference");
        this.CasingAudio = entry.GetString("CasingAudio");
        this.DryFireAudio = entry.GetString("DryFireAudio");
        this.FireAudio = entry.GetString("FireAudio");
        this.ImpactAudio = entry.GetString("ImpactAudio");
        this.UncockAudio = entry.GetString("UncockAudio");
        this.AimingStaminaExhaustedSound = entry.GetString("AimingStaminaExhaustedSound");
    }
}