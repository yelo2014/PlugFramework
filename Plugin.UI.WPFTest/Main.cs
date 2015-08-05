using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Framework.Interface;
using System.Windows;

namespace Plugin.UI.WPFTest
{
    public class Main:IInstance
    {
        public Main() {
            
        }

        public void Destory()
        {
        }

        public void Initlize()
        {
            
        }

        public void Run()
        {
            new MainWindow().Show();
        }
    }
}
