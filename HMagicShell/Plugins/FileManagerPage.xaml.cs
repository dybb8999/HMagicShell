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

namespace HMagicShell.Plugins
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class FileManagerPage : Page
    {
        private ModeView.FileManagerPageModeView m_pModeview = new ModeView.FileManagerPageModeView();
        public FileManagerPage()
        {
            this.InitializeComponent();

            mainGrid.DataContext = m_pModeview;

            var tmp = new ModeView.FolderTreeViewItem("C");
            tmp.SubFolder.Add(new ModeView.FolderTreeViewItem("asdsa"));
            tmp.SubFolder.Add(new ModeView.FolderTreeViewItem("123123"));
            tmp.SubFolder.Add(new ModeView.FolderTreeViewItem("asdf123"));

            m_pModeview.FolderData.Add(tmp);
            m_pModeview.FolderData.Add(new ModeView.FolderTreeViewItem("D"));
            m_pModeview.FolderData.Add(new ModeView.FolderTreeViewItem("E"));

            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
            m_pModeview.FileData.Add(new ModeView.FileInfoItem());
        }

        private void ListViewHeaderKeyUp(object sender, KeyRoutedEventArgs e)
        {

        }
    }
}
