using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI.Base
{
    class Consts
    {
        public const string API_CMD_NAME = "cmd_name";
        public const string HTTP_RESPONSE_OK = "0";



        #region http url
        public const string BASE_IP = "http://127.0.0.1";
        public const string BASE_PORT = ":8081";
        public const string HTTP_GET_ALL = BASE_IP + BASE_PORT + "/api/all";
        public const string HTTP_POST_DETAIL_REVISE = BASE_IP + BASE_PORT + "/api/revise";
        public const string HTTP_POST_DETAIL_ADD = BASE_IP + BASE_PORT + "/api/add";
        #endregion


        public static string GUID {
            get{
                return System.Guid.NewGuid().ToString();
            }
        }
    }
}
