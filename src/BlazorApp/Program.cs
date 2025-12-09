using BlazorApp;
using BlazorApp.Handlers;
using BlazorApp.Services;
using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure.Fakers;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7039") });


builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<BearerTokenHandler>();

// dotnet add package Microsoft.Extensions.Http
builder.Services.AddHttpClient<ICustomerService, ApiCustomerService>(
    client => client.BaseAddress = new Uri("https://localhost:7039"))
    .AddHttpMessageHandler<BearerTokenHandler>();



await builder.Build().RunAsync();
