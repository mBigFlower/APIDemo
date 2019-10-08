using HyteraAPI.Base;
using HyteraAPI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


// TODO 关于登录，Token怎么弄？
namespace HyteraAPI
{
    /// <summary>
    /// 启动页 + 登录页
    /// </summary>
    public partial class SplashWindow : Window
    {
        const string PASSWORD = "";

        public SplashWindow()
        {
            InitializeComponent();

            Init();
            //ShowMainWindow();
        }

        private void Init()
        {
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string serverIp = ServerIpTb.Text.Trim();
            if (!string.IsNullOrEmpty(serverIp))
            {
                SaveServerIp(serverIp);
                ShowMainWindow();
            }
        }
        private void ShowMainWindow()
        {
            new MainWindow().Show();
            this.Close();
        }
        private void SaveServerIp(string serverIp)
        {
            Consts.InitUrls(serverIp);
        }
    }
}
