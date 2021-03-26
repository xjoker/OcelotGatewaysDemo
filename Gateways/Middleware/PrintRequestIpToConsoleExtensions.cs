using Microsoft.AspNetCore.Builder;

namespace Gateways.Middleware
{
    public static class PrintRequestIpToConsoleExtensions
    {
        public static IApplicationBuilder UsePrintRequestIpToConsole(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PrintRequestIpToConsole>();
        }
    }
}