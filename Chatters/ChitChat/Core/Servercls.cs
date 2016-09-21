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
        static bool contype = false;
        public static NetworkInterfaceType networktype {get;set;}

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
                  
                return ipv4 = contype ? GetLocalIPv4(NetworkInterfaceType.Wireless80211) : GetLocalIPv4(NetworkInterfaceType.Ethernet);                 
            }
        }

        public string Typeuser
        {
            get
            {
                return Typeuser;
            }
        }

        public int ServerPort
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

        public bool IsRegistered
        {
            get { return true; }
            
        }

        public string clientPass
        {
            get
            {
                throw new NotImplementedException();
            }
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

       
        public static string GetLocalIPv4(NetworkInterfaceType _type)
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
                    if (string.IsNullOrEmpty(output))
                    {
                        NetworkInterfaceType _type1 = NetworkInterfaceType.Wireless80211;
                        foreach (NetworkInterface item1 in NetworkInterface.GetAllNetworkInterfaces())
                        {
                            if (item1.NetworkInterfaceType == _type1 && item1.OperationalStatus == OperationalStatus.Up)
                            {
                                IPInterfaceProperties adapterProperties1 = item1.GetIPProperties();

                                if (adapterProperties1.GatewayAddresses.FirstOrDefault() != null)
                                {
                                    foreach (UnicastIPAddressInformation ip in adapterProperties1.UnicastAddresses)
                                    {
                                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                        {
                                            output = ip.Address.ToString();
                                            contype = true;
                                        }
                                    }
                                }
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
