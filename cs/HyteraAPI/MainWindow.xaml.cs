using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using HyteraAPI.APIAdd;
using HyteraAPI.APIDetails;
using HyteraAPI.Windows;
using JumpKick.HttpLib;
using Newtonsoft.Json;
using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HyteraAPI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            Messenger.Default.Register<string>(this, "ShowSnackBar", ShowSnackBar);
            this.Unloaded += (sender, e) =>
            {
                Messenger.Default.Unregister(this);
            };
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = MainMenuListBox.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    // Setting

                    break;
                case 1:
                    // about us 
                    //ShowSnackBar("About us is building now .");
                    new AboutUsWindow().Show();
                    break;
            }
        }

        /////// TODO 消息通知, 以后可以单独拎出来一个控件,放到MainWindow的Grid下,专门通知消息
        /////// 或者在各自的布局文件里面加?
        private void NotifyToSnackBar(bool isSuccess, string message)
        {
            ShowSnackBar(message);
        }

        private void ShowSnackBar(string message)
        {
            this.Dispatcher.Invoke(() => {
                //use the message queue to send a message.
                var messageQueue = SnackbarThree.MessageQueue;
                //the message queue can be called from any thread
                Task.Factory.StartNew(() => messageQueue.Enqueue(message));
            });
            
        }

    }
}
