using System;
using ChitChatAPI.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI
{
    public interface IConnect
    {
        ConnTypes conntype { get; }
        string Server { get; }
        string clientName { get; }
        bool IsConnected(string client);
        bool IsDisconnected(string client);
        bool IsServerisdown(string server);
        bool IsRegistered(string Name);
        bool IsVisible(string uname);
        void statusMessage(string message, string uname);
        void database(string connectionstring,  Client.Types type);
        void ChangePassword(string uname, string oldpassword, string newpassword);
        string Typeuser{ get;}
    } 
  
}
