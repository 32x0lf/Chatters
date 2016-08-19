using System;
using ChitChatAPI.Enums;
using ChitChatAPI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI
{
    
    public class Client
    {
        [Serializable]
        public class MessageReceived
        {
            string message;
            string sender;
            public MessageReceived(string message, string sender)
            {
                this.message = message;
                this.sender = sender;
            }
            public string Message { get { return message; } }
            public string Sender { get { return sender; } }
        }

        public class Types
        {
            public void utypes(ConnTypes types)
            {
                return;
               
            }
        }
    }

 
}
