namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize]
    [ApiController]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private ILogger<ControllerBase> logger = null;

        public ControllerBase(ILogger<ControllerBase> logger)
        {
            this.logger = logger;
        }

        protected ApiResponse CreateResponse(object data)
        {
            this.logger.LogInformation("Logging Statred in Base");
            return new ApiResponse(data);
        }

        protected ApiErrorResponse CreateResponse(Exception ex)
        {
            this.logger.LogError(Newtonsoft.Json.JsonConvert.SerializeObject(ex));
            return new ApiErrorResponse(ex);
        }

        protected ApiErrorResponse CreateResponse(Exception ex, object data)
        {
            var e = new ApiErrorResponse(ex);
            e.Data = data;
            return e;
        }
    }
}
