using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static int id = 0;
    public static int IdGenerator()
    {
        id++;
        return id;
    }
    public static ProjectEntity? Create(ProjectRegistrationForm form) => form == null ? null : new()
    {
        Id = IdGenerator(),
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        CustomerId = form.CustomerId,
        StatusId = form.StatusId,
        UserId = form.UserId,
        ProductId = form.ProductId
    };

    public static Project? Create(ProjectEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        Title = entity.Title
    };
}
