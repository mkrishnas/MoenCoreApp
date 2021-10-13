namespace API
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.ExceptionHandling;
    using System.Web.Http.Results;
    using API.Logging;

    public class GlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// ILoggerManager
        /// </summary>
        private readonly ILoggerManager logger;

        /// <summary>
        /// Global Exception Handler
        /// </summary>
        /// <param name="logger"></param>
        public GlobalExceptionHandler(ILoggerManager logger)
        {
            this.logger = (ILoggerManager)logger;
        }

        /// <summary>
        /// HandleAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            // Access Exception using context.Exception;
            string errorMessage = context.Exception.Message;
            this.logger.LogError(errorMessage);
            var response = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new
                {
                    Message = errorMessage,
                });
            response.Headers.Add("X-Error", errorMessage);
            context.Result = new ResponseMessageResult(response);
        }
    }
}
