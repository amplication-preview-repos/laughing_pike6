using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;

namespace FieldManagementSystem.APIs;

public interface IFieldModelsService
{
    /// <summary>
    /// Create one Field
    /// </summary>
    public Task<FieldModel> CreateFieldModel(FieldModelCreateInput fieldmodel);

    /// <summary>
    /// Delete one Field
    /// </summary>
    public Task DeleteFieldModel(FieldModelWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Fields
    /// </summary>
    public Task<List<FieldModel>> FieldModels(FieldModelFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Field records
    /// </summary>
    public Task<MetadataDto> FieldModelsMeta(FieldModelFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Field
    /// </summary>
    public Task<FieldModel> FieldModel(FieldModelWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Field
    /// </summary>
    public Task UpdateFieldModel(
        FieldModelWhereUniqueInput uniqueId,
        FieldModelUpdateInput updateDto
    );
}
