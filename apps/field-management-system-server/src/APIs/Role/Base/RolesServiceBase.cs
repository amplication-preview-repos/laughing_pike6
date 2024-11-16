using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using FieldManagementSystem.APIs.Extensions;
using FieldManagementSystem.Infrastructure;
using FieldManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldManagementSystem.APIs;

public abstract class RolesServiceBase : IRolesService
{
    protected readonly FieldManagementSystemDbContext _context;

    public RolesServiceBase(FieldManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Role
    /// </summary>
    public async Task<Role> CreateRole(RoleCreateInput createDto)
    {
        var role = new RoleDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            RoleName = createDto.RoleName,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            role.Id = createDto.Id;
        }

        _context.Roles.Add(role);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RoleDbModel>(role.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Role
    /// </summary>
    public async Task DeleteRole(RoleWhereUniqueInput uniqueId)
    {
        var role = await _context.Roles.FindAsync(uniqueId.Id);
        if (role == null)
        {
            throw new NotFoundException();
        }

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Roles
    /// </summary>
    public async Task<List<Role>> Roles(RoleFindManyArgs findManyArgs)
    {
        var roles = await _context
            .Roles.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return roles.ConvertAll(role => role.ToDto());
    }

    /// <summary>
    /// Meta data about Role records
    /// </summary>
    public async Task<MetadataDto> RolesMeta(RoleFindManyArgs findManyArgs)
    {
        var count = await _context.Roles.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Role
    /// </summary>
    public async Task<Role> Role(RoleWhereUniqueInput uniqueId)
    {
        var roles = await this.Roles(
            new RoleFindManyArgs { Where = new RoleWhereInput { Id = uniqueId.Id } }
        );
        var role = roles.FirstOrDefault();
        if (role == null)
        {
            throw new NotFoundException();
        }

        return role;
    }

    /// <summary>
    /// Update one Role
    /// </summary>
    public async Task UpdateRole(RoleWhereUniqueInput uniqueId, RoleUpdateInput updateDto)
    {
        var role = updateDto.ToModel(uniqueId);

        _context.Entry(role).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Roles.Any(e => e.Id == role.Id))
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
