using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ApiResponse
    {
        public virtual bool OK => true;
        public virtual string Status => "200";
        public virtual string StatusText => "OK";
        public object Data { get; set; }
        public ApiResponse()
        {

        }

        public ApiResponse(object data)
        {
            this.Data = data;
        }
    }

    public class ApiErrorResponse : ApiResponse
    {
        public override bool OK => false;
        public override string Status => "500";
        public override string StatusText => "Error";
        public string Error { get; set; }
        public Exception Exception { get; set; }

        public ApiErrorResponse(Exception ex)
        {
            this.Exception = ex;
            this.Error = ex.Message;
        }
    }
}

