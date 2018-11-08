using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI.Base
{
    class MainResponse<T>
    {
        string result;
        string message;
        T data;

        public string Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
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
            }
        }

        public T Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }
    }
}
