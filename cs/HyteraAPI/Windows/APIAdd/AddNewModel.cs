using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using HyteraAPI.APIDetails;
using HyteraAPI.Base;
using JumpKick.HttpLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI.APIAdd
{
    class AddNewModel
    {
        
        public void AddNewApi()
        {
            
        }

        public void HttpAddNewApi(ApiDetail addDetail)
        {
            string jsonData = JsonConvert.SerializeObject(addDetail);

            Http.Post(Consts.HTTP_POST_DETAIL_ADD).Form(new { data = jsonData })
                .OnSuccess(result =>
                {
                    Console.Write(result);
                    DoAddResponse(result);
                })
                .OnFail(error =>
                {
                    Console.Write("Error :  " + error);
                    Messenger.Default.Send<string>(error.Message, "ShowSnackBar");
                })
                .Go();
        }

        private void DoAddResponse(string response)
        {
            MainResponse<string> res = JsonConvert.DeserializeObject<MainResponse<string>>(response);
            if(res.Result == Consts.HTTP_RESPONSE_OK)
            {
                //NotifyAddResult(true, res.Message);
                DispatcherHelper.CheckBeginInvokeOnUI(() => {
                    Messenger.Default.Send<string>(res.Message, "ShowSnackBar");
                    Messenger.Default.Send<object>(null, "AddNewApiSuccess");
                });

            }
            else
            {
                //NotifyAddResult(false, res.Message);
                Messenger.Default.Send<string>(res.Message, "ShowSnackBar");
            }
        }
        
    }
}
