using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace ChitChatAPI.Events
{
    public static class Event
    {
        public static event MessageHandler OnMessageReceived;
        public delegate void MessageHandler(object sender, LogReceivedArgs e);


        public static async void Log(string sender, string message, Color color)
        {
            
               OnMessageReceived(null, new LogReceivedArgs() { Sender = sender, Message = message, Color = color });                              
          
        }

        public class LogReceivedArgs : EventArgs
        {
            public string Sender;
            public string Message;
            public Color Color;
        }
    }
}
