using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TeamsControllerBase : ControllerBase
{
    protected readonly ITeamsService _service;

    public TeamsControllerBase(ITeamsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Team
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Team>> CreateTeam(TeamCreateInput input)
    {
        var team = await _service.CreateTeam(input);

        return CreatedAtAction(nameof(Team), new { id = team.Id }, team);
    }

    /// <summary>
    /// Delete one Team
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteTeam([FromRoute()] TeamWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteTeam(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Teams
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Team>>> Teams([FromQuery()] TeamFindManyArgs filter)
    {
        return Ok(await _service.Teams(filter));
    }

    /// <summary>
    /// Meta data about Team records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TeamsMeta([FromQuery()] TeamFindManyArgs filter)
    {
        return Ok(await _service.TeamsMeta(filter));
    }

    /// <summary>
    /// Get one Team
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Team>> Team([FromRoute()] TeamWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Team(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Team
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateTeam(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] TeamUpdateInput teamUpdateDto
    )
    {
        try
        {
            await _service.UpdateTeam(uniqueId, teamUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
