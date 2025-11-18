using Domain.Models;

namespace BlazorApp.Pages.Customers;

public partial class List
{
    private IEnumerable<Customer> customers = [];

    protected override async Task OnInitializedAsync()
    {
        customers = await Repository.GetAllAsync();
    }
}
