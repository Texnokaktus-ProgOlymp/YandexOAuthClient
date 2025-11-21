using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient;

internal class AuthService(IOAuthClient oAuthClient) : IAuthService
{
    public string GetOAuthUrl(string? redirectUrl) => oAuthClient.GetOAuthUri(redirectUrl).ToString();

    public async Task<string> GetAccessTokenAsync(string authCode)
    {
        var tokenResponse = await oAuthClient.GetAccessTokenAsync(authCode);
        return tokenResponse.AccessToken;
    }
}
