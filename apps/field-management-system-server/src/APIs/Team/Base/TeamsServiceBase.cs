using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using FieldManagementSystem.APIs.Extensions;
using FieldManagementSystem.Infrastructure;
using FieldManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldManagementSystem.APIs;

public abstract class TeamsServiceBase : ITeamsService
{
    protected readonly FieldManagementSystemDbContext _context;

    public TeamsServiceBase(FieldManagementSystemDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Team
    /// </summary>
    public async Task<Team> CreateTeam(TeamCreateInput createDto)
    {
        var team = new TeamDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            team.Id = createDto.Id;
        }

        _context.Teams.Add(team);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TeamDbModel>(team.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Team
    /// </summary>
    public async Task DeleteTeam(TeamWhereUniqueInput uniqueId)
    {
        var team = await _context.Teams.FindAsync(uniqueId.Id);
        if (team == null)
        {
            throw new NotFoundException();
        }

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Teams
    /// </summary>
    public async Task<List<Team>> Teams(TeamFindManyArgs findManyArgs)
    {
        var teams = await _context
            .Teams.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return teams.ConvertAll(team => team.ToDto());
    }

    /// <summary>
    /// Meta data about Team records
    /// </summary>
    public async Task<MetadataDto> TeamsMeta(TeamFindManyArgs findManyArgs)
    {
        var count = await _context.Teams.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Team
    /// </summary>
    public async Task<Team> Team(TeamWhereUniqueInput uniqueId)
    {
        var teams = await this.Teams(
            new TeamFindManyArgs { Where = new TeamWhereInput { Id = uniqueId.Id } }
        );
        var team = teams.FirstOrDefault();
        if (team == null)
        {
            throw new NotFoundException();
        }

        return team;
    }

    /// <summary>
    /// Update one Team
    /// </summary>
    public async Task UpdateTeam(TeamWhereUniqueInput uniqueId, TeamUpdateInput updateDto)
    {
        var team = updateDto.ToModel(uniqueId);

        _context.Entry(team).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Teams.Any(e => e.Id == team.Id))
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
