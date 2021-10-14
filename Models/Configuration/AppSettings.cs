using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Configuration
{
    public class JWT
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string Secret { get; set; }
    }
}
