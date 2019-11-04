using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell.ModeView
{
    class WebShellConfigModeView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string m_strUrl;
        private string m_strPassword;
        private string m_strRemark;
        private Guid m_guid;
        private WebShellType m_uType;
        private string m_strEncoding;

        public WebShellConfigModeView()
        {
            m_guid = Guid.NewGuid();
            m_strUrl = "http://";
            m_strPassword = "";
            m_strRemark = "";
            m_strEncoding = "";
        }

        public WebShellConfigModeView(CWebShellInfo info)
        {
            m_strUrl = info.Url;
            m_strPassword = info.Password;
            m_strRemark = info.Remark;
            m_guid = info.Guid;
            m_uType = info.Type;
            m_strEncoding = info.Encoding;
        }

        public void SetInfo(CWebShellInfo info)
        {
            m_strUrl = info.Url;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Url)));

            m_strPassword = info.Password;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));

            m_strRemark = info.Remark;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Remark)));

            m_guid = info.Guid;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Guid)));

            m_uType = info.Type;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));

            m_strEncoding = info.Encoding;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Encoding)));
        }

        public string Url
        {
            get => m_strUrl;
            set
            {
                m_strUrl = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Url)));
            }
        }

        public string Password
        {
            get => m_strPassword;
            set
            {
                m_strPassword = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public string Remark
        {
            get => m_strRemark;
            set
            {
                m_strRemark = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Remark)));
            }
        }

        public Guid Guid
        {
            get => m_guid;
            set
            {
                m_guid = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Guid)));
            }
        }

        public WebShellType Type
        {
            get => m_uType;
            set
            {
                m_uType = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
            }
        }

        public string Encoding
        {
            get => m_strEncoding;
            set
            {
                m_strEncoding = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Encoding)));
            }
        }

        public List<string> EncodingList
        {
            get
            {
                List<string> list = new List<string>();
                foreach(var item in System.Text.Encoding.GetEncodings())
                {
                    list.Add(item.Name.ToUpper());
                }
                return list;
            }
        }

        public List<string> TypeList
        {
            get
            {
                List<string> list = new List<string>();
                foreach (var item in Enum.GetNames(typeof(WebShellType)))
                {
                    list.Add(item);
                }

                return list;
            }
        }
    }
}
