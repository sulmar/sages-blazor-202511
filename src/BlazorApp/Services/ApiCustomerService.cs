using Domain.Models;
using System.Diagnostics;
using System.Net.Http.Json;

namespace BlazorApp.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>?> GetAll();
}

// Primary Constructor
public class ApiCustomerService(HttpClient Http) : ICustomerService
{
    public Task<IEnumerable<Customer>?> GetAll() => Http.GetFromJsonAsync<IEnumerable<Customer>>("api/customers");
}
