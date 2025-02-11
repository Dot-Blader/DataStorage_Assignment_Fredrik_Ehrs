using Business.Services;
using System.ComponentModel.Design;

namespace Presentation;

public class MenuDialogs(CustomerService customerService)
{
    private readonly CustomerService _customerService = customerService;

    public async Task Menu()
    {
        while (true)
        {
            Console.WriteLine("1. Create Customer");
        }
    }
}
