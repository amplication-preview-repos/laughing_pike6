using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class FieldModelsExtensions
{
    public static FieldModel ToDto(this FieldModelDbModel model)
    {
        return new FieldModel
        {
            Capacity = model.Capacity,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Price = model.Price,
            ServicesAvailability = model.ServicesAvailability,
            SurfaceType = model.SurfaceType,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FieldModelDbModel ToModel(
        this FieldModelUpdateInput updateDto,
        FieldModelWhereUniqueInput uniqueId
    )
    {
        var fieldModel = new FieldModelDbModel
        {
            Id = uniqueId.Id,
            Capacity = updateDto.Capacity,
            Price = updateDto.Price,
            ServicesAvailability = updateDto.ServicesAvailability,
            SurfaceType = updateDto.SurfaceType
        };

        if (updateDto.CreatedAt != null)
        {
            fieldModel.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            fieldModel.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return fieldModel;
    }
}
