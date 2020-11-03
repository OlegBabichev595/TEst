using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Formatting.Compact;

namespace Template.Configs
{
    public class LogConfig
    {
        public static void Configure()
        {
           
        }

        public static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
         
            diagnosticContext.Set("RequestScheme", httpContext.Request.Host.Value);
            diagnosticContext.Set("Headers", httpContext.Request.Scheme);
     
        } 
    }

}
