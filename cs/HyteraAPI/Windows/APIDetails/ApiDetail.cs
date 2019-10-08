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
        string _name;
        string _id;
        string _guid;
        string _description;
        ObservableCollection<string> _results = new ObservableCollection<string>();
        ObservableCollection<TreeNode> _items = new ObservableCollection<TreeNode>();

        public ApiDetail()
        {
            _guid = Consts.GUID;
        }
        public ApiDetail(string _name, string _id, string _guid, string _description)
        {
            name = _name;
            id = _id;
            guid = _guid;
            description = _description;
        }


        public ObservableCollection<TreeNode> items
        {
            get
            {
                return _items;
            }

            set
            {
                _items = value;
                OnPropertyChanged("items"); // list里用这个嘛？
            }
        }

        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }

        public string id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
                OnPropertyChanged("id");
            }
        }

        public string guid
        {
            get
            {
                return _guid;
            }

            set
            {
                _guid = value;
                OnPropertyChanged("guid");
            }
        }

        public string description
        {
            get
            {
                return _description;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    return;
                _description = value;
                OnPropertyChanged("description");
            }
        }

        public ObservableCollection<string> results
        {
            get
            {
                return _results;
            }

            set
            {
                _results = value;
                OnPropertyChanged("results");
            }
        }


        public ApiDetail Clone()
        {
            ApiDetail newDetail = new ApiDetail(name, id, guid, description);
            foreach (var item in this.items)
            {
                newDetail.items.Add(item.Clone());
            }
            foreach (var resultItem in results)
            {
                newDetail.results.Add(resultItem);
            }
            return newDetail;
        }
        
    }
}
