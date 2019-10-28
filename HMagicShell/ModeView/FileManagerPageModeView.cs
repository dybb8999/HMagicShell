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

        public ObservableCollection<FolderTreeViewItem> FolderData
        {
            get => m_pFolderCollect;
            set
            {
                m_pFolderCollect = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FolderData"));
            }
        }
    }
}
