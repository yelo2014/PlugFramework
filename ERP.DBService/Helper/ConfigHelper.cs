using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Utils;

namespace ERP.DBService.Helper
{
    public class ConfigHelper : ConfigBase
    {
        protected override void DoSetDllName()
        {
            base.DllName = "ERP.DBService.dll.Config";
        }
    }
}
