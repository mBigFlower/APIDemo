using GalaSoft.MvvmLight.Messaging;
using HyteraAPI.Utils;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HyteraAPI.APIAdd
{
    /// <summary>
    /// 添加新的API,翻牌子界面
    /// </summary>
    public partial class AddNewApi : UserControl
    {
        private AddNewApiViewModel mAddViewModel;
        // 是否是背面的卡片在显示
        private bool isBackCardShow;

        public AddNewApi()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            mAddViewModel = new AddNewApiViewModel();
            this.DataContext = mAddViewModel;

            Messenger.Default.Register<object>(this, "ShowTransferDialog", message => Show());
            Messenger.Default.Register<object>(this, "AddNewApiSuccess", message => Hidden());
        }

        private void AddNewModel_NotifyAddNewApi(bool isSuccess, string message)
        {
            if(isSuccess)
            {
                Hidden();
            }
        }

        public void Show()
        {
            rootControl.Visibility = Visibility.Visible;

            mAddViewModel.TransferData();
        }
        public void Hidden()
        {
            // clear
            mAddViewModel.Clear();
            // hidden
            rootControl.Visibility = Visibility.Collapsed;
            // 翻转到正面
            if(isBackCardShow)
                Flipper.FlipCommand.Execute(null, null);
        }

        private void Flipper_OnIsFlippedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            isBackCardShow = e.NewValue;
        }

        private void HiddenBt_Click(object sender, RoutedEventArgs e)
        {
            Hidden();
        }


        private void ReloadXmlBt_Click(object sender, RoutedEventArgs e)
        {
            mAddViewModel.TransferData();
        }

        private void AddNewApiBt_Click(object sender, RoutedEventArgs e)
        {
            mAddViewModel.AddNewApi();
        }

        private void CheckBt_Click(object sender, RoutedEventArgs e)
        {
            mAddViewModel.CheckDetail();
            Hidden();
        }
    }
}
