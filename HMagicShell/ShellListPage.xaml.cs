using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            m_pShellListModeView.Add(new ModeView.ShellListGridViewModeView("http://127.0.0.1/tesp.php", DateTime.Now));
            shellList.ItemsSource = m_pShellListModeView;
        }

        private void shellList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickItem = e.ClickedItem as ModeView.ShellListGridViewModeView;
            this.Frame.Navigate(typeof(ControlPage), "asdfasf", new DrillInNavigationTransitionInfo());
        }

        private async void OnAddWebShell(object sender, RoutedEventArgs e)
        {
            AddWebShellDialog dlg = new AddWebShellDialog();
            var result = await dlg.ShowAsync();
        }
    }
}
