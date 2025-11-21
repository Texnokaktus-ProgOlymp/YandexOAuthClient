using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Configuration;

public interface IYandexOAuthClientTokenStorageConfigurator<out TKey>
{
    IYandexOAuthClientTokenStorageConfigurator<TKey> WithDecorator<TDecorator>() where TDecorator : class, ITokenStorage<TKey>;
}
