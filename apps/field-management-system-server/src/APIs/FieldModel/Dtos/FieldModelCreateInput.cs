namespace FieldManagementSystem.APIs.Dtos;

public class FieldModelCreateInput
{
    public int? Capacity { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public double? Price { get; set; }

    public string? ServicesAvailability { get; set; }

    public string? SurfaceType { get; set; }

    public DateTime UpdatedAt { get; set; }
}
