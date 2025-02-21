using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public string Id { get; set; } = null!;

    public string CustomerName { get; set; } = null!;
}
