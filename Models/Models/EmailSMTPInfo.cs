using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class EmailSMTPInfo
    {
        public int Id { get; set; }
        public string SMPTUserName { get; set; }
        public string SMTPPassword { get; set; }
        public string SMPTHost { get; set; }
        public int SMTPPort { get; set; }

    }
}
