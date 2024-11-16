using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using FieldManagementSystem.APIs.Extensions;
using FieldManagementSystem.Infrastructure;
using FieldManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldManagementSystem.APIs;

public abstract class PasswordRecoveryLogsServiceBase : IPasswordRecoveryLogsService
{
    protected readonly FieldManagementSystemDbContext _context;

    public PasswordRecoveryLogsServiceBase(FieldManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PasswordRecoveryLog
    /// </summary>
    public async Task<PasswordRecoveryLog> CreatePasswordRecoveryLog(
        PasswordRecoveryLogCreateInput createDto
    )
    {
        var passwordRecoveryLog = new PasswordRecoveryLogDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            passwordRecoveryLog.Id = createDto.Id;
        }

        _context.PasswordRecoveryLogs.Add(passwordRecoveryLog);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PasswordRecoveryLogDbModel>(passwordRecoveryLog.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PasswordRecoveryLog
    /// </summary>
    public async Task DeletePasswordRecoveryLog(PasswordRecoveryLogWhereUniqueInput uniqueId)
    {
        var passwordRecoveryLog = await _context.PasswordRecoveryLogs.FindAsync(uniqueId.Id);
        if (passwordRecoveryLog == null)
        {
            throw new NotFoundException();
        }

        _context.PasswordRecoveryLogs.Remove(passwordRecoveryLog);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PasswordRecoveryLogs
    /// </summary>
    public async Task<List<PasswordRecoveryLog>> PasswordRecoveryLogs(
        PasswordRecoveryLogFindManyArgs findManyArgs
    )
    {
        var passwordRecoveryLogs = await _context
            .PasswordRecoveryLogs.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return passwordRecoveryLogs.ConvertAll(passwordRecoveryLog => passwordRecoveryLog.ToDto());
    }

    /// <summary>
    /// Meta data about PasswordRecoveryLog records
    /// </summary>
    public async Task<MetadataDto> PasswordRecoveryLogsMeta(
        PasswordRecoveryLogFindManyArgs findManyArgs
    )
    {
        var count = await _context.PasswordRecoveryLogs.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PasswordRecoveryLog
    /// </summary>
    public async Task<PasswordRecoveryLog> PasswordRecoveryLog(
        PasswordRecoveryLogWhereUniqueInput uniqueId
    )
    {
        var passwordRecoveryLogs = await this.PasswordRecoveryLogs(
            new PasswordRecoveryLogFindManyArgs
            {
                Where = new PasswordRecoveryLogWhereInput { Id = uniqueId.Id }
            }
        );
        var passwordRecoveryLog = passwordRecoveryLogs.FirstOrDefault();
        if (passwordRecoveryLog == null)
        {
            throw new NotFoundException();
        }

        return passwordRecoveryLog;
    }

    /// <summary>
    /// Update one PasswordRecoveryLog
    /// </summary>
    public async Task UpdatePasswordRecoveryLog(
        PasswordRecoveryLogWhereUniqueInput uniqueId,
        PasswordRecoveryLogUpdateInput updateDto
    )
    {
        var passwordRecoveryLog = updateDto.ToModel(uniqueId);

        _context.Entry(passwordRecoveryLog).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PasswordRecoveryLogs.Any(e => e.Id == passwordRecoveryLog.Id))
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
