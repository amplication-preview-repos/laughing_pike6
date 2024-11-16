using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class TeamsExtensions
{
    public static Team ToDto(this TeamDbModel model)
    {
        return new Team
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TeamDbModel ToModel(this TeamUpdateInput updateDto, TeamWhereUniqueInput uniqueId)
    {
        var team = new TeamDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            team.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            team.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return team;
    }
}
