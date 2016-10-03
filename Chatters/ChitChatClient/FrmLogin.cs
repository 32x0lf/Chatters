using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChitChatClient.Utils;
using System.Threading;
using ChitChatAPI;
using ChitChatAPI.Events;
using ChitChatAPI.Enums;

namespace ChitChatClient
{
    
    public partial class FrmLogin : Form
    {
        Settings settings = new Settings();
        
        IMClient _imclient = new IMClient();
        public FrmLogin()
        {
            InitializeComponent();
            
            txtserverip.Text = Properties.Settings.Default.ServerIP;
            txtport.Text = Properties.Settings.Default.Port.ToString();
            txtusername.Text = Properties.Settings.Default.UserName;
            settings.ServerIp = txtserverip.Text;
            settings.ServerPort = int.Parse(txtport.Text);
            Event.OnMessageReceived += Events_onstatusmessage;
            Logger.SetLogger(new EventLogger(LogLevel.Info));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //Event.OnMessageReceived += Events_onstatusmessage;
            //Logger.SetLogger(new EventLogger(LogLevel.Info));
        }

        private void Events_onstatusmessage(object sender, Event.LogReceivedArgs e)
        {
            try
            {
                if (!this.IsHandleCreated)
                    return;
                this.Invoke((MethodInvoker)delegate ()
                {
                    lblstatus.Text = e.Message;
                   
                });
            }   
            catch { }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            Logger.Write("");
            Properties.Settings.Default.ServerIP = txtserverip.Text;
            Properties.Settings.Default.Port = int.Parse(txtport.Text);
            Properties.Settings.Default.UserName = txtusername.Text;
            Properties.Settings.Default.Save();

            settings.ServerIp = Properties.Settings.Default.ServerIP;
            settings.ServerPort = Properties.Settings.Default.Port;
            settings.Uname = Properties.Settings.Default.UserName;
            settings.Upass = txtpass.Text;
            Client_Chat c = new Client_Chat(settings.ServerIp, settings.ServerPort, settings.Uname, settings.Upass, true);
            Thread t1 = new Thread(() => _imclient.setupcon(c.Server, c.ServerPort, c.clientName, c.clientPass, c.IsRegistered));
            t1.Start();
           
        }

    }
}
