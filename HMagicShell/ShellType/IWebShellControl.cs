using HMagicShell.EncryptAndDecode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell.ShellType
{
    public interface IWebShellControl
    {
        public void SetInfo(string address, string password, Encoding encoding, IShellTransmissionEncryptAndDecrypt itead);
        public Task<string> GetAllVolumes();
    }

    class WebShellControlFactory
    {
        public static IWebShellControl Create(WebShellType type)
        {
            IWebShellControl ret = null;
            switch (type)
            {
                case WebShellType.PHP5:
                    ret = new CWebShellPHP5();
                    break;
                case WebShellType.PHP7:
                    break;
                case WebShellType.ASPX:
                    break;
                case WebShellType.ASP:
                    break;
                default:
                    break;
            }
            return ret;
        }
    }
}
