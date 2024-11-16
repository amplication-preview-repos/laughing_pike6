using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class RolesExtensions
{
    public static Role ToDto(this RoleDbModel model)
    {
        return new Role
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            RoleName = model.RoleName,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RoleDbModel ToModel(this RoleUpdateInput updateDto, RoleWhereUniqueInput uniqueId)
    {
        var role = new RoleDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            RoleName = updateDto.RoleName
        };

        if (updateDto.CreatedAt != null)
        {
            role.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            role.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return role;
    }
}
