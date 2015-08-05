using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Interface;
using ERP.UI.Helper;
using System.Windows;

namespace ERP.UI
{
    public class Module : IInstance
    {
        public void Destory()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            var uihelper = UIHelper.GetInstance();
            new MainWindow().Show();
        }
    }
}
