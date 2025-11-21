using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Abstractions;
using YandexOAuthClient.Configuration;

namespace YandexOAuthClient;

public static class DiExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddOAuthClient(string configSection = nameof(YandexAppParameters))
        {
            services.AddHttpClient<IOAuthClient, OAuthClient>(client => client.BaseAddress = new("https://oauth.yandex.ru"));

            services.AddOptions<YandexAppParameters>().BindConfiguration(configSection);

            return services.AddScoped<IAuthService, AuthService>();
        }
        
        public IYandexOAuthClientConfigurator<TKey> AddStoredOAuthClient<TKey>(string configSection = nameof(YandexAppParameters))
        {
            services.AddHttpClient<IOAuthClient, OAuthClient>(client => client.BaseAddress = new("https://oauth.yandex.ru"));

            services.AddOptions<YandexAppParameters>().BindConfiguration(configSection);

            services.AddScoped<IStoredAuthService<TKey>, StoredAuthService<TKey>>();

            return new YandexOAuthClientConfigurator<TKey>(services);
        }
    }
}
