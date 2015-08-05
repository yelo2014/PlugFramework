using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Utils;

namespace ERP.BLService.Helper
{
    internal class ConfigHelper:ConfigBase
    {
        protected override void DoSetDllName()
        {
            base.DllName = "ERP.BLService.dll.config";
        }
    }
}
