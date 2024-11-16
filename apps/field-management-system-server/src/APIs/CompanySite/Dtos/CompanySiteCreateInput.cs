namespace FieldManagementSystem.APIs.Dtos;

public class CompanySiteCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Owner { get; set; }

    public DateTime UpdatedAt { get; set; }
}
