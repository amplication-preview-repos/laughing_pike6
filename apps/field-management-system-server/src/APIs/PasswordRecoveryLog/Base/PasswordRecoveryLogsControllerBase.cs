using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PasswordRecoveryLogsControllerBase : ControllerBase
{
    protected readonly IPasswordRecoveryLogsService _service;

    public PasswordRecoveryLogsControllerBase(IPasswordRecoveryLogsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one PasswordRecoveryLog
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<PasswordRecoveryLog>> CreatePasswordRecoveryLog(
        PasswordRecoveryLogCreateInput input
    )
    {
        var passwordRecoveryLog = await _service.CreatePasswordRecoveryLog(input);

        return CreatedAtAction(
            nameof(PasswordRecoveryLog),
            new { id = passwordRecoveryLog.Id },
            passwordRecoveryLog
        );
    }

    /// <summary>
    /// Delete one PasswordRecoveryLog
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeletePasswordRecoveryLog(
        [FromRoute()] PasswordRecoveryLogWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePasswordRecoveryLog(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many PasswordRecoveryLogs
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<PasswordRecoveryLog>>> PasswordRecoveryLogs(
        [FromQuery()] PasswordRecoveryLogFindManyArgs filter
    )
    {
        return Ok(await _service.PasswordRecoveryLogs(filter));
    }

    /// <summary>
    /// Meta data about PasswordRecoveryLog records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PasswordRecoveryLogsMeta(
        [FromQuery()] PasswordRecoveryLogFindManyArgs filter
    )
    {
        return Ok(await _service.PasswordRecoveryLogsMeta(filter));
    }

    /// <summary>
    /// Get one PasswordRecoveryLog
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<PasswordRecoveryLog>> PasswordRecoveryLog(
        [FromRoute()] PasswordRecoveryLogWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.PasswordRecoveryLog(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one PasswordRecoveryLog
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdatePasswordRecoveryLog(
        [FromRoute()] PasswordRecoveryLogWhereUniqueInput uniqueId,
        [FromQuery()] PasswordRecoveryLogUpdateInput passwordRecoveryLogUpdateDto
    )
    {
        try
        {
            await _service.UpdatePasswordRecoveryLog(uniqueId, passwordRecoveryLogUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
