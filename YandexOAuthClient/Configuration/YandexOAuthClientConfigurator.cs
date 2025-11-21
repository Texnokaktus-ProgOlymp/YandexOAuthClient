using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Configuration;

internal class YandexOAuthClientConfigurator<TKey>(IServiceCollection services) : IYandexOAuthClientConfigurator<TKey>
{
    public IServiceCollection Services => services;

    public IYandexOAuthClientConfigurator<TKey> WithTokenStorage<TTokenStorage>() where TTokenStorage : class, ITokenStorage<TKey>
    {
        services.AddScoped<ITokenStorage<TKey>, TTokenStorage>();
        return this;
    }

    public IYandexOAuthClientConfigurator<TKey> WithTokenStorage<TTokenStorage>(Func<IServiceProvider, TTokenStorage> implementationFactory) where TTokenStorage : class, ITokenStorage<TKey>
    {
        services.AddScoped<ITokenStorage<TKey>, TTokenStorage>(implementationFactory);
        return this;
    }

    public IYandexOAuthClientConfigurator<TKey> WithTokenStorage<TTokenStorage>(Action<IYandexOAuthClientTokenStorageConfigurator<TKey>> storageConfiguration) where TTokenStorage : class, ITokenStorage<TKey>
    {
        services.AddScoped<ITokenStorage<TKey>, TTokenStorage>();
        storageConfiguration.Invoke(new YandexOAuthClientTokenStorageConfigurator<TKey>(services));
        return this;
    }

    public IYandexOAuthClientConfigurator<TKey> WithTokenStorage<TTokenStorage>(Func<IServiceProvider, TTokenStorage> implementationFactory, Action<IYandexOAuthClientTokenStorageConfigurator<TKey>> storageConfiguration) where TTokenStorage : class, ITokenStorage<TKey>
    {
        services.AddScoped<ITokenStorage<TKey>, TTokenStorage>(implementationFactory);
        storageConfiguration.Invoke(new YandexOAuthClientTokenStorageConfigurator<TKey>(services));
        return this;
    }
}
