using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChitChatAPI;
using ChitChatAPI.Enums;
using ChitChatClient.Utils;
namespace ChitChatClient.Utils
{
   public class Client_Chat : IConnect
    {
        bool Logged = false;
        Settings _settings = new Settings();
        string serverip;
        private string serverPort;

        public Client_Chat(string serverIp)
        {
            serverip = serverIp;
        }

        public Client_Chat(string serverIp, string serverPort)
        {
            serverip = serverIp;
            this.serverPort = serverPort;
        }

        public string clientName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ConnTypes conntype
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Server
        {
            get
            {
                return serverip;
            }
        }

        public string Typeuser
        {
            get
            {
                return "Client";
            }
        }

        public string ServerPort
        {
            get
            {
                return serverPort;
            }
        }

        public void ChangePassword(string uname, string oldpassword, string newpassword)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected(bool client)
        {
           return Logged;
        }

        public bool IsDisconnected(string client)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(string Name)
        {
            throw new NotImplementedException();
        }

        public bool IsServerisdown(string server)
        {
            throw new NotImplementedException();
        }

        public bool IsVisible(string uname)
        {
            throw new NotImplementedException();
        }

        public void statusMessage(string message, string uname)
        {
            throw new NotImplementedException();
        }
    }
    
}
