using BlazorApp;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddTransient<ICustomerRepository, InMemoryCustomerRepository>();

builder.Services.AddTransient<IEnumerable<Customer>>(sp =>
{
    return new List<Customer>
    {
        new Customer { Id = 1, Name = "Customer #1", Email = "john@domain.com" },
        new Customer { Id = 2, Name = "Customer #2", Email = "kate@domain.com" },
        new Customer { Id = 3, Name = "Customer #3", Email = "bart@domain.com" },
    };
});

await builder.Build().RunAsync();
