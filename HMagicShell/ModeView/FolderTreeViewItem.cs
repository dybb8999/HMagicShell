using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell.ModeView
{
    class FolderTreeViewItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<FolderTreeViewItem> m_collectionSubFolder = new ObservableCollection<FolderTreeViewItem>();
        private string m_strPath;
        public string FullPath { get; set; }

        public FolderTreeViewItem()
        {

        }

        public FolderTreeViewItem(string str, string strFullPath)
        {
            m_strPath = str;
            FullPath = strFullPath;
        }

        public ObservableCollection<FolderTreeViewItem> SubFolder
        {
            get => m_collectionSubFolder;

            set
            {
                m_collectionSubFolder = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubFolder)));
            }
        }

        public string Path
        {
            get => m_strPath;

            set
            {
                m_strPath = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Path)));
            }
        }
    }
}
