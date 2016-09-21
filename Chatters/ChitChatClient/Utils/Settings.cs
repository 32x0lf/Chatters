using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChitChatClient.Utils
{
    [Serializable]
    public partial class Settings
    {
        
        public string ServerIp { get; set; }
        public int ServerPort { get; set; }
        public string Uname { get; set; }
        public string Upass { get; set; }
        public bool IsReg { get; set; }
    }
}
