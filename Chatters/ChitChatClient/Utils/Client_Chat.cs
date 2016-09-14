using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChitChatAPI;
using ChitChatAPI.Enums;

namespace ChitChatClient.Utils
{
    class Client_Chat : IConnect
    {
        bool Logged = false;
        
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
                return null;
            }
        }

        public string Typeuser
        {
            get
            {
                return "Client";
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
