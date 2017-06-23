using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMVunpack
{
    public class JSONSerializer
    {
        public bool hasEncryptedImages { get; set; }
        public bool hasEncryptedAudio { get; set; }
        public string encryptionKey { get; set; }
    }
}
