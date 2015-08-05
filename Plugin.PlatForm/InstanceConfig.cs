using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Utils;

namespace Plugin.PlatForm
{
    internal class InstanceConfig : ConfigBase
    {
        protected override void DoSetDllName()
        {
            base.DllName = "Plugin.PlatForm.dll.Config";
        }
    }
}
