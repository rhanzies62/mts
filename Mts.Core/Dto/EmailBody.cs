using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto
{
    public class EmailBody
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
    }
}
