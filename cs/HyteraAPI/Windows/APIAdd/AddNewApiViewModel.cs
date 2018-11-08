using GalaSoft.MvvmLight.Messaging;
using HyteraAPI.APIDetails;
using HyteraAPI.Base;
using HyteraAPI.Utils;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HyteraAPI.APIAdd
{
    class AddNewApiViewModel : BaseModel
    {
        const int STATE_DATA_BAD = 0;
        const int STATE_DATA_EXIST = 1;
        const int STATE_DATA_OK = 2;

        private AddNewModel mAddNewModel;
        private string CmdName ;
        #region 绑定显示的内容
        private ObservableCollection<TreeNode> toAddItems = new ObservableCollection<TreeNode>();
        private ApiDetail addDetail = new ApiDetail();
        private string message;

        public ObservableCollection<TreeNode> ToAddItems
        {
            get
            {
                return toAddItems;
            }

            set
            {
                toAddItems = value;
            }
        }
        public ApiDetail AddDetail
        {
            get
            {
                return addDetail;
            }

            set
            {
                addDetail = value;
                OnPropertyChanged("AddDetail");
            }
        }
        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        #endregion 绑定显示的内容 end
        #region 按钮的状态
        private bool isTransferBtnEnable;
        private Visibility transferBtnVisibility;
        private Visibility goCheckBtnVisibility;
        public bool IsTransferBtnEnable
        {
            get
            {
                return isTransferBtnEnable;
            }

            set
            {
                isTransferBtnEnable = value;
                OnPropertyChanged("IsTransferEnable");
            }
        }

        public Visibility TransferBtnVisibility
        {
            get
            {
                return transferBtnVisibility;
            }

            set
            {
                transferBtnVisibility = value;
                OnPropertyChanged("TransferBtnVisibility");
            }
        }

        public Visibility GoCheckBtnVisibility
        {
            get
            {
                return goCheckBtnVisibility;
            }

            set
            {
                goCheckBtnVisibility = value;
                OnPropertyChanged("GoCheckBtnVisibility");
            }
        }
        #endregion 按钮的状态 end
        public AddNewApiViewModel()
        {
            mAddNewModel = new AddNewModel();
        }


        private void ResetCard()
        {
            addDetail = new ApiDetail();
            TransferBtnVisibility = Visibility.Visible;
            GoCheckBtnVisibility = Visibility.Collapsed;
            IsTransferBtnEnable = true;
        }
        private void CheckXmlDataValidity()
        {
            string clipBoardData = Util.GetClipBoardContent();
            ToAddItems = new XmlBase(clipBoardData).GetData();
            if (ToAddItems == null)
            {
                // xml data is error, str maybe get from resource
                // 提示错误原因？
                DataBadState();
            }
            else if(IsDataExist())
            {
                DataExistState();
            }
            else
            {
                DataOKState();
            }
        }
        private void DataBadState()
        {
            Message = "复制的数据 格式有误";
            IsTransferBtnEnable = false;
        }
        private void DataExistState()
        {
            Message = "已找到该API";
            GoCheckBtnVisibility = Visibility.Visible;
            TransferBtnVisibility = Visibility.Collapsed;
        }
        private void DataOKState()
        {
            Message = CmdName;
            InitApiDetailItems();
        }

        private bool IsDataExist()
        {
            CmdName = FindCmdName();
            ApiDetail apiDetailFinded = DataBase.Get().FindApiDetail(CmdName);
            return apiDetailFinded == null ? false : true;
        }
        private string FindCmdName()
        {
            foreach (var item in ToAddItems)
            {
                if(item.Key == Consts.API_CMD_NAME) {
                    addDetail.Name = item.Content;
                    return item.Content;
                }
            }
            return null;
        }
        private void InitApiDetailItems()
        {
            addDetail.Items = ToAddItems;
        }
        #region public
        public void TransferData()
        {
            ResetCard();
            CheckXmlDataValidity();
        }
        public void Clear()
        {
            addDetail = new ApiDetail();
        }
        public void AddNewApi()
        {
            mAddNewModel.HttpAddNewApi(AddDetail);
        }
        public void CheckDetail()
        {
            Messenger.Default.Send<string>(CmdName, "ShowDetailByCmdName");
        }
        #endregion
    }
}
