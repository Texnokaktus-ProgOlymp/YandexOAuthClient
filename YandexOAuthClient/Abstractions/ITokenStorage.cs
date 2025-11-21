namespace YandexOAuthClient.Abstractions;

public interface ITokenStorage<in TKey>
{
    Task StoreAccessTokenAsync(TKey key, TokenSet tokenSet);
    Task<TokenSet?> GetAccessTokenAsync(TKey key);
}
