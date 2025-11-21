using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Diagnostics.HealthChecks;

internal class AuthenticationHealthCheck(IAuthService<string> tokenService, IOptions<AuthenticationHealthCheckOptions> options) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken) =>
            await tokenService.GetAccessTokenAsync(options.Value.DefaultTokenKey) != null
                ? HealthCheckResult.Healthy("Access token persists")
                : HealthCheckResult.Unhealthy("Application is unauthenticated");
}
