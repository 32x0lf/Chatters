using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using ChitChatAPI;
using System.Windows.Forms;

namespace ChitChatClient.Utils
{
    public class IMClient
    {
        IPAddress ipadd;
        Client_Chat c = new Client_Chat();
        TcpClient client;
        NetworkStream netstream;
        SslStream ssl;
        BinaryReader br;
        BinaryWriter bw;
        string _port;
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

        public void setupcon(string ip, int port, string uname, string upass, bool reg)
        {
            _user = uname;
            _pass = upass;
            _reg = reg;
            client = new TcpClient(ip, port);
            netstream = client.GetStream();
            ssl = new SslStream(netstream, false, new RemoteCertificateValidationCallback(ValidateCert));
            ssl.AuthenticateAsClient("ChitChat");


            br = new BinaryReader(ssl, Encoding.UTF8);
            bw = new BinaryWriter(ssl, Encoding.UTF8);

            int hello = br.ReadInt32();

            if (hello == Client.IM_Hello)
            {
                bw.Write(Client.IM_Hello);
                bw.Write(_reg ? Client.IM_Login : Client.IM_Register);
                bw.Write(_user);
                bw.Write(_pass);
                bw.Flush();

                byte ans = br.ReadByte();
                if (ans == Client.IM_OK)
                {
                    if (reg) { }
                   
                }
                else if (ans == Client.IM_NoExists)
                {
                    Logger.Write("We cannot validate your logins. Please try again.");
                }

            }

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
