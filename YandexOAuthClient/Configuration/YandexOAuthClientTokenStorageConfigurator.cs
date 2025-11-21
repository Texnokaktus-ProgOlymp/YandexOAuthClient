using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Configuration;

internal class YandexOAuthClientTokenStorageConfigurator<TKey>(IServiceCollection services) : IYandexOAuthClientTokenStorageConfigurator<TKey>
{
    public IYandexOAuthClientTokenStorageConfigurator<TKey> WithDecorator<TDecorator>() where TDecorator : class, ITokenStorage<TKey>
    {
        services.Decorate<ITokenStorage<TKey>, TDecorator>();
        return this;
    }
}
