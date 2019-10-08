using HyteraAPI.APIDetails;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HyteraAPI.Utils
{
    /// <summary>
    /// Xml处理类
    ///  TODO 需要处理异常
    /// </summary>
    class XmlBase
    {
        const string XML_DEFAULT_NAME = "#text";
        const string XML_DEFAULT_ROOT_NODE = "hytera";

        public XmlBase()
        {
            
        }
        public XmlBase(string xmlStr)
        {
            XmlNode rootNode = GetXmlNodeByStr(xmlStr, XML_DEFAULT_ROOT_NODE);
            if(rootNode != null)
            {
                ReadXmlNode(rootNode.ChildNodes, 1);
            } else
            {
                treeNodes = null;
            }
        }

        public XmlNode GetXmlNodeByStr(string xmlFileStr, string rootNodeName)
        {
            try
            {
                XmlDocument xmldocument = new XmlDocument();
                xmldocument.LoadXml(xmlFileStr);
                XmlNode xmlnode = xmldocument.SelectSingleNode(rootNodeName);
                return xmlnode;
            }
            catch
            {
                return null;
            }
        }
        public XmlNode GetXmlNode(string xmlFileName, string rootNodeName)
        {
            try
            {
                XmlDocument xmldocument = new XmlDocument();
                xmldocument.Load(xmlFileName);
                XmlNode xmlnode = xmldocument.SelectSingleNode(rootNodeName);
                return xmlnode;
            }
            catch
            {
                return null;
            }
        }

        #region xml to tree
        ObservableCollection<TreeNode> treeNodes = new ObservableCollection<TreeNode>();

        private void ReadXmlNode(XmlNodeList Xmlnodes, int level)
        {
            foreach (XmlNode subXmlnod in Xmlnodes)
            {
                if (HasNoChildrenReally(subXmlnod)) // 已无子节点
                {
                    AddNode(subXmlnod, level);
                }
                else if (subXmlnod.ChildNodes.Count > 0) // 此为父节点
                {
                    AddNode(subXmlnod, level, false);
                    ReadXmlNode(subXmlnod.ChildNodes, level + 1);
                }
            }
        }
        /// <summary>
        /// 是否是“最末”的节点（即没有子节点）
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <returns></returns>
        private bool HasNoChildrenReally(XmlNode xmlNode)
        {
            return xmlNode.ChildNodes.Count == 1 && xmlNode.ChildNodes[0].Name.Equals(XML_DEFAULT_NAME);
        }
        /// <summary>
        /// 将筛出的节点，添加到List中。
        /// 判重
        /// </summary>
        /// <param name="xmlnode"></param>
        /// <param name="level">节点的等级</param>
        /// <param name="isAddContent"></param>
        private void AddNode(XmlNode xmlnode, int level, bool isAddContent = true)
        {
            if (!IsKeyExist(xmlnode.Name))
            {
                TreeNode treeNode = new TreeNode(xmlnode.Name, level);
                if (isAddContent)
                {
                    treeNode.content = xmlnode.InnerText;
                }
                treeNodes.Add(treeNode);
            }
        }

        private bool IsKeyExist(string key)
        {
            // TODO 这里有个list和observableCollection的转换操作，后期优化一下
            return treeNodes.ToList().Exists(treeNode => treeNode.key == key);
        }


        ///////////// public 
        public ObservableCollection<TreeNode> GetData()
        {
            return treeNodes;
        }


        #endregion end - xml to tree

        
    }
}
