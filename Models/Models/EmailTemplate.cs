using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public string Template { get; set; }
        public string EmailType { get; set; }
        public string EmailSubject { get; set; }

    }
}
