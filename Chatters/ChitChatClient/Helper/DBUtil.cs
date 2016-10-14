using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChitChatClient.Helper
{
    public class DBUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public DBUtil()
        {
            
        }

        public void DBPath(string path)
        {
            var appDatapath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), path);
            //var folder = Path.Combine(appDatapath, @"\Roaming\Test\");
            if (!Directory.Exists(appDatapath))
            {
                Directory.CreateDirectory(appDatapath);
            }
        }
      
    }
}
