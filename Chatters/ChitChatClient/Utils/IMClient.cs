using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatClient.Utils
{
    public class IMClient
    {
        IPAddress ipadd;
        string _port;
        public IMClient()
        {

        }
        public IMClient(Client_Chat ip)
        {
            ipadd = IPAddress.Parse(ip.Server);  
        }

        public IMClient(Client_Chat ip, string port)
        {
            ipadd = IPAddress.Parse(ip.Server);
            _port = port;
        }

        public void setupcon(string ip,string port)
        {
            
        }
    }
}
