using DarraghConway_CA1.Client.Models;

namespace DarraghConway_CA1.Client.Services.Abstractions;

public interface IMarketDataService
{
    Task<List<CryptoListing>> GetLatestAsync(int limit = 20);
}