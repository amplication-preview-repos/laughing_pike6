using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldManagementSystem.Infrastructure.Models;

[Table("FieldModels")]
public class FieldModelDbModel
{
    [Range(-999999999, 999999999)]
    public int? Capacity { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Range(-999999999, 999999999)]
    public double? Price { get; set; }

    public string? ServicesAvailability { get; set; }

    [StringLength(1000)]
    public string? SurfaceType { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
