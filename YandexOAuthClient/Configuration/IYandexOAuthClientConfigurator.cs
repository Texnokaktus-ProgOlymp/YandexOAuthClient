using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Configuration;

public interface IYandexOAuthClientConfigurator
{
    IServiceCollection Services { get; }
    IYandexOAuthClientConfigurator WithTokenStorage<TTokenStorage>() where TTokenStorage : class, ITokenStorage;
    IYandexOAuthClientConfigurator WithTokenStorage<TTokenStorage>(Action<IYandexOAuthClientTokenStorageConfigurator> storageConfiguration) where TTokenStorage : class, ITokenStorage;
}
