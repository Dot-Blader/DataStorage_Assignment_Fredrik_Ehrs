using Azure.Core;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerEntity? Create(CustomerRegistrationForm form) => form == null ? null : new()
    {
        Id = Guid.NewGuid().ToString(),
        CustomerName = form.CustomerName
    };

    public static Customer? Create(CustomerEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName
    };

}
