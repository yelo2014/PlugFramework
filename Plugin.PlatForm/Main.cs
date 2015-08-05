using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.PlatForm.Core;

namespace Plugin.PlatForm
{
    public class Main
    {
        InstanceMgr _instanceManager;
        public void Initlize() {
            InitInstance();
        }

        void InitInstance() {
            _instanceManager = new InstanceMgr();
            _instanceManager.InitInstance();
            _instanceManager.RunInstance();
        }
    }
}
