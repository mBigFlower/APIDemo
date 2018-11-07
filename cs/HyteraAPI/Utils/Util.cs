using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HyteraAPI.Utils
{
    class Util
    {
        public static void SetClipBoardContent(String content)
        {
            try
            {
                Clipboard.SetText(content);
                MessageBox.Show("已成功将文本框内容复制到剪贴板!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        public static string GetClipBoardContent()
        {
            string clipBoardContent = null;
            try
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    clipBoardContent = (string)iData.GetData(DataFormats.Text);  
                }
                else
                {
                    MessageBox.Show("目前剪贴板中数据不可转换为文本", "错误");
                }
            }
            catch (Exception)
            {
                
            }
            return clipBoardContent;
        }
        
    }
}
