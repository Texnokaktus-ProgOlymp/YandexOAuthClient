using System;
using Microsoft.Extensions.DependencyInjection;
using YandexOAuthClient.Configuration;

namespace YandexOAuthClient.TokenStorage.DistributedCache;

public static class DiExtensions
{
    extension(IYandexOAuthClientConfigurator<string> configurator)
    {
        public IYandexOAuthClientConfigurator<string> WithDistributedCacheStorage() =>
            configurator.WithTokenStorage<DistributedCacheTokenStorage>();

        public IYandexOAuthClientConfigurator<string> WithDistributedCacheStorage<TKey>(Action<DistributedCacheTokenStorageOptions> configureOptions)
        {
            configurator.Services.Configure(configureOptions);
            return configurator.WithTokenStorage<DistributedCacheTokenStorage>();
        }

        public IYandexOAuthClientConfigurator<string> WithDistributedCacheStorage(Action<IYandexOAuthClientTokenStorageConfigurator<string>> storageConfiguration) =>
            configurator.WithTokenStorage<DistributedCacheTokenStorage>(storageConfiguration);

        public IYandexOAuthClientConfigurator<string> WithDistributedCacheStorage(Action<DistributedCacheTokenStorageOptions> configureOptions, Action<IYandexOAuthClientTokenStorageConfigurator<string>> storageConfiguration)
        {
            configurator.Services.Configure(configureOptions);
            return configurator.WithTokenStorage<DistributedCacheTokenStorage>(storageConfiguration);
        }
    }
}
