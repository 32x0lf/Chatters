using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChitChatAPI;
using ChitChatAPI.Enums;
using System.Security.Cryptography.X509Certificates;
using ChitChat.Network;
using System.Net.NetworkInformation;
using ChitChat;

namespace ChitChat.Core
{
    public class Servercls : IConnect
    {
        // public static Clientcls _client;
        public static Networking _security;
        string ipv4;

        public string clientName
        {
            get
            {
                return clientName;
            }
        }

        public ConnTypes conntype
        {
            get
            {
                return conntype;
            }
        }

        public string Server
        {
            get
            {
                //return ipv4 = Servercls.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Ethernet);
                return ipv4 = Servercls.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            }
        }

        public string Typeuser
        {
            get
            {
                return Typeuser;
            }
        }

        public string ServerPort
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ChangePassword(string uname, string oldpassword, string newpassword)
        {
           
        }

        public void database(string connectionstring, Client.Types type)
        {
           
        }

        public bool IsConnected(bool client)
        {
            return client;
        }

        public bool IsDisconnected(string client)
        {
            return true;
        }

        public bool IsRegistered(string Name)
        {
            return true;
        }

        public bool IsServerisdown(string server)
        {
            return true;
        }

        public bool IsVisible(string uname)
        {
            return true;
        }

        public void statusMessage(string message, string uname)
        {
            throw new NotImplementedException();
        }

       
        public static string GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties adapterProperties = item.GetIPProperties();

                    if (adapterProperties.GatewayAddresses.FirstOrDefault() != null)
                    {
                        foreach (UnicastIPAddressInformation ip in adapterProperties.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                output = ip.Address.ToString();
                            }
                        }
                    }
                }
            }

            return output;
        }

        //public X509Certificate cert = new X509Certificate(_security.file , _security.pass);
        



    }
}
