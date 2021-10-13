namespace API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http.Filters;
    using API.Controllers;
    using API.Logging;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// Global Exception Filter
    /// </summary>
    public class GlobalExceptionFilter : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {
        /// <summary>
        /// ILoggerManager
        /// </summary>
        private readonly ILoggerManager logger;

        /// <summary>
        /// Global Exception Filter
        /// </summary>
        /// <param name="logger"></param>
        public GlobalExceptionFilter(ILoggerManager logger)
        {
            this.logger = (ILoggerManager)logger;
        }

        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var actionDescriptior = (ControllerActionDescriptor)context.ActionDescriptor;
            var conntrollerType = actionDescriptior.ControllerTypeInfo;

            var controllerBase = typeof(Controllers.ControllerBase);
            var controller = typeof(Controller);

            if (conntrollerType.IsSubclassOf(controllerBase) && !conntrollerType.IsSubclassOf(controller))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.HttpContext.Response.ContentType = "application/json";

                this.logger.LogError($"Application thrown error: {context.Exception.Message}");
                context.Result = new JsonResult(context.Exception.Message);
            }

            base.OnException(context);
        }
    }
}
