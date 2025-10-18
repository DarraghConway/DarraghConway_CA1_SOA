namespace DarraghConway_CA1.Client.Services;

using System.Net.Http.Json;
using DarraghConway_CA1.Client.Models;

public class CryptoPanicService
{
    private readonly HttpClient _http;
    private const string _apiToken = "0fdb0be37c67680dad10365003e8d1b7c7bb4430"; // your CryptoPanic API key

    public CryptoPanicService(HttpClient http) => _http = http;

    public async Task<List<CryptoPanicPost>> GetPostsForSymbolAsync(string symbol)
    {
        var url = $"https://cryptopanic.com/api/developer/v2/posts/?auth_token={_apiToken}&currencies={symbol}";
        var opts = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var res = await _http.GetFromJsonAsync<CryptoPanicResponse>(url, opts);
        return res?.Results ?? new();
    }


}