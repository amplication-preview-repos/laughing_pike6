using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class LocationsExtensions
{
    public static Location ToDto(this LocationDbModel model)
    {
        return new Location
        {
            City = model.City,
            Country = model.Country,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            State = model.State,
            TimeZone = model.TimeZone,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LocationDbModel ToModel(
        this LocationUpdateInput updateDto,
        LocationWhereUniqueInput uniqueId
    )
    {
        var location = new LocationDbModel
        {
            Id = uniqueId.Id,
            City = updateDto.City,
            Country = updateDto.Country,
            State = updateDto.State,
            TimeZone = updateDto.TimeZone
        };

        if (updateDto.CreatedAt != null)
        {
            location.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            location.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return location;
    }
}
