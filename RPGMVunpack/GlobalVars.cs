using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RPGMVunpack
{
    static class GlobalVars
    {
        public static string jsPath;
        public static string encryptionKey;
        public static bool _hasImg;
        public static bool _hasAudio;
        public static string helpPath = @"help.txt";
        public static string aboutPath = @"about.txt";
        public static Regex regex1 = new Regex(@"\*.rpgmvp", RegexOptions.IgnoreCase);
        public static Regex regex2 = new Regex(@"\*.rpgmvo", RegexOptions.IgnoreCase);
        public static string path = @"\Decrypted";
        public static byte[] bEncryptionKey;
    }
}
