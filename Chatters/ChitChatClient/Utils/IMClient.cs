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
using System.ComponentModel;

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
        public static bool _closeform { get; set; }

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
            try
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

                    int a = br.PeekChar() + 1; // I am not sure if this is correct but it works. Prevent to have a -1 value.
                    byte ans = br.ReadByte();

                    if (ans == Client.IM_OK)
                    {
                        if (reg)
                        {
                            Logger.Write("Success");
                            HideFormLogin();
                            MainClient m = new MainClient();
                            m.ShowDialog();
                        }

                    }
                    else if (ans == Client.IM_WrongPass)
                    {
                        Logger.Write("Wrong Password, Please try again.");
                        _closeform = false;
                    }
                    else if (ans == Client.IM_NoExists)
                    {
                        Logger.Write("We cannot validate your logins. Please try again.", ChitChatAPI.Enums.LogLevel.Error, ConsoleColor.Red);
                    }
                    else if (ans == Client.IM_SomeoneLoggedIn)
                    {
                        Logger.Write("Someone Logged-In to your account.Please log In again.", ChitChatAPI.Enums.LogLevel.Error, ConsoleColor.Red);
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
            }
        }
        delegate void HideFormLoginDelegate();
        private static void HideFormLogin()
        {
            //BackgroundWorker bw = new BackgroundWorker();
            //bw.DoWork += (s, e) => { };
            //bw.RunWorkerCompleted += (s, e) =>
            //{

            var a = Application.OpenForms;
            if (a[0].InvokeRequired == true)
            {
                a[0].Invoke((HideFormLoginDelegate)delegate ()
                 {
                     a[0].Hide();
                 });
            }

            //};
            //bw.RunWorkerAsync();

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
