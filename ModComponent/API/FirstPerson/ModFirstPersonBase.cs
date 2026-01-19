using Il2CppInterop.Runtime.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModComponent.API.Components.ModBaseComponent;

namespace ModComponent.API.FirstPerson
{
    [MelonLoader.RegisterTypeInIl2Cpp(false)]
    public class ModFirstPersonBase : MonoBehaviour
    {
        public ModFirstPersonBase(IntPtr intPtr) : base(intPtr) { }


        void Awake()
        {
            CopyFieldHandler.UpdateFieldValues(this);
        }


        [HideFromIl2Cpp]
        internal virtual void InitializeComponent(JsonDict jsonDict, string inheritanceName) => Validate();


        internal virtual void Validate() { }
       
    }
}
