using Microsoft.UI.Xaml.Controls;
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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace HMagicShell
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ControlPage : Page
    {
        static private List<TabViewItem> m_listControllerSave = null;
        public ControlPage()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        { 
            //首先检查是否保存有其他窗口
            if(m_listControllerSave != null)
            {
                //恢复
                tabView.TabItems.Clear();
                foreach (var item in m_listControllerSave)
                {
                    tabView.TabItems.Add(item);
                }
            }
            
            //检查是否传递参数
            if(e?.Parameter == null)
            {
                return;
            }

            var info = e.Parameter as CPluginCreateInfo;
            tabView.TabItems.Add(CreateNewTab(info.WebShellInfo, info.Plugin));
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //要离开，保存tabviewitem
            m_listControllerSave = new List<TabViewItem>();
            foreach (var item in tabView.TabItems)
            {
                m_listControllerSave.Add(item as TabViewItem);
            }
            tabView.TabItems.Clear();
            base.OnNavigatingFrom(e);
        }

        private TabViewItem CreateNewTab(CWebShellInfo info, string Plugin)
        {
            TabViewItem newItem = new TabViewItem();
            newItem.Header = info.Url;

            switch(Plugin)
            {
                case "FileManager":
                    newItem.IconSource = new Microsoft.UI.Xaml.Controls.SymbolIconSource() { Symbol = Symbol.Folder };
                    var page = new Plugins.FileManagerPage();
                    page.SetInfo(info).ConfigureAwait(false);
                    newItem.Content = page;
                    break;

                case "RemoteShell":
                    newItem.IconSource = new Microsoft.UI.Xaml.Controls.SymbolIconSource() { Symbol = Symbol.PostUpdate };
                    newItem.Content = new Plugins.TerminalPage();
                    break;
            }
            

            // The content of the tab is often a frame that contains a page, though it could be any UIElement.

            
            return newItem;
        }

        private void tabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
        }
    }
}
