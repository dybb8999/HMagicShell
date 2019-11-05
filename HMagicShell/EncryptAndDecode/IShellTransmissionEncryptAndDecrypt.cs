using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell.EncryptAndDecode
{
    public interface IShellTransmissionEncryptAndDecrypt
    {
        //将代码通过一定方式加密后发送到远程shell
        public string Encrypt(string data);
        //将代码返回的数据进行解密
        public string Decode(string data);
    }

    public class CShellTransmissionEncryptAndDecryptFactory
    {
        public static IShellTransmissionEncryptAndDecrypt Create(string str)
        {
            IShellTransmissionEncryptAndDecrypt ret = null;
            switch (str)
            {
                case "base64":
                    ret = new CBase64EbcryptAndDecrypt();
                    break;
            }
            return ret;
        }
    }
}
