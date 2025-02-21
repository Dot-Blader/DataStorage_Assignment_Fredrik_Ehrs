using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    public string CustomerId { get; set; } = null!;
    public CustomerEntity Customer { get; set; } = null!;

    public string StatusId { get; set; } = null!;
    public StatusTypeEntity Status { get; set; } = null!;

    public string UserId { get; set; } = null!;
    public UserEntity User { get; set; } = null!;

    public string ProductId { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
}