using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace HMagicShell
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //初始化数据库
            DataBaseManager.QueryAllWebShell();
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            var item = navigationView.MenuItems[0] as NavigationViewItem;
            if(item != null)
            {
                item.IsSelected = true;
            }
            
        }

        private void navigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            
        }

        private void navigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem navigationView = args.InvokedItemContainer as NavigationViewItem;
            do
            {
                if (args.IsSettingsInvoked == true)
                {
                    //Go to Setting
                    break;
                }

                if (navigationView == null)
                {
                    break;
                }

                string strTag = navigationView.Tag as string;
                switch (strTag)
                {
                    case "ShellList":
                        contentFrame.Navigate(typeof(ShellListPage));
                        break;

                    case "Controller":
                        contentFrame.Navigate(typeof(ControlPage));
                        break;

                    case "About":
                        contentFrame.Navigate(typeof(AboutPage));
                        break;
                }
            } while (false);
        }

        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if(e.SourcePageType == typeof(ShellListPage))
            {
                (navigationView.MenuItems[0] as NavigationViewItem).IsSelected = true;
            }
            else if(e.SourcePageType == typeof(ControlPage))
            {
                (navigationView.MenuItems[1] as NavigationViewItem).IsSelected = true;
            }
            else if(e.SourcePageType == typeof(AboutPage))
            {
                (navigationView.MenuItems[2] as NavigationViewItem).IsSelected = true;
            }
        }
    }
}
