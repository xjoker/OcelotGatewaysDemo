using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace Gateways.Middleware
{
    public class PrintRequestIpToConsole
    {
        private readonly ILogger<PrintRequestIpToConsole> _logger;
        private readonly RequestDelegate _requestDelegate;

        public PrintRequestIpToConsole(RequestDelegate requestDelegate,
            ILogger<PrintRequestIpToConsole> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _requestDelegate(context);

            var printStr =
                $"IP:{context.Request.HttpContext.Connection.RemoteIpAddress} | RequestUrl:{context.Request.HttpContext.Request.GetDisplayUrl()}";

            _logger.LogDebug(printStr);

            //Console.WriteLine(printStr);
        }
    }
}