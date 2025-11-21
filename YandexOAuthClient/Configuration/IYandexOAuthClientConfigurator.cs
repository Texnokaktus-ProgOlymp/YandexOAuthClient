using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Configuration;

public interface IYandexOAuthClientConfigurator<TKey>
{
    IServiceCollection Services { get; }
    IYandexOAuthClientConfigurator<TKey> WithTokenStorage<TTokenStorage>() where TTokenStorage : class, ITokenStorage<TKey>;
    IYandexOAuthClientConfigurator<TKey> WithTokenStorage<TTokenStorage>(Func<IServiceProvider, TTokenStorage> implementationFactory) where TTokenStorage : class, ITokenStorage<TKey>;
    IYandexOAuthClientConfigurator<TKey> WithTokenStorage<TTokenStorage>(Action<IYandexOAuthClientTokenStorageConfigurator<TKey>> storageConfiguration) where TTokenStorage : class, ITokenStorage<TKey>;
    IYandexOAuthClientConfigurator<TKey> WithTokenStorage<TTokenStorage>(Func<IServiceProvider, TTokenStorage> implementationFactory, Action<IYandexOAuthClientTokenStorageConfigurator<TKey>> storageConfiguration) where TTokenStorage : class, ITokenStorage<TKey>;
}
