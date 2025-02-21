using Business.Models;
using Business.Services;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity? Create(ProjectRegistrationForm form) => form == null ? null : new()
    {
        Id = Guid.NewGuid().ToString(),
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
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        CustomerId = entity.CustomerId,
        StatusId = entity.StatusId,
        UserId = entity.UserId,
        ProductId = entity.ProductId
    };
}
