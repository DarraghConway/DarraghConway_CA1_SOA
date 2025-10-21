using DarraghConway_CA1.Client.Models;

namespace DarraghConway_CA1.Client.Services.Abstractions;

public interface INewsService
{
    Task<List<CryptoPanicPost>> GetPostsForSymbolAsync(string symbol);
}