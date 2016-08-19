using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChitChatAPI;
using ChitChatAPI.Enums;

namespace ChitChat.Core
{
    public class Servercls : IConnect
    {
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
                return Server;
            }
        }

        public string Typeuser
        {
            get
            {
                return Typeuser;
            }
        }

        public void ChangePassword(string uname, string oldpassword, string newpassword)
        {
           
        }

        public void database(string connectionstring, Client.Types type)
        {
           
        }

        public bool IsConnected(string client)
        {
            return true;
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
    }
}
