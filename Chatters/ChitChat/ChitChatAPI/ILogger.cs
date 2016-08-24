using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChitChatAPI.Enums;

namespace ChitChatAPI
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILogger
    {
        void Write(string message, LogLevel level = LogLevel.Info, ConsoleColor color = ConsoleColor.Black);
    }
    /// <summary>
    /// 
    /// </summary>
    public static class Logger
    {
        private static ILogger _logger;

        public static void SetLogger(ILogger logger)
        {
            _logger = logger;
            _logger.Write($"Initializing MyChat at time {DateTime.Now}...");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        /// <param name="color"></param>
      
        public static void Write(string message, LogLevel level = LogLevel.Info, ConsoleColor color = ConsoleColor.Black)
        {
            if (_logger == null)
                return;
            _logger.Write(message, level, color);
           
        }

     
    }
}
