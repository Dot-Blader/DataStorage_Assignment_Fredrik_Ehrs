using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusTypeFactory
{
    public static int id = 0;
    public static int IdGenerator()
    {
        id++;
        return id;
    }
    public static StatusTypeEntity? Create(StatusTypeRegForm form) => form == null ? null : new()
    {
        Id = IdGenerator(),
        StatusName = form.StatusName
    };
    public static StatusType? Create(StatusTypeEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };
}
