using Il2CppInterop.Runtime.Attributes;


namespace ModComponent.API.FirstPerson
{
    public class ModFirstPersonWeapon : ModFirstPersonBase
    {
        /// <summary>
        /// GameObject containing the renderable rig for first person usage.
        /// </summary>
        public GameObject Renderable;


        /// <summary>
        /// Animator for first person usage.
        /// </summary>
        public Animator Animator;


        /// <summary>
        /// Gameobject representing the front sight of the weapon, if applicable.
        /// </summary>
        public GameObject FrontSight;


        /// <summary>
        /// Gameobject representing the front sight of the weapon, if applicable.
        /// </summary>
        public GameObject RearSight;


        /// <summary>
        /// Gameobject representing the front sight of the weapon, if applicable.
        /// WARNING: If Front and Rear sights are not both configured, the z-axis of this transform will be used as the base projectile vector!
        /// </summary>
        public GameObject BulletEmissionPoint;


        public ModFirstPersonWeapon(System.IntPtr intPtr) : base(intPtr) { }



        [HideFromIl2Cpp]
        internal override void InitializeComponent(JsonDict jsonDict, string className = "ModFirstPersonWeapon")
        {
            base.InitializeComponent(jsonDict, className);
            JsonDictEntry entry = jsonDict.GetEntry(className);

            Renderable = ModUtils.GetInChildren(this.gameObject, entry.GetString("Renderable"));
            FrontSight = ModUtils.GetInChildren(this.gameObject, entry.GetString("FrontSight"));
            RearSight = ModUtils.GetInChildren(this.gameObject, entry.GetString("RearSight"));
            BulletEmissionPoint = ModUtils.GetInChildren(this.gameObject, entry.GetString("BulletEmissionPoint"));
            Animator = this.gameObject.GetComponentInChildren<Animator>();
        }


        internal override void Validate()
        {
            if (!Renderable) MelonLogger.Warning("No Renderable found on ModFirstPersonWeapon!");
            if (!FrontSight) MelonLogger.Warning("No FrontSight found on ModFirstPersonWeapon!");
            if (!RearSight) MelonLogger.Warning("No RearSight found on ModFirstPersonWeapon!");
            if (!BulletEmissionPoint) MelonLogger.Warning("No BulletEmissionPoint found on ModFirstPersonWeapon!");
            if (!Animator) MelonLogger.Warning("No Animator found on ModFirstPersonWeapon!");
        }
    }
}
