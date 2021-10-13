namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ApiErrorResponse : ApiResponse
    {
        public ApiErrorResponse(Exception ex)
        {
            this.Exception = ex;
            this.Error = ex.Message;
        }

        /// <inheritdoc/>
        public override bool OK => false;

        /// <inheritdoc/>
        public override string Status => "500";

        /// <inheritdoc/>
        public override string StatusText => "Error";

        public string Error { get; set; }

        public Exception Exception { get; set; }
    }
}