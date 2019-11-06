﻿using HMagicShell.EncryptAndDecode;
using HMagicShell.ShellType;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
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
        //保存WebShell配置信息
        private CWebShellInfo m_pWebShellInfo;
        //拿到PHP5 PHP7 or Ajax处理操作
        private IWebShellControl m_pShellControl;
        //处理编码信息

        private ModeView.FileManagerPageModeView m_pModeview = new ModeView.FileManagerPageModeView();
        public FileManagerPage()
        {
            this.InitializeComponent();
            mainGrid.DataContext = m_pModeview;
        }

        public async Task SetInfo(CWebShellInfo info)
        {
            m_pWebShellInfo = info;
            m_pShellControl = WebShellControlFactory.Create(m_pWebShellInfo.Type);
            m_pShellControl.SetInfo(m_pWebShellInfo.Url, m_pWebShellInfo.Password, Encoding.GetEncoding(m_pWebShellInfo.Encoding), CShellTransmissionEncryptAndDecryptFactory.Create(""));
            await QueryVolumes();
        }

        private void ListViewHeaderReleased(object sender, PointerRoutedEventArgs e)
        {

        }

        private async Task QueryVolumes()
        {
            string jsonData = await m_pShellControl.GetAllVolumes();
            var jsonObj = JObject.Parse(jsonData);
            var diskList = jsonObj["DiskList"];
            
        }
    }
}
