using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using HyteraAPI.APIList;
using HyteraAPI.Base;
using HyteraAPI.Utils;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HyteraAPI.APIDetails
{
    class APIDetailsViewModel:BaseModel
    {
        private ApiDetail detail = new ApiDetail();
        private APIDetailsModel mApiDetailsModel= new APIDetailsModel();
        public RelayCommand ShowAddResultDialogCommand { get; set; }
        public RelayCommand AddDetailItemCommand { get; set; }
        public RelayCommand DetailReviseCommand { get; set; }
        //public RelayCommand DeleteResultItemCommand { get; set; }
    

        public ApiDetail Detail
        {
            get
            {
                return detail;
            }

            set
            {
                detail = value;
                OnPropertyChanged("Detail");
            }
        }

        private Visibility loadingVisibility;
        private Visibility addResultItemButtonVisibility;

        public Visibility LoadingVisibility
        {
            get
            {
                return loadingVisibility;
            }

            set
            {
                loadingVisibility = value;
                OnPropertyChanged("LoadingVisibility");
            }
        }
        public Visibility AddResultItemButtonVisibility
        {
            get
            {
                return addResultItemButtonVisibility;
            }

            set
            {
                addResultItemButtonVisibility = value;
                OnPropertyChanged("AddResultItemButtonVisibility");
            }
        }

        private int resultItemSelectedIndex;
        public int ResultItemSelectedIndex
        {
            set
            {
                resultItemSelectedIndex = value;
                OnPropertyChanged("SelectedResultItem");
            }
            get
            {
                return resultItemSelectedIndex;
            }
        }

        public APIDetailsViewModel()
        {
            Init();
        }
        

        private void Init()
        {
            ShowAddResultDialogCommand = new RelayCommand(ShowAddResultPanel);
            AddDetailItemCommand = new RelayCommand(AddEmptyDetailItem);
            DetailReviseCommand = new RelayCommand(HttpRevise);
            //DeleteResultItemCommand = new RelayCommand(DeleteResultItem);
            //APIListViewModel.ShowDetail += ShowDetail;
            Messenger.Default.Register<ApiDetail>(this, "ShowDetail", ShowDetail);
            Messenger.Default.Register<string>(this, "AddResultItem", AddResultItem);
        }

        private void ShowDetail(ApiDetail apiItem)
        {
            // TODO 没有显示的时候，最好显示另一个“画面”
            if(apiItem == null)
            {
                Detail = new ApiDetail();
                HiddenLoading();
            } else
            {
                Detail = apiItem.Clone();
                HiddenLoading();
            }
        }
        private void ShowAddResultPanel()
        {
            Messenger.Default.Send<bool>(true, "ChangeAddResultItemPanel");
        }
        //private void HiddenAddResultPanel()
        //{
        //    AddResultItemButtonVisibility = Visibility.Visible;
        //}

        private void AddResultItem(string newItem)
        {
            if (string.IsNullOrEmpty(newItem))
                return;
            Detail.results.Add(newItem);
            // 排序  TODO 这个方法有点low啊
            Detail.results = new ObservableCollection<string>(Detail.results.OrderBy(s => s));
        }
        // 暂时没用
        private void AddAPIItem(TreeNode apiItem)
        {
            Detail.items.Add(apiItem);
        }

        private void AddEmptyDetailItem()
        {
            Detail.items.Add(new TreeNode());
        }

        // 修改请求
        public void HttpRevise()
        {
            // TODO 判断Detail的有效性
            if (Detail.name == null)
            {
                return;
            }

            mApiDetailsModel.PostReviseApiDetail(Detail);
        }

        public void DeleteResultItem()
        {
            if (ResultItemSelectedIndex >= Detail.results.Count || ResultItemSelectedIndex < 0)
                return;
            Detail.results.RemoveAt(ResultItemSelectedIndex);
        }

        public void DeleteDetailItem()
        {

        }

        private void ShowHttpFailed()
        {

        }
        private void ShowLoading()
        {
            LoadingVisibility = Visibility.Visible;
        }
        private void HiddenLoading()
        {
            LoadingVisibility = Visibility.Collapsed;
        }
    }
}
