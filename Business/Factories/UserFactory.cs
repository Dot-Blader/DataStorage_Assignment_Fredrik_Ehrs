using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class UserFactory
{
    public static int id = 0;
    public static int IdGenerator()
    {
        id++;
        return id;
    }
    public static UserEntity? Create(UserRegistrationForm form) => form == null ? null : new()
    {
        Id = IdGenerator(),
        FirstName = form.FirstName,
        LastName = form.LastName
    };

    public static User? Create(UserEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName
    };
}
