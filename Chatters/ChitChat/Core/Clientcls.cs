using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Threading;
using ChitChatAPI;
using ChitChat.Utils;
using System.Security.Cryptography.X509Certificates;
using ChitChat.Network;

namespace ChitChat.Core
{
    public class Clientcls
    {
        MainServer ms;
        public TcpClient client;
        public NetworkStream netstream;
        public SslStream sslstream;
        public BinaryReader br;
        public BinaryWriter bw;
        Networking _security = new Networking();
        UserInfo user;


        //public X509Certificate cert = new X509Certificate(_security., _security.pass);
        public Clientcls(MainServer main, TcpClient tc)
        {
            ms = main;
            client = tc;

            (new Thread(new ThreadStart(SetConn))).Start();
        }

        void SetConn()
        {

           
            try
            {
                Logger.Write($"New Connection Created!", ChitChatAPI.Enums.LogLevel.Info, ConsoleColor.Magenta);
                netstream = client.GetStream();
                sslstream = new SslStream(netstream, false);
                sslstream.AuthenticateAsServer(_security.cert, false, SslProtocols.Tls, true);
                Logger.Write($"Connection is now authenticated!", ChitChatAPI.Enums.LogLevel.Info, ConsoleColor.Green);
                br = new BinaryReader(sslstream, Encoding.UTF8);
                bw = new BinaryWriter(sslstream, Encoding.UTF8);

                bw.Write(Client.IM_Hello);
                bw.Flush();

                int Init = br.ReadInt32();
                if (Init == Client.IM_Hello)
                {
                    byte mode = br.ReadByte();
                    string username = br.ReadString();
                    string password = br.ReadString();
                    if (mode == Client.IM_Login)
                    {
                        user = new UserInfo(this, true);
                        if (user.GetUser(username))
                        {

                            if (user.CheckPassword(username, password))
                            {
                                //Check if the user Logged In.
                                user._connection = this;
                                if (!user._Details(username))
                                {
                                    user.UpdateLogged(username);
                                }
                                //If connected..DisConnect the user.
                                else
                                {
                                    bw.Write(Client.IM_SomeoneLoggedIn);
                                    user._connection.CloseConn();
                                    user.Deactivate(username);
                                    return;
                                }

                                user._connection = this;
                                bw.Write(Client.IM_OK);
                                bw.Flush();
                            }
                            else
                            {
                                bw.Write(Client.IM_WrongPass);
                            }
                        }
                        else
                        {
                            bw.Write(Client.IM_NoExists);
                        }
                    }
                    else if (mode == Client.IM_Register)
                    {
                        //Register
                    }

                }
            }
            catch (IOException ex)
            {

                Logger.Write(ex.Message, ChitChatAPI.Enums.LogLevel.Error, ConsoleColor.Red);
            }
        }



        void CloseConn() // Close connection.
        {
            try
            {
                int a = br.PeekChar() + 1;
                user.Logged = false;
                br.Close();
                bw.Close();
                sslstream.Close();
                netstream.Close();
                client.Close();
                Logger.Write($"{DateTime.Now} End of connection", ChitChatAPI.Enums.LogLevel.Info, ConsoleColor.Yellow);

            }
            catch (IOException e)
            { Logger.Write(e.Message, ChitChatAPI.Enums.LogLevel.Error, ConsoleColor.Red); }
        }

    }
}
