using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProductEntity
{
    [Key]
    public string Id { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }
}
