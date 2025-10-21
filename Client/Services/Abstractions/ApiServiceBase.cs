using System.Net.Http.Json;
using System.Text.Json;

namespace DarraghConway_CA1.Client.Services.Abstractions;

public abstract class ApiServiceBase
{
    protected readonly HttpClient Http;

    protected ApiServiceBase(HttpClient http) => Http = http;
    
    protected static readonly JsonSerializerOptions Json = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public virtual async Task<bool> TestConnectionAsync(string? url = null)
    {
        try
        {
            var resp = await Http.GetAsync(url ?? "https://example.com");
            return resp.IsSuccessStatusCode;
        }
        catch { return false; }
    }
    protected Task<T?> GetJsonAsync<T>(string url, CancellationToken ct = default)
        => Http.GetFromJsonAsync<T>(url, Json, ct);
}