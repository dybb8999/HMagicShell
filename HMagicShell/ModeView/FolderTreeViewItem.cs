﻿using System;
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
        

        public FolderTreeViewItem()
        {

        }

        public FolderTreeViewItem(string str)
        {
            m_strPath = str;
        }

        public ObservableCollection<FolderTreeViewItem> SubFolder
        {
            get => m_collectionSubFolder;

            set
            {
                m_collectionSubFolder = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SubFolder"));
            }
        }

        public string Path
        {
            get => m_strPath;

            set
            {
                m_strPath = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Path"));
            }
        }
    }
}