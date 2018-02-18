using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto.Config
{
    public class AppSettingConfig
    {
        public string Url { get; set; }
        public string EncryptionKey { get; set; }
        public int MaxLoginErrorCount { get; set; }
    }
}
