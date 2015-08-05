using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.PL.Interface.BLService;
using Plugin.Framework.Interface;
using Plugin.Framework.Instance;
using Plugin.Framework.Entity;

namespace ERP.UI.Helper
{
    internal class InstanceMgr
    {
        public ISimpleBlService ISimpleBlService { get; private set; }
        internal InstanceMgr()
        {
            ISimpleBlService = InstanceLoader<IInstance>.GetInstance().GetTargetInstance("ERP_BLService") as ISimpleBlService;
        }
    }
}
