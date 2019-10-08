using HyteraAPI.APIDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI.Utils
{
    class MockData
    {
        List<ApiDetail> mApiDetailsModels = new List<ApiDetail>();
        public MockData()
        {
            Init();
        }

        private void Init()
        {
            mApiDetailsModels.Add(CreateApi1());
            mApiDetailsModels.Add(CreateApi2());
            mApiDetailsModels.Add(CreateApi3());
            mApiDetailsModels.Add(CreateApi4());
        }

        private ApiDetail CreateApi1()
        {
            return new ApiDetail()
            {
                name = "puc_login_ack",
                guid = "guid",
                id = "1",
                items = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()
                {
                    new TreeNode("result", 1),
                    new TreeNode("cmd_name", 1),
                    new TreeNode("puc_id", 1)
                }
            };
        }
        private ApiDetail CreateApi2()
        {
            return new ApiDetail()
            {
                name = "cc_setup_call",
                guid = "guid",
                id = "2",
                items = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()
                {
                    new TreeNode("result", 1),
                    new TreeNode("cmd_name", "cc_setup_call"),
                    new TreeNode("called", "bigflower"),
                    new TreeNode("callee", "zmm"),
                    new TreeNode("puc_id", 1)
                }
            };
        }
        private ApiDetail CreateApi3()
        {
            return new ApiDetail()
            {
                name = "mon_monitor_ack",
                guid = "guid",
                id = "3",
                items = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()
                {
                    new TreeNode("result", 1),
                    new TreeNode("cmd_name", "mon_monitor_ack"),
                    new TreeNode("puc_id", 1)
                }
            };
        }
        private ApiDetail CreateApi4()
        {
            return new ApiDetail()
            {
                name = "cc_incoming_evt",
                guid = "guid",
                id = "4",
                items = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()
                {
                    new TreeNode("result", 1),
                    new TreeNode("cmd_name", "cc_incoming_evt"),
                    new TreeNode("puc_id", 1)
                }
            };
        }


        public List<ApiDetail> GetMockData()
        {
            return mApiDetailsModels;
        }
    }
}
