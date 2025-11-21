using YandexOAuthClient.Configuration;

namespace YandexOAuthClient.TokenStorage.Decorators.DataProtection;

public static class DiExtensions
{
    extension<TKey>(IYandexOAuthClientTokenStorageConfigurator<TKey> configurator)
    {
        public IYandexOAuthClientTokenStorageConfigurator<TKey> ProtectStorage() =>
            configurator.WithDecorator<EncryptedStorageDecorator<TKey>>();
    }
}
