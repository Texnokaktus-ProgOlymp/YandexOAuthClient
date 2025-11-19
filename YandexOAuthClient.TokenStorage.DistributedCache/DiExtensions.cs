using System;
using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Configuration;

namespace YandexOAuthClient.TokenStorage.DistributedCache;

public static class DiExtensions
{
    extension(IYandexOAuthClientConfigurator configurator)
    {
        public IYandexOAuthClientConfigurator WithDistributedCacheStorage() =>
            configurator.WithTokenStorage<DistributedCacheTokenStorage>();

        public IYandexOAuthClientConfigurator WithDistributedCacheStorage(Action<DistributedCacheTokenStorageOptions> configureOptions)
        {
            configurator.Services.Configure(configureOptions);
            return configurator.WithTokenStorage<DistributedCacheTokenStorage>();
        }

        public IYandexOAuthClientConfigurator WithDistributedCacheStorage(Action<IYandexOAuthClientTokenStorageConfigurator> storageConfiguration) =>
            configurator.WithTokenStorage<DistributedCacheTokenStorage>(storageConfiguration);

        public IYandexOAuthClientConfigurator WithDistributedCacheStorage(Action<DistributedCacheTokenStorageOptions> configureOptions, Action<IYandexOAuthClientTokenStorageConfigurator> storageConfiguration)
        {
            configurator.Services.Configure(configureOptions);
            return configurator.WithTokenStorage<DistributedCacheTokenStorage>(storageConfiguration);
        }
    }
}
