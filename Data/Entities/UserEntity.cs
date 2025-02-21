using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class UserEntity
{
    [Key]
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
