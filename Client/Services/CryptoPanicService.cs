namespace DarraghConway_CA1.Client.Services;

using System.Net.Http.Json;
using DarraghConway_CA1.Client.Models;
using DarraghConway_CA1.Client.Services.Abstractions;

public class CryptoPanicService : ApiServiceBase, INewsService
{
    private const string _apiToken = "0fdb0be37c67680dad10365003e8d1b7c7bb4430";

    public CryptoPanicService(HttpClient http) : base(http) { }

    public async Task<List<CryptoPanicPost>> GetPostsForSymbolAsync(string symbol)
    {
        var url = $"https://cryptopanic.com/api/developer/v2/posts/?auth_token={_apiToken}&currencies={symbol}";
        var res = await GetJsonAsync<CryptoPanicResponse>(url);
        return res?.Results ?? new();
    }
}
