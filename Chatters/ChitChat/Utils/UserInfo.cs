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
        public string _name;
        public string _pass;
        public bool clientinfo;
        [NonSerialized]
        public Clientcls _connection;
        [NonSerialized]
        public bool Logged;
        Servercls _server = new Servercls();
        private Clientcls clientcls;
        private bool v;

        public UserInfo()
        {

        }
        public UserInfo(string user, string pass, Clientcls Connection, bool LoggedIn)
        {
            this._connection = Connection;
            this.Logged = LoggedIn;
            _name = user;
            _pass = pass;
        }

        public UserInfo(Clientcls clientcls, bool v)
        {
            this.clientcls = clientcls;
            this.v = v;
        }

        public bool GetUser(string name)
        {
            try
            {
                using (var ent = new ServerEntities())
                {
                    var query = (from ui in ent.Client_Info
                                 where ui.Client_Uname == name
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
        public bool CheckPassword(string name, string password)
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
                             join cd in ent.Client_Details on ci.id equals cd.Client_Id
                             where ci.Client_Uname == username

                             select new
                             {
                                 cd.IsLogged
                             });

                foreach (var q in query)
                {
                    if (q.IsLogged == true)
                        s = true;
                }
            }

            return s;
        }

        public void UpdateLogged(string username)
        {
            try
            {
                using (var ent = new ServerEntities())
                {
                    var result = (from ci in ent.Client_Info
                                  join cd in ent.Client_Details on ci.id  equals cd.Client_Id
                                  where ci.Client_Uname == username
                                  select cd).FirstOrDefault< Client_Details>();
                    //if (result == null)
                    result.IsLogged = true;
                    
                    ent.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message, ChitChatAPI.Enums.LogLevel.Error, ConsoleColor.Red);

            }
        }

        public void Deactivate(string username)
        {
            try
            {
                using (var ent = new ServerEntities())
                {
                    var result = (from ci in ent.Client_Info
                                  join cd in ent.Client_Details on ci.id equals cd.Client_Id
                                  where ci.Client_Uname == username
                                  select cd).FirstOrDefault<Client_Details>();
                    //if (result == null)
                    result.IsLogged = false;

                    ent.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message, ChitChatAPI.Enums.LogLevel.Error, ConsoleColor.Red);

            }
        }

    }
}
