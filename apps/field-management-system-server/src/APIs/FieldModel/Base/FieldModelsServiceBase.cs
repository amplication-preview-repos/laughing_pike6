using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using FieldManagementSystem.APIs.Extensions;
using FieldManagementSystem.Infrastructure;
using FieldManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldManagementSystem.APIs;

public abstract class FieldModelsServiceBase : IFieldModelsService
{
    protected readonly FieldManagementSystemDbContext _context;

    public FieldModelsServiceBase(FieldManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Field
    /// </summary>
    public async Task<FieldModel> CreateFieldModel(FieldModelCreateInput createDto)
    {
        var fieldModel = new FieldModelDbModel
        {
            Capacity = createDto.Capacity,
            CreatedAt = createDto.CreatedAt,
            Price = createDto.Price,
            ServicesAvailability = createDto.ServicesAvailability,
            SurfaceType = createDto.SurfaceType,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            fieldModel.Id = createDto.Id;
        }

        _context.FieldModels.Add(fieldModel);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<FieldModelDbModel>(fieldModel.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Field
    /// </summary>
    public async Task DeleteFieldModel(FieldModelWhereUniqueInput uniqueId)
    {
        var fieldModel = await _context.FieldModels.FindAsync(uniqueId.Id);
        if (fieldModel == null)
        {
            throw new NotFoundException();
        }

        _context.FieldModels.Remove(fieldModel);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Fields
    /// </summary>
    public async Task<List<FieldModel>> FieldModels(FieldModelFindManyArgs findManyArgs)
    {
        var fieldModels = await _context
            .FieldModels.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return fieldModels.ConvertAll(fieldModel => fieldModel.ToDto());
    }

    /// <summary>
    /// Meta data about Field records
    /// </summary>
    public async Task<MetadataDto> FieldModelsMeta(FieldModelFindManyArgs findManyArgs)
    {
        var count = await _context.FieldModels.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Field
    /// </summary>
    public async Task<FieldModel> FieldModel(FieldModelWhereUniqueInput uniqueId)
    {
        var fieldModels = await this.FieldModels(
            new FieldModelFindManyArgs { Where = new FieldModelWhereInput { Id = uniqueId.Id } }
        );
        var fieldModel = fieldModels.FirstOrDefault();
        if (fieldModel == null)
        {
            throw new NotFoundException();
        }

        return fieldModel;
    }

    /// <summary>
    /// Update one Field
    /// </summary>
    public async Task UpdateFieldModel(
        FieldModelWhereUniqueInput uniqueId,
        FieldModelUpdateInput updateDto
    )
    {
        var fieldModel = updateDto.ToModel(uniqueId);

        _context.Entry(fieldModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.FieldModels.Any(e => e.Id == fieldModel.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
