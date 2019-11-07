using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace HMagicShell.ValueConvert
{
    class FileSizeValueConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string[] suffix = { "Byte", "KB", "MB", "GB" };

            long ulSize = (long)value;
            int i = 0;
            for (; i < suffix.Length; ++i)
            {
                if(ulSize / 1024 <= 0)
                {
                    break;
                }
                ulSize /= 1024;
            }

            return string.Format("{0} {1}", ulSize, suffix[i]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
