using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell.EncryptAndDecode
{
    class CBase64EbcryptAndDecrypt : IShellTransmissionEncryptAndDecrypt
    {
        public string Decode(string data)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string data, Encoding encoding)
        {
            var byteData = encoding.GetBytes(data);
            return Convert.ToBase64String(byteData);
        }
    }
}
