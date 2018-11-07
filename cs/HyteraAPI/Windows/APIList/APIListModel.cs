using GalaSoft.MvvmLight.Messaging;
using HyteraAPI.APIAdd;
using HyteraAPI.APIDetails;
using HyteraAPI.Base;
using JumpKick.HttpLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI.APIList
{
    class APIListModel
    {
        List<ApiDetail> basicApis = new List<ApiDetail>();

        public APIListModel()
        {
            Init();
        }

        private void Init()
        {
            HttpGetApis();

            Messenger.Default.Register<object>(this, "AddNewApiSuccess", message => HttpGetApis());
        }

        private void HttpGetApis()
        {
            Http.Get(Consts.HTTP_GET_ALL).OnSuccess(result =>
            {
                Console.WriteLine(result);
                OnResponse(result);

            }).OnFail(error=> {
                Console.WriteLine(error);
                Messenger.Default.Send<string>(error.Message, "ShowSnackBar");
            })
            .Go();
        }
        private void OnResponse(string result)
        {
            basicApis = JsonConvert.DeserializeObject<List<ApiDetail>>(result);
            // 将请求结果,通知给ViewModel
            Messenger.Default.Send<List<ApiDetail>>(basicApis, "ShowApiList");
        }

        #region Public
        public List<ApiDetail> GetApiList()
        {
            return basicApis;
        }
        public ApiDetail GetApiDetail(int index)
        {
            return basicApis[index];
        }
        public void ReviseDetail(ApiDetail toReviseDetail)
        {
            int itmesCount = basicApis.Count;
            for (int i = 0; i < itmesCount; i++)
            {
                if (basicApis[i].Name == toReviseDetail.Name)
                {
                    basicApis[i] = toReviseDetail.Clone();
                    break;
                }
            }
        }
    }

    #endregion

}
