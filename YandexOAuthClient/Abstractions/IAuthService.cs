namespace YandexOAuthClient.Abstractions;

public interface IAuthService
{
    string GetOAuthUrl(string? redirectUrl);
    Task<string> GetAccessTokenAsync(string authCode);
}
