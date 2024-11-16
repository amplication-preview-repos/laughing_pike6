using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class CompanySitesExtensions
{
    public static CompanySite ToDto(this CompanySiteDbModel model)
    {
        return new CompanySite
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            Owner = model.Owner,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CompanySiteDbModel ToModel(
        this CompanySiteUpdateInput updateDto,
        CompanySiteWhereUniqueInput uniqueId
    )
    {
        var companySite = new CompanySiteDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Name = updateDto.Name,
            Owner = updateDto.Owner
        };

        if (updateDto.CreatedAt != null)
        {
            companySite.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            companySite.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return companySite;
    }
}
