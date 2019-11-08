using HMagicShell.EncryptAndDecode;
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
using Windows.UI.Popups;
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
            m_pShellControl.SetInfo(m_pWebShellInfo.Url, m_pWebShellInfo.Password, Encoding.GetEncoding(m_pWebShellInfo.Encoding), CShellTransmissionEncryptAndDecryptFactory.Create("base64"));
            try
            {
                await QueryVolumes();
            }
            catch(Exception e)
            {
                await new MessageDialog(e.Message).ShowAsync();
            } 
        }

        private void ListViewHeaderReleased(object sender, PointerRoutedEventArgs e)
        {

        }

        private async Task QueryVolumes()
        {
            string jsonData = await m_pShellControl.GetAllVolumes();
            var jsonObj = JObject.Parse(jsonData);
            var diskList = jsonObj["DiskList"];
            //解析json然后同步数据
            var diskArray = diskList.ToArray();
            foreach (var item in diskArray)
            {
                m_pModeview.FolderData.Add(new ModeView.FolderTreeViewItem(item.ToString(), item.ToString()));
            }

            //接下来构建文件夹书结构
            var strBasePath = jsonObj["BaseDir"];
            var subPath = strBasePath.ToString().Split('\\');
            var treeData = m_pModeview.FolderData;
            ModeView.FolderTreeViewItem currentItem = null;
            var strFullPath = "";
            foreach (var subItem in subPath)
            {
                bool bFind = false;
                foreach(var treeItem in treeData)
                {
                    if(subItem.CompareTo(treeItem.Path) == 0)
                    {
                        treeData = treeItem.SubFolder;
                        bFind = true;
                        break;
                    }
                }

                if(strFullPath.CompareTo("") != 0)
                {
                    strFullPath += "\\";
                }
                strFullPath += subItem;

                if(bFind == false)
                {
                    //没有这一项，添加
                    var newFolder = new ModeView.FolderTreeViewItem(subItem, strFullPath);
                    treeData.Add(newFolder);
                    treeData = newFolder.SubFolder;
                    currentItem = newFolder;
                }
            }

            //设置当前路径
            m_pModeview.FullPath = (string)strBasePath;

            //获取文件列表
            await GetFileList(strFullPath + "\\", currentItem);
        }

        private async void folderTreeView_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs args)
        {
            var clickItem = args.InvokedItem as ModeView.FolderTreeViewItem;
            string strQueryPath = clickItem.FullPath + "\\";
            await GetFileList(strQueryPath, clickItem);
        }

        private async Task GetFileList(string strQueryPath, ModeView.FolderTreeViewItem clickItem)
        {
            string jsonData = await m_pShellControl.GetFolderAndFiles(strQueryPath);
            var jsonObj = JObject.Parse(jsonData);

            //设置当前路径
            m_pModeview.FullPath = strQueryPath;
            //清除文件列表内容
            m_pModeview.FileData.Clear();
            //文件夹列表添加
            var folderList = jsonObj["folders"];
            foreach (var folderItem in folderList)
            {
                //文件列表添加
                m_pModeview.FileData.Add(new ModeView.FileInfoItem((string)folderItem["Name"], "文件夹", (long)folderItem["LastModifyTime"], (long)folderItem["Size"]));

                var findItem = from targeItem in clickItem.SubFolder where targeItem.Path == folderItem["Name"].ToString() select folderItem;
                if (findItem.Count() != 0)
                {
                    continue;
                }

                clickItem.SubFolder.Add(new ModeView.FolderTreeViewItem((string)folderItem["Name"], clickItem.FullPath + "\\" + (string)folderItem["Name"]));
            }

            //文件列表添加

            var fileList = jsonObj["files"];
            foreach (var fileItem in fileList)
            {
                m_pModeview.FileData.Add(new ModeView.FileInfoItem((string)fileItem["Name"], "文件", (long)fileItem["LastModifyTime"], (long)fileItem["Size"]));
            }
        }
    }
}
