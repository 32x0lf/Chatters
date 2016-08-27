using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChitChatAPI.Helper
{
    public static class Utils
    {
        public static Color ColorFromHex(string Hex)
        {
            return Color.FromArgb(Convert.ToInt32(long.Parse(string.Format("FFFFFFFFFF{0}", Hex.StartsWith("#") ? Hex.Substring(1) : Hex), System.Globalization.NumberStyles.HexNumber)));
        }

        public static Color ToColor(this string str)
        {
            return ColorFromHex(str);
        }
    }
}
