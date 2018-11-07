using HyteraAPI.Base;
using JumpKick.HttpLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using GalaSoft.MvvmLight.Messaging;

namespace HyteraAPI.APIDetails
{
    class APIDetailsModel:BaseModel
    {
        public APIDetailsModel()
        {

        }

        public void PostReviseApiDetail(ApiDetail apiDetail)
        {
            HttpRevise(apiDetail);
        }

        private void HttpRevise(ApiDetail apiDetail)
        {
            string jsonData = JsonConvert.SerializeObject(apiDetail);

            Http.Post(Consts.HTTP_POST_DETAIL_REVISE).Form(new { data = jsonData })
                .OnSuccess(result =>
                {
                    Console.Write(result);

                    DoReviseResponse(result);
                })
                .OnFail(error =>
                {
                    Console.Write("Error :  " + error);
                    Messenger.Default.Send<string>(error.Message, "ShowSnackBar");
                })
                .Go();
        }

        private void DoReviseResponse(string response)
        {
            MainResponse<ApiDetail> res = JsonConvert.DeserializeObject<MainResponse<ApiDetail>>(response);
            if (res.Result == Consts.HTTP_RESPONSE_OK)
            {
                //NotifyAddResult(true, res.Message);
                Messenger.Default.Send<string>(res.Message, "ShowSnackBar");
                Messenger.Default.Send<ApiDetail>(res.Data, "ReviseListDetail");
            }
            else
            {
                //NotifyAddResult(false, res.Message);
                Messenger.Default.Send<string>(res.Message, "ShowSnackBar");
            }
        }

    }
}
