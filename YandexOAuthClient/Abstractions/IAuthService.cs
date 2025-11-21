namespace YandexOAuthClient.Abstractions;

public interface IAuthService
{
    string GetOAuthUrl(string? redirectUrl);
    Task<string> AuthorizeAsync(string key, string authCode);
    Task<string?> GetAccessTokenAsync(string key);
}
