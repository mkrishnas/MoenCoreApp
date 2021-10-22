using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class EmailQueue
    {
        public int Id { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public int SentRetry { get; set; }
        public bool IsSent { get; set; }

    }
}
