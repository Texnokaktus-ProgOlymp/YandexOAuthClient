using System.Text.Json.Serialization;

namespace YandexOAuthClient;

internal record TokenResponse
{
    [JsonPropertyName("token_type")]
    public string TokenType { get; init; }

    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }

    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; init; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; init; }

    [JsonPropertyName("scope")]
    public string Scope { get; init; }
}
