﻿using System;
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
        public static Networking _security;
        Servercls server = new Servercls();
        public Clientcls(MainServer main, TcpClient tc)
        {
            ms = main;
            client = tc;

            (new Thread(new ThreadStart(SetConn))).Start();
        }

        void SetConn()
        {
            
            // var cert = new Servercls();
            try
            {
                Logger.Write($"New Connection Created!", ChitChatAPI.Enums.LogLevel.Info, ConsoleColor.Magenta);
                netstream = client.GetStream();
                sslstream = new SslStream(netstream, false);
                sslstream.AuthenticateAsServer(cert, false, SslProtocols.Tls, true);
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
                        UserInfo user = new UserInfo(this, true);
                        if (user.GetUser(username,password))
                        {
                            //_userinfo._connection = this;
                              user._connection =this;

                            if (user._server.IsConnected(true))
                            {
                                
                            }
                            
                        }
                    }
                        
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public X509Certificate cert = new X509Certificate(_security.file, _security.pass);



    }
}
