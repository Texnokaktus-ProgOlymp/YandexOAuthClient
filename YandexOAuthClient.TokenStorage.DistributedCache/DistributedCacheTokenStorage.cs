using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient.TokenStorage.DistributedCache;

internal class DistributedCacheTokenStorage(IDistributedCache cache, IOptions<DistributedCacheTokenStorageOptions> options) : ITokenStorage<string>
{
    private string GetCacheKey(string tokenKey) =>
        options.Value.KeyPrefix is { } keyPrefix
            ? $"{keyPrefix}:OAuth:Yandex:{tokenKey}"
            : $"OAuth:Yandex:{tokenKey}";

    public Task StoreAccessTokenAsync(string key, TokenSet tokenSet) =>
        cache.SetStringAsync(GetCacheKey(key), JsonSerializer.Serialize(tokenSet));

    public async Task<TokenSet?> GetAccessTokenAsync(string key)
    {
        if (await cache.GetStringAsync(GetCacheKey(key)) is not { } payloadString)
            return null;

        try
        {
            return JsonSerializer.Deserialize<TokenSet>(payloadString);
        }
        catch
        {
            return null;
        }
    }
}
