using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Plugin.Framework.Interface;
using Plugin.Framework.Utils;

namespace Plugin.UI.WPFTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, ILog
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoggerMgr.GetInstance().Regist(this);
        }

        public void Notify(Framework.Entity.Logger logger)
        {
            this.Dispatcher.BeginInvoke(new Action(() => {
                listBox1.Items.Add(string.Format("{0}:{1}", logger.LoggerType, logger.Content));
            }));
        }
    }
}
