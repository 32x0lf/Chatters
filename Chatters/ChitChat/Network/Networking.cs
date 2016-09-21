using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChitChatAPI;
using ChitChat.Core;
using System.Security.Cryptography.X509Certificates;
using System.Security.Authentication;

namespace ChitChat.Network
{
    public class Networking
    {
        public X509Certificate cert = new X509Certificate(file, pass);
        public Networking()
        {

        }
      
        public static string file
        {
            get { return "server.pfx"; }        
        }

        public static string pass
        {
            get { return "instant"; }
        }

        
    }
}
