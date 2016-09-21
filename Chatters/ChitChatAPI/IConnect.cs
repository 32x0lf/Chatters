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
        int ServerPort { get; }
        string clientName { get; }
        string clientPass { get; }
        bool IsConnected(bool client);
        bool IsDisconnected(string client);
        bool IsServerisdown(string server);
        bool IsRegistered { get; }
        bool IsVisible(string uname);
        void statusMessage(string message, string uname);
        //void database(string connectionstring,  Client.Types type);
        void ChangePassword(string uname, string oldpassword, string newpassword);
        string Typeuser{ get;}
    } 
  
}
