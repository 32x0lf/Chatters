using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI
{
    public interface IConnect
    {
        void Server(string server);
        void clientName(string uname);
        bool IsConnected(string client);
        bool IsDisconnected(string client);
        bool IsServerisdown(string server);
        bool IsRegistered(string Name);
        bool IsVisible(string uname);
        void statusMessage(string message, string uname);
        void database(string connectionstring, Types type);
        void ChangePassword(string uname, string oldpassword, string newpassword);
        string Typeuser{ get; set; }
    }

   
    [Serializable]
    public class MessageReceived
    {
        string message;
        string sender;
        public MessageReceived(string message,string sender)
        {
            this.message = message;
            this.sender = sender;
        }
        public string Message { get { return message;  } }
        public string Sender { get { return sender; } }
    }
    
    public class Types
     {
        string type;
        public Types(string utype)
        {
            type = utype;
        }
        public enum user
        {
            server,
            client
        }
     }
   
  
}
