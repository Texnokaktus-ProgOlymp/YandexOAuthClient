using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient;

internal class AuthService<TKey>(ITokenStorage<TKey> tokenStorage, IOAuthClient oAuthClient, TimeProvider timeProvider) : IAuthService<TKey>
{
    public string GetOAuthUrl(string? redirectUrl) => oAuthClient.GetOAuthUri(redirectUrl).ToString();

    public async Task<string> AuthorizeAsync(TKey key, string authCode)
    {
        var tokenResponse = await oAuthClient.GetAccessTokenAsync(authCode);
        var tokenSet = GetTokenSet(tokenResponse, timeProvider.GetUtcNow());
        await tokenStorage.StoreAccessTokenAsync(key, tokenSet);

        return tokenSet.AccessToken;
    }

    public async Task<string?> GetAccessTokenAsync(TKey key)
    {
        if (await tokenStorage.GetAccessTokenAsync(key) is not { } tokenSet)
            return null;

        var now = timeProvider.GetUtcNow();

        if (now >= tokenSet.ExpiresAt)
            return await RefreshTokenAsync(key, tokenSet);

        return tokenSet.AccessToken;
    }

    private async Task<string?> RefreshTokenAsync(TKey key, TokenSet tokenSet)
    {
        if (tokenSet.RefreshToken is null)
            return null;

        var tokenResponse = await oAuthClient.RefreshAccessTokenAsync(tokenSet.RefreshToken);
        var newSet = GetTokenSet(tokenResponse, timeProvider.GetUtcNow());
        await tokenStorage.StoreAccessTokenAsync(key, newSet);

        return newSet.AccessToken;
    }

    private static TokenSet GetTokenSet(TokenResponse tokenResponse, DateTimeOffset now) =>
        new()
        {
            TokenType = tokenResponse.TokenType,
            AccessToken = tokenResponse.AccessToken,
            RefreshToken = tokenResponse.RefreshToken,
            ExpiresAt = now.AddSeconds(tokenResponse.ExpiresIn),
            Scope = tokenResponse.Scope
        };
}
