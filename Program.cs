using DarraghConway_CA1.Client.Services;
using DarraghConway_CA1.Components;

var builder = WebApplication.CreateBuilder(args);

// Razor components – using Server interactivity only
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Typed HttpClients for your services
builder.Services.AddHttpClient<CoinMarketCapService>();
builder.Services.AddHttpClient<CryptoPanicService>();  // <-- change this line

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