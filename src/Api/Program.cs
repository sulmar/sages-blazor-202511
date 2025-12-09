using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure.Fakers;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    // policy.AllowAnyOrigin();
    policy.WithOrigins("https://localhost:7285");
    // policy.AllowAnyMethod();
    policy.WithOrigins("GET");

    policy.AllowAnyHeader();

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();


app.MapGet("/ping", () => "pong");

app.MapGet("api/customers", async (ICustomerRepository repository) => await repository.GetAllAsync());

app.Run();

