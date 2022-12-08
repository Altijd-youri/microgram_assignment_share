using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microgram.Frontend;
using Microgram.Frontend.Core.Repository;
using Microgram.Frontend.Infrastructure.Repository;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

builder.Services.AddSingleton<IPhotoRepository>(new PhotoBackendRepository("https://localhost:7012/api"));

await builder.Build().RunAsync();