using GalaSoft.MvvmLight.Messaging;
using HyteraAPI.APIDetails;
using HyteraAPI.APIList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI
{
    /// <summary>
    /// 缓存库
    /// 1. 服务器返回的API列表
    /// 2. 筛选出字段列表
    /// </summary>
    class DataBase
    {
        private List<ApiDetail> mApis = new List<ApiDetail>();

        #region 单例
        public static DataBase mInstance;

        public static DataBase Get()
        {
            if(mInstance == null)
            {
                mInstance = new DataBase();
            }
            return mInstance;
        }

        public DataBase()
        {
            Messenger.Default.Register<List<ApiDetail>>(this, "ShowApiList", apis => APIListModel_GetListSuccess(apis));
        }
        #endregion

        private void APIListModel_GetListSuccess(List<ApiDetail> apis)
        {
            mApis = apis;
        }
        #region Public
        public ApiDetail FindApiDetail(string cmdName)
        {
            if (mApis == null || mApis.Count == 0)
                return null;
            return mApis.Find((detail) => detail.Name == cmdName);
        }
        #endregion
    }
}
