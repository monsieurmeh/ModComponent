using Il2Cpp;
using Il2CppTLD.Gear;
using ModComponent.API.Components;
using ModComponent.Utils;
using UnityEngine.AddressableAssets;

namespace ModComponent.Mapper.ComponentMappers;

internal static class FirstPersonMapper
{
    internal static void Configure(ModBaseComponent modComponent)
    {
        ModFirstPersonComponent? modFirstPersonComponent = modComponent.TryCast<ModFirstPersonComponent>();
        if (modFirstPersonComponent == null)
        {
            return;
        }

        FirstPersonItem firstPersonItem = ComponentUtils.GetOrCreateComponent<FirstPersonItem>(modFirstPersonComponent);

        firstPersonItem.m_PlayerStateTransitions = new PlayerStateTransitions();
        firstPersonItem.m_PlayerStateTransitions.m_InvalidTransitions = new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<PlayerAnimation.StateFlags>(PlayerAnimation.NumStates);
        firstPersonItem.m_PlayerStateTransitions.m_ValidTransitions = new Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<PlayerAnimation.StateFlags>(PlayerAnimation.NumStates);
        for (int i = 0, iMax = (int)PlayerAnimation.NumStates; i < iMax; i++)
        {
            firstPersonItem.m_PlayerStateTransitions.m_InvalidTransitions[i] = modFirstPersonComponent.ValidTransitions[i];
            firstPersonItem.m_PlayerStateTransitions.m_ValidTransitions[i] = modFirstPersonComponent.InvalidTransitions[i];
        }
        firstPersonItem.m_WieldAudioEvent = ModUtils.MakeAudioEvent(modFirstPersonComponent.WieldAudio);
        firstPersonItem.m_UnwieldAudioEvent = ModUtils.MakeAudioEvent(modFirstPersonComponent.UnwieldAudio);
    }
}