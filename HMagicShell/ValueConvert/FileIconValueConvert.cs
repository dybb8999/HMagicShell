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

                case "exe":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/exe.png"));
                    break;

                case "dll":
                case "sys":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/dll.png"));
                    break;

                case "ini":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/ini.png"));
                    break;

                case "pdf":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/pdf.png"));
                    break;

                case "rtf":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/rtf.png"));
                    break;

                case "mp3":
                case "wav":
                case "flac":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/music.png"));
                    break;

                case "php":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/php.png"));
                    break;

                case "cpp":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/cpp.png"));
                    break;

                case "js":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/js.png"));
                    break;

                case "doc":
                case "docx":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/word.png"));
                    break;

                case "xls":
                case "xlsx":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/excel.png"));
                    break;

                case "ppt":
                case "pptx":
                    source = new BitmapImage(new Uri("ms-appx:///Assets/FileTypeIcon/ppt.png"));
                    break;

                default:
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
