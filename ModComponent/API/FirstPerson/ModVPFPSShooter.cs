using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Attributes;
using static ModComponent.Utils.VP_PresetUtils;
using System.Reflection;


namespace ModComponent.API.FirstPerson
{
    public class ModVPFPSShooter : ModFirstPersonBase, IVP_Presettable
    {
        public static IEnumerable<VP_MemberPresetTemplate> EnumeratePresettableValues()
        {
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ProjectileCount), typeof(int), "Sets the projectile count each time the trigger is pulled.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ProjectileScale), typeof(float), "Sets the scale of each projectile shot.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ProjectileSpread), typeof(float), "Sets the potential projectile spread in degrees, where the total included angle of the generated cone is twice this value.\nExample: ProjectileSpread = 1f ---> 2 degree projectile spread.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MotionPositionReset), typeof(float), "Reset speed for weapon position motion.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MotionRotationReset), typeof(float), "Reset speed for weapon rotation motion.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MotionPositionPause), typeof(float), "Pause multiplier for weapon position motion.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MotionRotationPause), typeof(float), "Pause multiplier for weapon rotation motion.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MotionDryFireRecoil), typeof(float), "Recoil strength when firing with no ammo.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MuzzleFlashFadeSpeed), typeof(float), "Speed at which the muzzle flash fades.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MuzzleFlashPosition), typeof(Vector3), "Local position of the muzzle flash.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MuzzleFlashScale), typeof(Vector3), "Scale of the muzzle flash.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ShellScale), typeof(float), "Sets the scale of each shell dropped.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ShellEjectVelocity), typeof(float), "Velocity at which shells are ejected.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ShellEjectDelay), typeof(float), "Delay before shells are ejected after firing.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ShellEjectSpin), typeof(float), "Spin applied to ejected shells.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ShellEjectDirection), typeof(Vector3), "Direction in which shells are ejected.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.ShellEjectPosition), typeof(Vector3), "Local position from which shells are ejected.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.JamConditionThreshold), typeof(float), "Threshold that determines when a jam can occur.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.JamMinimumChance), typeof(float), "Minimum chance for the weapon to jam.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.JamMaximumChance), typeof(float), "Maximum chance for the weapon to jam.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MotionPositionRecoil), typeof(Vector3), "Recoil offset for weapon position.");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSShooter.MotionRotationRecoil), typeof(Vector3), "Recoil offset for weapon rotation.");
        }


        public ModVPFPSShooter(System.IntPtr intPtr) : base(intPtr) { }

        public VP_Preset[] States = [];

        public string? MuzzleFlashPrefabName { get; set; } = null;
        public string? ProjectilePrefabName { get; set; } = null;
        public string? ShellPrefabName { get; set; } = null;


        [HideFromIl2Cpp]
        internal override void InitializeComponent(JsonDict jsonDict, string className = "ModVPFPSShooter")
        {
            base.InitializeComponent(jsonDict, className);
            JsonDictEntry entry = jsonDict.GetEntry(className);

            this.States = entry.GetArray<VP_Preset>("States");
            this.MuzzleFlashPrefabName = entry.GetString("MuzzleFlashPrefabName");
            this.ProjectilePrefabName = entry.GetString("ProjectilePrefabName");
            this.ShellPrefabName = entry.GetString("ShellPrefabName");
        }
    }
}
