using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace HMagicShell
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShellListPage : Page
    {
        private ObservableCollection<ModeView.ShellListGridViewModeView> m_pShellListModeView = new ObservableCollection<ModeView.ShellListGridViewModeView>();
        public ShellListPage()
        {
            this.InitializeComponent();
            RefreshWebShell();
            shellList.ItemsSource = m_pShellListModeView;
        }

        private void shellList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickItem = e.ClickedItem as ModeView.ShellListGridViewModeView;
            this.Frame.Navigate(typeof(ControlPage), "asdfasf", new DrillInNavigationTransitionInfo());
        }

        private async void OnAddWebShell(object sender, RoutedEventArgs e)
        {
            WebShellConfigDialog dlg = new WebShellConfigDialog();
            var result = await dlg.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                //确定
                var webShellInfo = dlg.GetWebShellConfig();
                await DataBaseManager.AddWebShellAsync(webShellInfo);
                RefreshWebShell();
            }
        }

        private async void RefreshWebShell()
        {
            m_pShellListModeView.Clear();
            //获取所有webshell
            var webshellList = await DataBaseManager.QueryAllWebShell();
            foreach (var item in webshellList)
            {
                m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView(item.Url, item.CreateTime,item.Guid));
            }
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = e.OriginalSource as MenuFlyoutItem;
            if(item == null)
            {
                return;
            }

            switch ((string)item.Tag)
            {
                case "FileManager":

                    break;

                case "RemoteShell":
                    break;

                case "Modify":
                    break;

                case "Delete":
                    ModeView.ShellListGridViewModeView pData = item.DataContext as ModeView.ShellListGridViewModeView;
                    await DeleteWebShell(pData.Guid);
                    m_pShellListModeView.Remove(pData);
                    break;

                default:
                    break;
            }
        }

        private async Task DeleteWebShell(Guid guid)
        {
            await DataBaseManager.DeleteWebShellAsync(guid);
        }
    }
}
