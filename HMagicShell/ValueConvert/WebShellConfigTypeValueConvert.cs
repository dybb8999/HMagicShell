using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace HMagicShell.ValueConvert
{
    class WebShellConfigTypeValueConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (WebShellType)Enum.Parse(typeof(WebShellType), (string)value, true);  
        }
    }
}
