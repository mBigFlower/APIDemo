using GalaSoft.MvvmLight.Messaging;
using JumpKick.HttpLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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

namespace HyteraAPI.APIDetails
{
    /// <summary>
    /// APIDetails.xaml 的交互逻辑
    /// </summary>
    public partial class APIDetailsView : UserControl
    {
        
        private APIDetailsViewModel detailViewModel = new APIDetailsViewModel();

        public APIDetailsView()
        {
            InitializeComponent();

            Init();
        }
        private void Init()
        {
            this.DataContext = detailViewModel;
            this.Unloaded += (sender, e) =>
            {
                detailViewModel.Dispose();
            };
            
        }

        private void DeleteResultItem_Click(object sender, RoutedEventArgs e)
        {
            detailViewModel.DeleteResultItem();
        }
        private void DeleteGridItem_Click(object sender, RoutedEventArgs e)
        {
            detailViewModel.DeleteDetailItem();
        }
    }
}
