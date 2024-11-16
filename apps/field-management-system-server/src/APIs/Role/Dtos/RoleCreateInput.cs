namespace FieldManagementSystem.APIs.Dtos;

public class RoleCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Id { get; set; }

    public string? RoleName { get; set; }

    public DateTime UpdatedAt { get; set; }
}
