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
            var info = new CPluginCreateInfo();
            info.WebShellInfo = clickItem.BaseInfo;
            //点击默认打开文件管理器
            info.Plugin = "FileManager";
            this.Frame.Navigate(typeof(ControlPage), info, new DrillInNavigationTransitionInfo());
        }

        private async void OnAddWebShell(object sender, RoutedEventArgs e)
        {
            WebShellConfigDialog dlg = new WebShellConfigDialog();
            var result = await dlg.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                //确定
                var webShellInfo = dlg.GetWebShellConfig();
                //设置创建时间
                webShellInfo.CreateTime = DateTime.Now.ToFileTimeUtc();

                await DataBaseManager.AddWebShellAsync(webShellInfo);
                ModeView.ShellListGridViewModeView webShellItem = new ModeView.ShellListGridViewModeView(webShellInfo.Url, webShellInfo.CreateTime, webShellInfo);
                m_pShellListModeView.Add(webShellItem);
            }
        }

        private async void RefreshWebShell()
        {
            m_pShellListModeView.Clear();
            //获取所有webshell
            var webshellList = await DataBaseManager.QueryAllWebShell();
            foreach (var item in webshellList)
            {
                m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView(item.Url, item.CreateTime, item));
            }
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = e.OriginalSource as MenuFlyoutItem;
            if(item == null)
            {
                return;
            }

            ModeView.ShellListGridViewModeView pData = item.DataContext as ModeView.ShellListGridViewModeView;
            var info = new CPluginCreateInfo();
            info.WebShellInfo = pData.BaseInfo;
            info.Plugin = (string)item.Tag;
            switch ((string)item.Tag)
            {
                case "FileManager":
                case "RemoteShell":
                    this.Frame.Navigate(typeof(ControlPage), info, new DrillInNavigationTransitionInfo());
                    break;

                case "Modify":
                    await ModifyWebShell(pData.BaseInfo);
                    break;

                case "Delete":
                    await DeleteWebShell(pData.BaseInfo);
                    break;

                default:
                    break;
            }
        }

        private async Task DeleteWebShell(CWebShellInfo info)
        {
            await DataBaseManager.DeleteWebShellAsync(info.Guid);
            var deleteItem = (from item in m_pShellListModeView where item.Guid == info.Guid select item).FirstOrDefault();
            m_pShellListModeView.Remove(deleteItem);
        }

        private async Task ModifyWebShell(CWebShellInfo info)
        {
            WebShellConfigDialog dlg = new WebShellConfigDialog();
            dlg.SetWebShellConfig(info);
            var result = await dlg.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                info = dlg.GetWebShellConfig();
                //更新数据库
                await DataBaseManager.ModifyWebShellAsync(info);

                //更新界面数据
                var modifyItem = (from item in m_pShellListModeView where item.Guid == info.Guid select item).FirstOrDefault();
                modifyItem.SetFromData(info);
            }

            //RefreshWebShell();
        }
    }
}
