using Il2CppInterop.Runtime;
using System.Reflection;

namespace ModComponent.Utils
{
    public class VP_PresetUtils
    {
        public interface IVP_Presettable
        {
            public static virtual IEnumerable<VP_MemberPresetTemplate> EnumeratePresettableValues()
            {
                yield break;
            }
        }


        [Serializable]
        public class VP_Preset
        {
            public string PresetName = "New State";
            public List<VP_MemberPreset> PresetValues = new();
        }


        public struct VP_MemberPresetTemplate
        {
            public string Name;
            public Type Type;
            public string Description;

            public VP_MemberPresetTemplate(string name, Type type, string description)
            {
                Name = name;
                Type = type;
                Description = description;
            }
        }


        public class VP_MemberPreset
        {
            public VP_MemberPresetTemplate Template;
            public object? Value;
        }


        public static vp_StateInfo GenerateStateInfo(VP_Preset preset, Type targetType)
        {
            try
            {
                Il2CppSystem.Type targetTypeIl2Cpp = Il2CppType.From(targetType);
                vp_StateInfo stateInfo = new vp_StateInfo(targetType.Name, preset.PresetName);
                vp_ComponentPreset componentPreset = new vp_ComponentPreset();
                componentPreset.m_ComponentType = targetTypeIl2Cpp;
                componentPreset.m_Fields = new Il2CppSystem.Collections.Generic.List<vp_ComponentPreset.Field>();
                foreach (VP_MemberPreset memberPreset in preset.PresetValues)
                {
                    if (memberPreset == null)
                    {
                        continue;
                    }

                    Il2CppSystem.Reflection.FieldInfo targetFieldInfo = targetTypeIl2Cpp.GetField(memberPreset.Template.Name);
                    if (targetFieldInfo != null)
                    {
                        componentPreset.m_Fields.Add(new vp_ComponentPreset.Field(targetFieldInfo, memberPreset.Value as Il2CppSystem.Object));
                        continue;
                    }

                    MelonLogger.Warning($"Could not resolve field {memberPreset.Template.Name} of type {targetType.Name}");
                }
                stateInfo.Preset = componentPreset;
                return stateInfo;
            }
            catch (Exception e)
            {
                MelonLogger.Error(e);
                return null;
            }
        }
    }
}
