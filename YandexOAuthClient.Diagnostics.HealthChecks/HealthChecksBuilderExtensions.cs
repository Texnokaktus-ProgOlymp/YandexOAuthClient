using Microsoft.Extensions.DependencyInjection;

namespace YandexOAuthClient.Diagnostics.HealthChecks;

public static class HealthChecksBuilderExtensions
{
    public static IHealthChecksBuilder AddAuthenticationHealthCheck(this IHealthChecksBuilder healthChecksBuilder, Action<AuthenticationHealthCheckOptions> configureOptions)
    {
        healthChecksBuilder.Services.Configure(configureOptions);
        return healthChecksBuilder.AddCheck<AuthenticationHealthCheck>(nameof(AuthenticationHealthCheck));
    }
}
