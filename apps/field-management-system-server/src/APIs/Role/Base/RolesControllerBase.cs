using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RolesControllerBase : ControllerBase
{
    protected readonly IRolesService _service;

    public RolesControllerBase(IRolesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Role
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Role>> CreateRole(RoleCreateInput input)
    {
        var role = await _service.CreateRole(input);

        return CreatedAtAction(nameof(Role), new { id = role.Id }, role);
    }

    /// <summary>
    /// Delete one Role
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteRole([FromRoute()] RoleWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRole(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Roles
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Role>>> Roles([FromQuery()] RoleFindManyArgs filter)
    {
        return Ok(await _service.Roles(filter));
    }

    /// <summary>
    /// Meta data about Role records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RolesMeta([FromQuery()] RoleFindManyArgs filter)
    {
        return Ok(await _service.RolesMeta(filter));
    }

    /// <summary>
    /// Get one Role
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Role>> Role([FromRoute()] RoleWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Role(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Role
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateRole(
        [FromRoute()] RoleWhereUniqueInput uniqueId,
        [FromQuery()] RoleUpdateInput roleUpdateDto
    )
    {
        try
        {
            await _service.UpdateRole(uniqueId, roleUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
