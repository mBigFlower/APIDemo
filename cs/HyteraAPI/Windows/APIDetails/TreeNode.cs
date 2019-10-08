using HyteraAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI.APIDetails
{
    public class TreeNode : BaseModel
    {

        string _introduce;
        bool _isNecessary;
        string _content;
        string _key;
        int _level;
        string _parentName;

        #region Construction
        public TreeNode()
        {
            
        }
        public TreeNode(string key, int level)
        {
            this.key = key;
            this.content = "";
            this.level = level;
        }
        public TreeNode(string key, string content)
        {
            this.key = key;
            this.content = content;
            level = 1;
        }
        #endregion Construction

        #region Getter and Setter
        public string parentName
        {
            get
            {
                return _parentName;
            }
            set
            {
                _parentName = value;
                OnRevised("parentName");
            }
        }

        public int level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                OnRevised("level");
            }
        }

        public string key
        {
            set
            {
                _key = value;
                OnRevised("key");
            }
            get
            {
                return _key;
            }
        }

        public string content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnRevised("content");
            }
        }

        public bool isNecessary
        {
            get
            {
                return _isNecessary;
            }

            set
            {
                _isNecessary = true;
                OnRevised("isNecessary");
            }
        }

        public string introduce
        {
            get
            {
                return _introduce;
            }

            set
            {
                _introduce = value;
                OnRevised("introduce");
            }
        }
        #endregion Getter and Setter

        #region clone
        public TreeNode Clone()
        {
            TreeNode result = new TreeNode();
            result.introduce = this.introduce;
            result.isNecessary = this.isNecessary;
            result.content = this.content;
            result.key = this.key;
            result.level = this.level;
            result.parentName = this.parentName;

            return result;
        }
        #endregion

    }
}
