using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Abstractions;
using YandexOAuthClient.Configuration;

namespace YandexOAuthClient;

public static class DiExtensions
{
    extension(IServiceCollection services)
    {
        public IYandexOAuthClientConfigurator<TKey> AddOAuthClient<TKey>(string configSection = nameof(YandexAppParameters))
        {
            services.AddHttpClient<IOAuthClient, OAuthClient>(client => client.BaseAddress = new("https://oauth.yandex.ru"));

            services.AddOptions<YandexAppParameters>().BindConfiguration(configSection);

            services.AddScoped<IAuthService<TKey>, AuthService<TKey>>();

            return new YandexOAuthClientConfigurator<TKey>(services);
        }
    }
}
