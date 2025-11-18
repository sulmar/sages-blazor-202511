using BlazorApp;
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

builder.Services.AddTransient<ICustomerRepository, InMemoryCustomerRepository>();
builder.Services.AddTransient<Faker<Customer>, CustomerFaker>();

builder.Services.AddTransient<IEnumerable<Customer>>(sp =>
{
    return sp.GetRequiredService<Faker<Customer>>().Generate(100);
});

builder.Services.AddTransient<IProductRepository, InMemoryProductRepository>();
builder.Services.AddTransient<Faker<Product>, ProductFaker>();

builder.Services.AddTransient<IEnumerable<Product>>(sp =>
{
    return sp.GetRequiredService<Faker<Product>>().Generate(100);
});


await builder.Build().RunAsync();
