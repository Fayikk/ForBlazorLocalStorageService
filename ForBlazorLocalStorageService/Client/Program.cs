using Blazored.LocalStorage;
using ForBlazorLocalStorageService.Client;
using ForBlazorLocalStorageService.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICartExampleService, CartExampleService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
