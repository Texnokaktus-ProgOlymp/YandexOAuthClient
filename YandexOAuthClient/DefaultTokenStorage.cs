using System.Collections.Concurrent;
using YandexOAuthClient.Abstractions;

namespace YandexOAuthClient;

internal class DefaultTokenStorage<TKey> : ITokenStorage<TKey>
{
    private static readonly ConcurrentDictionary<TKey, TokenSet> Storage = new();

    public Task StoreAccessTokenAsync(TKey key, TokenSet tokenSet)
    {
        Storage.AddOrUpdate(key, tokenSet, (_, _) => tokenSet);
        return Task.CompletedTask;
    }

    public Task<TokenSet?> GetAccessTokenAsync(TKey key) =>
        Storage.TryGetValue(key, out var value)
            ? Task.FromResult<TokenSet?>(value)
            : Task.FromResult<TokenSet?>(null);
}
