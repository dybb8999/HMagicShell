using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace HMagicShell.ValueConvert
{
    class FileIconValueConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Windows.UI.Xaml.Media.ImageSource source = null;
            string strType = (string)value;
            switch(strType)
            {
                case "文件夹":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/folder.png"));
                    break;

                case "文件":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/default.png"));
                    break;
            }
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
