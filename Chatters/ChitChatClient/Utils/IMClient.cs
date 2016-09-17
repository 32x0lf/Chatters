using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ChitChatClient.Utils
{
    public class IMClient
    {
        IPAddress ipadd;
        string _port;
        Client_Chat c = new Client_Chat();
        TcpClient client;
        NetworkStream netstream;
        SslStream ssl;
        string _user;
        string _pass;
        bool _reg;
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

        public void setupcon(string ip,int port,string uname,string upass,bool reg)
        {
            client = new TcpClient(ip,port);
            netstream = client.GetStream();
            ssl = new SslStream(netstream, false, new RemoteCertificateValidationCallback(ValidateCert));
            ssl.AuthenticateAsClient("ChitChat");

            _user = uname;
            _pass = upass;
            _reg = reg;
        }

        public static bool ValidateCert(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // Uncomment this lines to disallow untrusted certificates.
            //if (sslPolicyErrors == SslPolicyErrors.None)
            //    return true;
            //else
            //    return false;

            return true; // Allow untrusted certificates.
        }
    }
}
