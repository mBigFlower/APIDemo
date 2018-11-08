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
                Name = "puc_login_ack",
                Guid = "guid",
                Id = "1",
                Items = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()
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
                Name = "cc_setup_call",
                Guid = "guid",
                Id = "2",
                Items = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()
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
                Name = "mon_monitor_ack",
                Guid = "guid",
                Id = "3",
                Items = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()
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
                Name = "cc_incoming_evt",
                Guid = "guid",
                Id = "4",
                Items = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()
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
