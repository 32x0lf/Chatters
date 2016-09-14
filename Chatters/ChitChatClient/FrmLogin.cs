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
            txtport.Text = Properties.Settings.Default.Port;

            settings.ServerIp = txtserverip.Text;
            settings.ServerPort = txtport.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        //    settings.ServerIp = txtserverip.Text;
        //    settings.ServerPort = txtport.Text;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerIP = txtserverip.Text;
            Properties.Settings.Default.Port = txtport.Text;
            Properties.Settings.Default.Save();
            
            settings.ServerIp = Properties.Settings.Default.ServerIP;
            settings.ServerPort = Properties.Settings.Default.Port;
            Client_Chat c = new Client_Chat(settings.ServerIp, settings.ServerPort);
            _imclient.setupcon(c.Server, c.ServerPort);
                             
        }
    }
}
