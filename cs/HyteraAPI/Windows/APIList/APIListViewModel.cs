using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using HyteraAPI.APIAdd;
using HyteraAPI.APIDetails;
using HyteraAPI.Base;
using HyteraAPI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace HyteraAPI.APIList
{

    public class APIListViewModel : ViewModelBase
    {
        // 待显示数据
        ObservableCollection<ApiDetail> showItems = new ObservableCollection<ApiDetail>();
        string inputSearchText = string.Empty;
        int selectedIndex = -1;

        /// <summary>
        /// 数据驱动，SelectedIndex的改变，来操作显示不同的ApiDetail
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                if (selectedIndex == value)
                    return;
                selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
                ShowDetailByIndex();
            }
        }
        public ObservableCollection<ApiDetail> ShowItems
        {
            get
            {
                return showItems;
            }
            set
            {
                showItems = value;
                RaisePropertyChanged("ShowItems");
            }
        }
        public string InputSearchText
        {
            get
            {
                return inputSearchText;
            }

            set
            {
                if (inputSearchText == value)
                    return;
                inputSearchText = value;
                RaisePropertyChanged("InputSearchText");
                ShowApiList();
            }
        }

        private APIListModel mApiListModel;
        public RelayCommand ClearSearchInputCommand { get; set; }

        public APIListViewModel()
        {
            mApiListModel = new APIListModel();

            ClearSearchInputCommand = new RelayCommand(ClearSearchInput);

            InitMessage();
        }

        private void InitMessage()
        {
            MessengerInstance.Register<string>(this, "ShowDetailByCmdName", ShowDetailByCmdName);
            MessengerInstance.Register<ApiDetail>(this, "ReviseListDetail", ReviseDetail);
            MessengerInstance.Register<List<ApiDetail>>(this, "ShowApiList", message => ShowApiList());
        }

        protected void CleanUp()
        {
            base.Cleanup();
        }

        /// <summary>
        /// 从Model里取数据,过滤后展示
        /// </summary>
        private void ShowApiList()
        {
            App.Current.Dispatcher.Invoke(() => {
                ShowApiList(mApiListModel.GetApiList());
            });
        }
        /// <summary>
        /// 接收到请求后的
        /// </summary>
        /// <param name="showItems"></param>
        private void ShowApiList(List<ApiDetail> basicItems)
        {
            FilterAndShowItems(basicItems);

            ShowDefaultDetail();
        }
        private void FilterAndShowItems(List<ApiDetail> basicItems)
        {
            ShowItems.Clear();

            int length = basicItems.Count;
            for (int i = 0; i < length; i++)
            {
                if (basicItems[i].Name.Contains(InputSearchText))
                    this.ShowItems.Add(basicItems[i]);
            }
        }
        private void ShowDefaultDetail()
        {
            int length = ShowItems.Count;
            if(length == 0)
            {
                SelectedIndex = -2;
                return;
            }
            SelectedIndex = 0;
        }

        private void ShowDetailByCmdName(string cmdName)
        {
            InputSearchText = cmdName;
        }


        // 当选择新的item, 通知Detail界面更新
        private void ShowDetailByIndex()
        {
            if (SelectedIndex < 0)
            {
                // Detail什么都不显示
                Messenger.Default.Send<ApiDetail>(null, "ShowDetail");
            }
            else
            {
                Messenger.Default.Send<ApiDetail>(ShowItems[SelectedIndex], "ShowDetail");
            }
        }


        public void ClearSearchInput()
        {
            InputSearchText = string.Empty;
        }
        /// <summary>
        /// 修改成功后，修改此处的Detail
        /// </summary>
        /// <param name="toReviseDetail"></param>
        private void ReviseDetail(ApiDetail toReviseDetail)
        {
            mApiListModel.ReviseDetail(toReviseDetail);
            //Messenger.Default.Send<string>("未找到已修改的API", "ShowSnackBar");
            ShowApiList();
        }
    }
}
