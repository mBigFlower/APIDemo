using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HyteraAPI.APIDetails
{
    class NameWithLevelConverter: IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string tabStr = "    ";
            string result = value[0] as string;
            string levelStr = value[1] as string;
            int level = 0;
            if(!string.IsNullOrEmpty(levelStr))
                level = int.Parse(levelStr);
            for (int i = 0; i < level; i++)
            {
                result = tabStr + result;
            }
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
