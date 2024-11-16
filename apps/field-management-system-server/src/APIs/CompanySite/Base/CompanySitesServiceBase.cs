using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using FieldManagementSystem.APIs.Extensions;
using FieldManagementSystem.Infrastructure;
using FieldManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldManagementSystem.APIs;

public abstract class CompanySitesServiceBase : ICompanySitesService
{
    protected readonly FieldManagementSystemDbContext _context;

    public CompanySitesServiceBase(FieldManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one CompanySite
    /// </summary>
    public async Task<CompanySite> CreateCompanySite(CompanySiteCreateInput createDto)
    {
        var companySite = new CompanySiteDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Name = createDto.Name,
            Owner = createDto.Owner,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            companySite.Id = createDto.Id;
        }

        _context.CompanySites.Add(companySite);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CompanySiteDbModel>(companySite.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one CompanySite
    /// </summary>
    public async Task DeleteCompanySite(CompanySiteWhereUniqueInput uniqueId)
    {
        var companySite = await _context.CompanySites.FindAsync(uniqueId.Id);
        if (companySite == null)
        {
            throw new NotFoundException();
        }

        _context.CompanySites.Remove(companySite);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many CompanySites
    /// </summary>
    public async Task<List<CompanySite>> CompanySites(CompanySiteFindManyArgs findManyArgs)
    {
        var companySites = await _context
            .CompanySites.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return companySites.ConvertAll(companySite => companySite.ToDto());
    }

    /// <summary>
    /// Meta data about CompanySite records
    /// </summary>
    public async Task<MetadataDto> CompanySitesMeta(CompanySiteFindManyArgs findManyArgs)
    {
        var count = await _context.CompanySites.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one CompanySite
    /// </summary>
    public async Task<CompanySite> CompanySite(CompanySiteWhereUniqueInput uniqueId)
    {
        var companySites = await this.CompanySites(
            new CompanySiteFindManyArgs { Where = new CompanySiteWhereInput { Id = uniqueId.Id } }
        );
        var companySite = companySites.FirstOrDefault();
        if (companySite == null)
        {
            throw new NotFoundException();
        }

        return companySite;
    }

    /// <summary>
    /// Update one CompanySite
    /// </summary>
    public async Task UpdateCompanySite(
        CompanySiteWhereUniqueInput uniqueId,
        CompanySiteUpdateInput updateDto
    )
    {
        var companySite = updateDto.ToModel(uniqueId);

        _context.Entry(companySite).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.CompanySites.Any(e => e.Id == companySite.Id))
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
