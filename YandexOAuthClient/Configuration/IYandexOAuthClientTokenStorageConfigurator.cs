using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Configuration;

public interface IYandexOAuthClientTokenStorageConfigurator
{
    IYandexOAuthClientTokenStorageConfigurator WithDecorator<TDecorator>() where TDecorator : class, ITokenStorage;
}
