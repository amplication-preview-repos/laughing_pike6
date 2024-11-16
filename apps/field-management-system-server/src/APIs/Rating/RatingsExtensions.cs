using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class RatingsExtensions
{
    public static Rating ToDto(this RatingDbModel model)
    {
        return new Rating
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RatingDbModel ToModel(
        this RatingUpdateInput updateDto,
        RatingWhereUniqueInput uniqueId
    )
    {
        var rating = new RatingDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            rating.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            rating.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return rating;
    }
}
