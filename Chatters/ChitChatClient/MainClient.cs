using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChitChatClient.Helper;
using System.IO;
using ServiceProvider;

namespace ChitChatClient
{
    public partial class MainClient : Form
    {
        
        static string path = $"Chatters\\{Properties.Settings.Default.UserName}";
        
        public MainClient()
        {
            InitializeComponent();
            DBUtil dbutil = new DBUtil();
            dbutil.DBPath(path);
            DbProvider _dbProvider = new DbProvider(path, "main.db");
            
            
        }

    }
}
