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

        string introduce;
        bool isNecessary;
        string content;
        string key;
        int level;
        string parentName;

        #region Construction
        public TreeNode()
        {
            
        }
        public TreeNode(string key, int level)
        {
            Key = key;
            Content = "";
            Level = level;
        }
        public TreeNode(string key, string content)
        {
            Key = key;
            Content = content;
            Level = 1;
        }
        #endregion Construction

        #region Getter and Setter
        public string ParentName
        {
            get
            {
                return parentName;
            }
            set
            {
                parentName = value;
                OnRevised("ParentName");
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnRevised("Level");
            }
        }

        public string Key
        {
            set
            {
                key = value;
                OnRevised("Key");
            }
            get
            {
                return key;
            }
        }

        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnRevised("Value");
            }
        }

        public bool IsNecessary
        {
            get
            {
                return isNecessary;
            }

            set
            {
                isNecessary = true;
                OnRevised("IsNecessary");
            }
        }

        public string Introduce
        {
            get
            {
                return introduce;
            }

            set
            {
                introduce = value;
                OnRevised("Introduce");
            }
        }
        #endregion Getter and Setter

        #region clone
        public TreeNode Clone()
        {
            TreeNode result = new TreeNode();
            result.Introduce = this.Introduce;
            result.IsNecessary = this.IsNecessary;
            result.Content = this.Content;
            result.Key = this.Key;
            result.Level = this.Level;
            result.ParentName = this.ParentName;

            return result;
        }
        #endregion

    }
}
