using Azure.Core;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static int id = 0;
    public static int IdGenerator()
    {
        id++;
        return id;
    }
    public static CustomerEntity? Create(CustomerRegistrationForm form) => form == null ? null : new()
    {
        Id = IdGenerator(),
        CustomerName = form.CustomerName
    };

    public static Customer? Create(CustomerEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName
    };

}
