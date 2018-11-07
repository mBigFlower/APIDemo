using HyteraAPI.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI.APIDetails
{
    public class ApiDetail: BaseModel
    {
        string name;
        string id;
        string guid;
        string description;
        ObservableCollection<string> results = new ObservableCollection<string>();
        ObservableCollection<TreeNode> items = new ObservableCollection<TreeNode>();

        public ApiDetail()
        {
            guid = Consts.GUID;
        }
        public ApiDetail(string name, string id, string guid, string description)
        {
            Name = name;
            Id = id;
            Guid = guid;
            Description = description;
        }


        public ObservableCollection<TreeNode> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
                OnPropertyChanged("Items"); // list里用这个嘛？
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Guid
        {
            get
            {
                return guid;
            }

            set
            {
                guid = value;
                OnPropertyChanged("Guid");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public ObservableCollection<string> Results
        {
            get
            {
                return results;
            }

            set
            {
                results = value;
                OnPropertyChanged("Results");
            }
        }


        public ApiDetail Clone()
        {
            ApiDetail newDetail = new ApiDetail(Name, Id, Guid, Description);
            foreach (var item in this.Items)
            {
                newDetail.Items.Add(item.Clone());
            }
            foreach (var resultItem in Results)
            {
                newDetail.Results.Add(resultItem);
            }
            return newDetail;
        }
        
    }
}
