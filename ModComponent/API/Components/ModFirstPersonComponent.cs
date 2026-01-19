using Il2Cpp;
using Il2CppInterop.Runtime.Attributes;
using MelonLoader.TinyJSON;
using ModComponent.Utils;

namespace ModComponent.API.Components;

[MelonLoader.RegisterTypeInIl2Cpp(false)]
public partial class ModFirstPersonComponent : ModGenericComponent
{
    //TODO: Write editor script for a gui to handle these valid/invalid transitions - they are represented in a pretty condensed but complex manner at runtime.

    /// <summary>
    /// Name of the first person object this points at. Recommendation: unprefixed gear name (i.e. for GEAR_Shotgun, this would be Shotgun)
    /// </summary>
    public string FirstPersonObjectName;

    /// <summary>
    /// Array of State Flags that represent valid transitions from one state to another.
    /// Length of array is equal to number of available states.
    /// Setting a flag in an array entry indicates that transitioning from that index's state to the flagged state is VALID
    /// Example: if ValidTransitions[(int)State.Aiming].IsSet(State.FromAiming), then "Transitioning from state 'Aiming' to state 'FromAiming' is VALID
    /// </summary>
    public PlayerAnimation.StateFlags[] ValidTransitions = new PlayerAnimation.StateFlags[PlayerAnimation.NumStates];


    /// <summary>
    /// Array of State Flags that represent invalid transitions from one state to another.
    /// WARNING: NOT YET SURE IF THE GAME ACTUALLY USES THIS. WIP!
    /// Length of array is equal to number of available states.
    /// Setting a flag in an array entry indicates that transitioning from that index's state to the flagged state is INVALID
    /// Example: if !ValidTransitions[(int)State.ToAiming].IsSet(State.FromAiming), then "Transitioning from state 'Aiming' to state 'FromAiming' is INVALID.
    /// </summary>
    public PlayerAnimation.StateFlags[] InvalidTransitions = new PlayerAnimation.StateFlags[PlayerAnimation.NumStates];


    /// <summary>
    /// Sound ID for wield audio.
    /// </summary>
    public string WieldAudio = "RifleWieldAudio"; //WIP


    /// <summary>
    /// Sound ID for wield audio.
    /// </summary>
    public string UnwieldAudio = "RifleUnwieldAudio"; //WIP


    public ModFirstPersonComponent(System.IntPtr intPtr) : base(intPtr) { }


    [HideFromIl2Cpp]
    internal override void InitializeComponent(JsonDict jsonDict, string className = "ModGunComponent")
    {
        base.InitializeComponent(jsonDict, className);
        JsonDictEntry entry = jsonDict.GetEntry(className);

        this.FirstPersonObjectName = entry.GetString("FirstPersonObjectName");
        this.WieldAudio = entry.GetString("WieldAudio");
        this.UnwieldAudio = entry.GetString("UnwieldAudio");
        uint[] rawValidTransitionFlags = entry.GetArray<uint>("ValidTransitionFlags");
        uint[] rawInvalidTransitionFlags = entry.GetArray<uint>("InvalidTransitionFlags");
        for (int i = 0, iMax = (int)PlayerAnimation.NumStates; i < iMax; i++)
        {
            ValidTransitions[i] = (PlayerAnimation.StateFlags)rawValidTransitionFlags[i];
            InvalidTransitions[i] = (PlayerAnimation.StateFlags)rawInvalidTransitionFlags[i];
        }

    }
}