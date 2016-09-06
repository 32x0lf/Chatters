using System;
using ChitChatAPI;
using ChitChatAPI.Events;
using ChitChatAPI.Enums;
using ChitChatAPI.Helper;
using ChitChat.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ChitChat
{
    public partial class MainServer : Form
    {
        string ipv4;
        public IPAddress ip;
        public int port = 3268;
        public bool running;
        public TcpListener server;
       
        public MainServer()
        {
            InitializeComponent();
            
    }

        private void MainServer_Load(object sender, EventArgs e)
        {
            Servercls server = new Servercls();
            Event.OnMessageReceived += Events_onstatusmessage;
            Logger.SetLogger(new EventLogger(LogLevel.Info));

            
            //ipv4 = Servercls.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            //ip = IPAddress.Parse(ipv4);
            ip = IPAddress.Parse(server.Server);
            Logger.Write($"Click Start button to start server", LogLevel.Info, ConsoleColor.Magenta);

        }

        private void Events_onstatusmessage(object sender, Event.LogReceivedArgs e)
        {
            try
            {
                if (!this.IsHandleCreated)
                    return;
                this.Invoke((MethodInvoker)delegate () 
                {
                    ListViewItem lvi = new ListViewItem($"[{ DateTime.Now.ToString("HH:mm:ss")}]");
                    lvi.UseItemStyleForSubItems = true;
                    lvi.SubItems.Add(e.Message);
                    lvi.ForeColor = e.Color;
                    lvstatlog.Items.Add(lvi);
                    lvstatlog.EnsureVisible(lvstatlog.Items.Count - 1);
                    //lvstatlog.Items[lvstatlog.Items.Count - 1].EnsureVisible();
                });
            
            }
            catch(Exception ex)
            {
                Logger.Write(ex.Message, LogLevel.Error, ConsoleColor.Red);
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            if (btnstart.Text == "START")
            {
                Start();
            }
            else if (btnstart.Text == "STOP")
            {
                Stop();
            }
        }

        private void Stop()
        {
            btnstart.Text = "START";
            running = false;
            server.Stop();
            Logger.Write($"Server Stopped at {DateTime.Now}", LogLevel.Info, ConsoleColor.DarkRed);
        }

        private void Start()
        {
            btnstart.Text = "STOP";
            running = true;

            server = new TcpListener(ip, port);
            Logger.Write($"Listening to port: {port}", LogLevel.Info, ConsoleColor.Yellow);
            server.Start();
            Logger.Write($"Server Started", LogLevel.Info, ConsoleColor.Green);

            (new Thread(new ThreadStart(Listening))).Start();
        }

        void Listening()
        {
            Logger.Write($"Waiting for request", LogLevel.Info, ConsoleColor.DarkGray);
            while (running)
            {
                
                if (server.Pending())
                {
                    Logger.Write($"Found a pending request", LogLevel.Info, ConsoleColor.DarkCyan);
                    TcpClient tcp = server.AcceptTcpClient();
                    Clientcls _client = new Clientcls(this, tcp);
                }
                
            }
        }

    }
}
