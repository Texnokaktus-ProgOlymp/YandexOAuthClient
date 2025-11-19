using YandexOAuthClient.Configuration;

namespace YandexOAuthClient.TokenStorage.Decorators.DataProtection;

public static class DiExtensions
{
    extension(IYandexOAuthClientTokenStorageConfigurator configurator)
    {
        public IYandexOAuthClientTokenStorageConfigurator ProtectStorage() =>
            configurator.WithDecorator<EncryptedStorageDecorator>();
    }
}
