using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Configuration;

internal class YandexOAuthClientTokenStorageConfigurator(IServiceCollection services) : IYandexOAuthClientTokenStorageConfigurator
{
    public IYandexOAuthClientTokenStorageConfigurator WithDecorator<TDecorator>() where TDecorator : class, ITokenStorage
    {
        services.Decorate<ITokenStorage, TDecorator>();
        return this;
    }
}
