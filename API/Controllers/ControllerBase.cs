using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private ILogger<ControllerBase> _logger = null;

        public ControllerBase(ILogger<ControllerBase> logger)
        {
            _logger = logger;
        }

        protected ApiResponse CreateResponse(object data)
        {
            _logger.LogInformation("Logging Statred in Base");
            return new ApiResponse(data);
        }

        protected ApiErrorResponse CreateResponse(Exception ex)
        {
            _logger.LogError(Newtonsoft.Json.JsonConvert.SerializeObject(ex));
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
