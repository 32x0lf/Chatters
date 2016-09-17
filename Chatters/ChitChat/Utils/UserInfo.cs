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
        public bool clientinfo;
        public Clientcls _connection;
        public bool Logged;
        Servercls _server = new Servercls();

        public UserInfo()
        {

        }
        public UserInfo(Clientcls Connection, bool LoggedIn)
        {
            this._connection = Connection;
            this.Logged = LoggedIn;
        }

        public bool GetUser(string name, string password)
        {
            try
            {
                using (var ent = new ServerEntities())
                {
                    var query = (from ui in ent.Client_Info
                                 where ui.Client_Uname == name && ui.Client_Upass == password
                                 select ui).FirstOrDefault<Client_Info>();
                    if (query == null)
                        this.clientinfo = false;
                    else
                        this.clientinfo = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message, ChitChatAPI.Enums.LogLevel.Error, ConsoleColor.Red);

            }
            return clientinfo;
        }
        public bool _Details(string username)
        {
            bool s = false;
            using (var ent = new ServerEntities())
            {
                var query = (from ci in ent.Client_Info
                             join cd in ent.Client_Details on ci.id equals cd.Clien_Id
                             where ci.Client_Uname == username

                             select new
                             {
                                 cd.IsOnline
                             });

                foreach (var q in query)
                {
                    if (q.IsOnline == true)
                        s = true;
                }
            }

            return s;
        }

    }
}
