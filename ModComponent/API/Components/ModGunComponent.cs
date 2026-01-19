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
    /// Addressable asset name for ammo sprite to be displayed on screen. 
    /// </summary>
    public string AmmoSpriteName = "RifleSpriteName"; //WIP


    /// <summary>
    /// Addressable asset name for casing gear prefab to be dropped on the ground. 
    /// </summary>
    public string CasingReference = "RifleCasingName"; //WIP


    /// <summary>
    /// Sound ID for Casing audio. 
    /// </summary>
    public string CasingAudio = "RifleCasingAudo"; //WIP


    /// <summary>
    /// Sound ID for dry fire audio.
    /// </summary>
    public string DryFireAudio = "RifleDryFireAudio"; //WIP


    /// <summary>
    /// Sound ID for fire audio.
    /// </summary>
    public string FireAudio = "RifleFireAudio"; //WIP


    /// <summary>
    /// Sound ID for projectile impact audio.
    /// </summary>
    public string ImpactAudio = "RifleImpactAudio"; //WIP


    /// <summary>
    /// Sound ID for uncock audio.
    /// </summary>
    public string UncockAudio = "RifleUncockAudio"; //WIP


    /// <summary>
    /// Sound ID for out-of-stamina soundbite while aiming.
    /// </summary>
    public string AimingStaminaExhaustedSound = "RifleAimingStaminaExhaustedSound"; //WIP


    /// <summary>
    /// Controls how many rounds can be loaded at once.
    /// </summary>
    public int ClipSize = 12;


    /// <summary>
    /// (TESTING NEEDED) Number of rounds to speed-load when possible.
    /// </summary>
    public int RoundsToReloadPerClip = 6;


    /// <summary>
    /// Default damage per shot. 
    /// </summary>
    public int DamageHP = 100;


    /// <summary>
    /// Default maximum range of weapon.
    /// </summary>
    public int AccuracyRange = 65;


    /// <summary>
    /// (TESTING NEEDED) Cooldown between attempts to reload the gun.
    /// </summary>
    public float ReloadCooldownSeconds = 2f;


    /// <summary>
    /// Minimum distance needed for aim assist to kick in
    /// </summary>
    public int MinDistanceForAimAssist = 30;


    /// <summary>
    /// Delay after firing before muzzle flash occurs in seconds.
    /// </summary>
    public float MuzzleFlash_FlashDelay = 0.1f;


    /// <summary>
    /// Delay after firing before muzzle smoke appears in seconds.
    /// </summary>
    public float MuzzleFlash_SmokeDelay = 0.15f;


    /// <summary>
    /// (TESTING NEEDED) UNKNOWN
    /// </summary>
    public float SwayValueMaxFatigue = 0.75f;


    /// <summary>
    /// (TESTING NEEDED) UNKNOWN
    /// </summary>
    public float SwayIncreasePerSecond = 0.1f;


    /// <summary>
    /// (TESTING NEEDED) UNKNOWN
    /// </summary>
    public float SwayDecreasePerSecond = 0.15f;


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
        this.ClipSize = entry.GetInt("ClipSize");
        this.RoundsToReloadPerClip = entry.GetInt("RoundsToReloadPerClip");
        this.DamageHP = entry.GetInt("DamageHP");
        this.AccuracyRange = entry.GetInt("AccuracyRange");
        this.ReloadCooldownSeconds = entry.GetFloat("ReloadCooldownSeconds");
        this.MinDistanceForAimAssist = entry.GetInt("MinDistanceForAimAssist");
        this.MuzzleFlash_FlashDelay = entry.GetFloat("MuzzleFlash_FlashDelay");
        this.MuzzleFlash_SmokeDelay = entry.GetFloat("MuzzleFlash_SmokeDelay");
        this.SwayValueMaxFatigue = entry.GetFloat("SwayValueMaxFatigue");
        this.SwayIncreasePerSecond = entry.GetFloat("SwayIncreasePerSecond");
        this.SwayDecreasePerSecond = entry.GetFloat("SwayDecreasePerSecond");
    }
}