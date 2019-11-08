using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell.ModeView
{
    class FileManagerPageModeView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<FolderTreeViewItem> m_pFolderCollect = new ObservableCollection<FolderTreeViewItem>();
        private ObservableCollection<FileInfoItem> m_pFileCollect = new ObservableCollection<FileInfoItem>();
        private string m_strFullPath;

        public string FullPath
        {
            get => m_strFullPath;
            set
            {
                m_strFullPath = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FullPath"));
            }
        }


        public ObservableCollection<FolderTreeViewItem> FolderData
        {
            get => m_pFolderCollect;
            set
            {
                m_pFolderCollect = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FolderData)));
            }
        }

        public ObservableCollection<FileInfoItem> FileData
        {
            get => m_pFileCollect;
            set
            {
                m_pFileCollect = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileData)));
            }
        }
    }
}
