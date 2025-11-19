namespace YandexOAuthClient;

public record TokenSet
{
    public required string TokenType { get; init; }
    public required string AccessToken { get; init; }
    public required string? RefreshToken { get; init; }
    public required DateTimeOffset ExpiresAt { get; init; }
    public required string Scope { get; init; }
}
