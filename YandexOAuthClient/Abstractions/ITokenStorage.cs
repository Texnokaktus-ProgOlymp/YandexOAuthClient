namespace YandexOAuthClient.Abstractions;

public interface ITokenStorage
{
    Task StoreAccessTokenAsync(string key, TokenSet tokenSet);
    Task<TokenSet?> GetAccessTokenAsync(string key);
}
