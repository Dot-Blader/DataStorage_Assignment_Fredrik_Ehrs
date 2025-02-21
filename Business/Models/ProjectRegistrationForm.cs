using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models;

public class ProjectRegistrationForm
{
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string CustomerId { get; set; } = null!;

    public string StatusId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string ProductId { get; set; } = null!;
}
