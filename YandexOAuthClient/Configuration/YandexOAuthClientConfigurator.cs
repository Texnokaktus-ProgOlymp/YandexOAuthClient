using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.Configuration;

internal class YandexOAuthClientConfigurator(IServiceCollection services) : IYandexOAuthClientConfigurator
{
    public IServiceCollection Services => services;

    public IYandexOAuthClientConfigurator WithTokenStorage<TTokenStorage>() where TTokenStorage : class, ITokenStorage
    {
        services.AddScoped<ITokenStorage, TTokenStorage>();
        return this;
    }

    public IYandexOAuthClientConfigurator WithTokenStorage<TTokenStorage>(Func<IServiceProvider, TTokenStorage> implementationFactory) where TTokenStorage : class, ITokenStorage
    {
        services.AddScoped<ITokenStorage, TTokenStorage>(implementationFactory);
        return this;
    }

    public IYandexOAuthClientConfigurator WithTokenStorage<TTokenStorage>(Action<IYandexOAuthClientTokenStorageConfigurator> storageConfiguration) where TTokenStorage : class, ITokenStorage
    {
        services.AddScoped<ITokenStorage, TTokenStorage>();
        storageConfiguration.Invoke(new YandexOAuthClientTokenStorageConfigurator(services));
        return this;
    }

    public IYandexOAuthClientConfigurator WithTokenStorage<TTokenStorage>(Func<IServiceProvider, TTokenStorage> implementationFactory, Action<IYandexOAuthClientTokenStorageConfigurator> storageConfiguration) where TTokenStorage : class, ITokenStorage
    {
        services.AddScoped<ITokenStorage, TTokenStorage>(implementationFactory);
        storageConfiguration.Invoke(new YandexOAuthClientTokenStorageConfigurator(services));
        return this;
    }
}
