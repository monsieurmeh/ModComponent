using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Attributes;
using static ModComponent.Utils.VP_PresetUtils;
using System.Reflection;


namespace ModComponent.API.FirstPerson
{
    public class ModVPFPSWeapon : ModFirstPersonBase, IVP_Presettable
    {
        public static IEnumerable<VP_MemberPresetTemplate> EnumeratePresettableValues()
        {
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RenderingZoomDamping), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RenderingFieldOfView), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RenderingClippingPlanes), typeof(Vector2), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionOffset), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionSpringStiffness), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionSpringDamping), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionKneeling), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionFallRetract), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionFallYCancel), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionPivotSpringStiffness), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionPivotSpringDamping), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionSpring2Stiffness), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionSpring2Damping), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionWalkSlide), typeof(Vector2), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionPivot), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionInputVelocityScale), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionMaxInputVelocity), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationOffset), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationSpringStiffness), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationSpringDamping), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationSpring2Stiffness), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationSpring2Damping), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationLookSway), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationStrafeSway), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationFallSway), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationSlopeSway), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationInputVelocityScale), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationMaxInputVelocity), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.ShakeSpeed), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.ShakeAmplitude), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.BobRate), typeof(Vector4), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.BobAmplitude), typeof(Vector4), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.BobInputVelocityScale), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.BobMaxInputVelocity), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.SwayStartFatigue), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.SwayMaxFatigue), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.SwayMotionSpeed), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.SwayLimits), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.SwayCrouchScalar), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.PositionExitOffset), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.RotationExitOffset), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_UseFirstPersonHands), typeof(bool), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_AimingMinYawStepDegrees), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_AimingMaxYawStepDegrees), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_AimingMinYawDegrees), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_AimingMaxYawDegrees), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_BreathingCycleMinPitchDegrees), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_BreathingCycleMaxPitchDegrees), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_KneelingBonusPitch), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_KneelingBonusYaw), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_ColdRandomShakingOscillationSpeed), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_ColrRandomShakingNoiseSpeed), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_ColdTeethChatterRate), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_ColdShakingAngleLimits), typeof(Vector3), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_ColdShakeAngle), typeof(float), "");
            yield return new VP_MemberPresetTemplate(nameof(vp_FPSWeapon.m_StaminaWeaponDropDegrees), typeof(float), "");
        }


        public ModVPFPSWeapon(System.IntPtr intPtr) : base(intPtr) { }

        public VP_Preset[] States = [];

        public string? FirstPersonWeaponShoulderPrefabName;

        public string? FirstPersonWeaponRightHandPrefaName;

        public string? FirstPersonWeaponLeftHandPrefaName;


        [HideFromIl2Cpp]
        internal override void InitializeComponent(JsonDict jsonDict, string className = "ModVPFPSShooter")
        {
            base.InitializeComponent(jsonDict, className);
            JsonDictEntry entry = jsonDict.GetEntry(className);

            this.States = entry.GetArray<VP_Preset>("States"); 
            this.FirstPersonWeaponShoulderPrefabName = entry.GetString("FirstPersonWeaponShoulderPrefabName");
            this.FirstPersonWeaponRightHandPrefaName = entry.GetString("FirstPersonWeaponRightHandPrefaName");
            this.FirstPersonWeaponLeftHandPrefaName = entry.GetString("FirstPersonWeaponLeftHandPrefaName");
        }
    }
}
