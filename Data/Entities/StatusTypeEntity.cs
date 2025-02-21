using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class StatusTypeEntity
{
    [Key]
    public string Id { get; set; } = null!;

    public string StatusName { get; set; } = null!;
}
