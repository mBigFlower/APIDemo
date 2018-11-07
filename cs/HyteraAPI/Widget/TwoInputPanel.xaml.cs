using GalaSoft.MvvmLight.Messaging;
using HyteraAPI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HyteraAPI.Widget
{
    /// <summary>
    /// 两个输入的Panel
    /// </summary>
    public partial class TwoInputPanel : UserControl, INotifyPropertyChanged
    {

        private Visibility addResultItemPanelVisibility = Visibility.Collapsed;
        public Visibility AddResultItemPanelVisibility
        {
            get
            {
                return addResultItemPanelVisibility;
            }

            set
            {
                addResultItemPanelVisibility = value;
                OnPropertyChanged("AddResultItemPanelVisibility");
            }
        }

        private string keyInputStr;
        public string KeyInputStr
        {
            get
            {
                return keyInputStr;
            }

            set
            {
                keyInputStr = value;
                OnPropertyChanged("KeyInputStr");
            }
        }

        private string valueInputStr;
        public string ValueInputStr
        {
            get
            {
                return valueInputStr;
            }

            set
            {
                valueInputStr = value;
                OnPropertyChanged("ValueInputStr");
            }
        }


        public TwoInputPanel()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            AddResultItemLayout.DataContext = this;

            Messenger.Default.Register<bool>(this, "ChangeAddResultItemPanel", ChangePanelVisible);
            this.Unloaded += (sender, e) =>
            {
                Messenger.Default.Unregister(this);
            };

        }

        private void SureBt_Click(object sender, RoutedEventArgs e)
        {
            if (!IsInputRight())
            {
                // Say Something.
                Messenger.Default.Send<string>("Input is Wrong !", "ShowSnackBar");
                return;
            }
            Messenger.Default.Send<string>(KeyInputStr+" - "+ValueInputStr, "AddResultItem");
            KeyInputStr = ValueInputStr = "";
            HiddenPanel();
        }
        private bool IsInputRight()
        {
            if (string.IsNullOrEmpty(KeyInputStr))
            {
                return false;
            }
            if (string.IsNullOrEmpty(ValueInputStr))
            {
                return false;
            }
            return true;
        }
        
        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            HiddenPanel();
        }

        public void ChangePanelVisible(bool isShow)
        {
            if (isShow)
                ShowPanel();
            else
                HiddenPanel();
        }
        public void ShowPanel()
        {
            AddResultItemPanelVisibility = Visibility.Visible;
        }
        public void HiddenPanel()
        {
            AddResultItemPanelVisibility = Visibility.Collapsed;
        }

        // TODO 动画





        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
