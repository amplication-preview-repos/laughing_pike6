using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldManagementSystem.Infrastructure.Models;

[Table("CompanySites")]
public class CompanySiteDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? Owner { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
