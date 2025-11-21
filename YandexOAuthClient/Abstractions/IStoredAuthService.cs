namespace YandexOAuthClient.Abstractions;

public interface IStoredAuthService<in TKey>
{
    string GetOAuthUrl(string? redirectUrl);
    Task<string> AuthorizeAsync(TKey key, string authCode);
    Task<string?> GetAccessTokenAsync(TKey key);
}
