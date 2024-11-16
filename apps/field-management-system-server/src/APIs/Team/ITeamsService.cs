using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;

namespace FieldManagementSystem.APIs;

public interface ITeamsService
{
    /// <summary>
    /// Create one Team
    /// </summary>
    public Task<Team> CreateTeam(TeamCreateInput team);

    /// <summary>
    /// Delete one Team
    /// </summary>
    public Task DeleteTeam(TeamWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Teams
    /// </summary>
    public Task<List<Team>> Teams(TeamFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Team records
    /// </summary>
    public Task<MetadataDto> TeamsMeta(TeamFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Team
    /// </summary>
    public Task<Team> Team(TeamWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Team
    /// </summary>
    public Task UpdateTeam(TeamWhereUniqueInput uniqueId, TeamUpdateInput updateDto);
}
