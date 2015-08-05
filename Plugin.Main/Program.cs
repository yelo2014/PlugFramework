using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Plugin.Main
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Plugin.PlatForm.Main main = new PlatForm.Main();
            main.Initlize();
            Application.Run();
        }
    }
}
