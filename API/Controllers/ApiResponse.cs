namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ApiResponse
    {
        public ApiResponse()
        {
        }

        public ApiResponse(object data)
        {
            this.Data = data;
        }

        public virtual bool OK => true;

        public virtual string Status => "200";

        public virtual string StatusText => "OK";

        public object Data { get; set; }
    }
}