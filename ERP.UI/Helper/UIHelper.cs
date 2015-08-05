using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Utils;

namespace ERP.UI.Helper
{
    internal class UIHelper
    {
        static object lck4Instance = new object();
        static UIHelper _Instance;
        internal static UIHelper GetInstance()
        {
            lock (lck4Instance)
            {
                if (null == _Instance)
                {
                    _Instance = new UIHelper();
                }
                return _Instance;
            }
        }

        internal ConfigBase ConfigHelper { get; private set; }
        internal InstanceMgr InstanceMgr { get; private set; }
        UIHelper()
        {
            ConfigHelper = new ConfigHelper();
            InstanceMgr = new InstanceMgr();
        }
    }
}
