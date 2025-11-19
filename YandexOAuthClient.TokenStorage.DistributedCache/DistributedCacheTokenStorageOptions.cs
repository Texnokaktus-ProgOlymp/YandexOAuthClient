namespace YandexOAuthClient.TokenStorage.DistributedCache;

public record DistributedCacheTokenStorageOptions
{
    public string? KeyPrefix { get; set; }
}
