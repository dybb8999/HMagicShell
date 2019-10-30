using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell.ModeView
{
    class FileInfoItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string m_strName;
        private DateTime m_dateLastChangeTime;
        private string m_strType;
        private uint m_uSize;

        public FileInfoItem()
        {
            m_strName = "1";
            m_dateLastChangeTime = DateTime.Now;
            m_strType = "exe";
            m_uSize = 1024;
        }

        public string Name
        {
            get => m_strName;

            set
            {
                m_strName = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public DateTime LastChangeTime
        {
            get => m_dateLastChangeTime;
            set
            {
                m_dateLastChangeTime = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastChangeTime)));
            }
        }

        public string Type
        {
            get => m_strType;
            set
            {
                m_strType = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
            }
        }

        public uint Size
        {
            get => m_uSize;
            set
            {
                m_uSize = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Size)));
            }
        }
    }
}
