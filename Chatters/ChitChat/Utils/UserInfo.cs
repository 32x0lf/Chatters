using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChitChatAPI;
using ChitChat.Core;

namespace ChitChat.Utils
{
    public class UserInfo
    {
        bool clientinfo;
        public Clientcls _connection;
        public bool loggedin;
        public UserInfo(Clientcls Connection,bool LoggedIn)
        {
            this._connection = Connection;
            this.loggedin = LoggedIn;
            
        }

        public bool GetUser(string name,string password)
        {
            try
            {
                using (var ent = new ServerEntities())
                {
                    var query = (from ui in ent.Client_Info
                                 where ui.Client_Uname == name && ui.Client_Upass == password
                                 select ui).FirstOrDefault<Client_Info>();

                    this.clientinfo = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message, ChitChatAPI.Enums.LogLevel.Error, ConsoleColor.Red);
                
            }
            return clientinfo;
        }

    }
}
