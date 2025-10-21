using DarraghConway_CA1.Client.Services;
using DarraghConway_CA1.Client.Services.Abstractions;
using DarraghConway_CA1.Components;

var builder = WebApplication.CreateBuilder(args);

// Razor components – using Server interactivity only
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register typed clients against interfaces
builder.Services.AddHttpClient<IMarketDataService, CoinMarketCapService>();
builder.Services.AddHttpClient<INewsService, CryptoPanicService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();