using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Template
{
    public class HealthCheckExample : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using var request = new HttpClient();
            var response = await request.GetAsync("https://www.google.com/");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return HealthCheckResult.Healthy("Google is avaivable");
            }

            return HealthCheckResult.Unhealthy("Google is unavaivable");
        }
    }
}
