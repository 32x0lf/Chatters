using System;
using ChitChatAPI.Enums;
using ChitChatAPI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace ChitChatAPI
{

    public class Client
    {
        public const int IM_Hello = 2012;      // Hello
        public const byte IM_OK = 0;           // OK
        public const byte IM_Login = 1;        // Login
        public const byte IM_Register = 2;     // Register
        public const byte IM_TooUsername = 3;  // Too long username
        public const byte IM_TooPassword = 4;  // Too long password
        public const byte IM_Exists = 5;       // Already exists
        public const byte IM_NoExists = 6;     // Doesn't exists
        public const byte IM_WrongPass = 7;    // Wrong password
        public const byte IM_IsAvailable = 8;  // Is user available?
        public const byte IM_Send = 9;         // Send message
        public const byte IM_Received = 10;    // Message received
        public const byte IM_LoggedIn = 11;    // Logged In
        public const byte IM_SomeoneLoggedIn = 12;

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

      
        public string filename{ get; set; }
        public string filepass{ get; set; }

        
        
    }

 
}
