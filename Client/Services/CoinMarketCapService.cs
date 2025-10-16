namespace DarraghConway_CA1.Client.Services;
using System.Net.Http.Json;
using DarraghConway_CA1.Client.Models;

public class CoinMarketCapService
{
    private readonly HttpClient _http;
    private readonly string _apiKey = "864c4110305a493895bb6f9c22ee13f2";

    public CoinMarketCapService(HttpClient http) => _http = http;

    public async Task<List<CryptoListing>> GetLatestAsync(int limit = 10)
    {
        var url = $"https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?start=1&limit=20&convert=USD";
        using var req = new HttpRequestMessage(HttpMethod.Get, url);
        req.Headers.Add("X-CMC_PRO_API_KEY", _apiKey);
        req.Headers.Add("Accept", "application/json");

        var resp = await _http.SendAsync(req);
        resp.EnsureSuccessStatusCode();

        var result = await resp.Content.ReadFromJsonAsync<CoinMarketCapResponse>();
        return result?.Data ?? new();
    }
}