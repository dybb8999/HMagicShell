using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell
{
    public enum WebShellType : uint
    {
        PHP5,
        PHP7,
        ASPX,
        ASP
    }

    public class CWebShellInfo
    {
        private string m_strUrl;
        private string m_strPassword;
        private string m_strRemark;
        private Guid m_guid;
        private WebShellType m_uType;
        private string m_strEncoding;
        private Int64 m_i64CreateTime;

        public CWebShellInfo()
        {

        }

        public CWebShellInfo(string strUrl, string strPassword, string strRemark, Guid guid, WebShellType type, string encoding, Int64 CreateTime = 0)
        {
            m_strUrl = strUrl;
            m_strPassword = strPassword;
            m_strRemark = strRemark;
            m_guid = guid;
            m_uType = type;
            m_strEncoding = encoding;
            m_i64CreateTime = CreateTime;
        }

        public string Url
        {
            get => m_strUrl;
            set => m_strUrl = value;
        }

        public string Password
        {
            get => m_strPassword;
            set => m_strPassword = value;
        }

        public string Remark
        {
            get => m_strRemark;
            set => m_strRemark = value;
        }

        public Guid Guid
        {
            get => m_guid;
            set => m_guid = value;
        }

        public WebShellType Type
        {
            get => m_uType;
            set => m_uType = value;
        }

        public string Encoding
        {
            get => m_strEncoding;
            set => m_strEncoding = value;
        }

        public Int64 CreateTime
        {
            get => m_i64CreateTime;
            set => m_i64CreateTime = value;
        }
    }
}
