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

            //Init();
            ShowMainWindow();
        }

        private void Init()
        {
            // 启动中，演示2s
            if (HasLoginToken())
            {
                ShowMainWindow();
            }
            else
            {
                ShowLoginWidget();
            }
        }

        private bool HasLoginToken()
        {
            bool hasLoginToken = false;
            if(PASSWORD == PassWordTb.Text.Trim())
            {
                hasLoginToken = true;
            }
            return hasLoginToken;
        }
        private void ShowLoginWidget()
        {
            // 将登录的控件，显示出来
        }
        private void ShowMainWindow()
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (HasLoginToken())
            {
                ShowMainWindow();
            }
        }
    }
}
