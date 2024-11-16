using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CompanySitesControllerBase : ControllerBase
{
    protected readonly ICompanySitesService _service;

    public CompanySitesControllerBase(ICompanySitesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one CompanySite
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<CompanySite>> CreateCompanySite(CompanySiteCreateInput input)
    {
        var companySite = await _service.CreateCompanySite(input);

        return CreatedAtAction(nameof(CompanySite), new { id = companySite.Id }, companySite);
    }

    /// <summary>
    /// Delete one CompanySite
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteCompanySite(
        [FromRoute()] CompanySiteWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteCompanySite(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many CompanySites
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<CompanySite>>> CompanySites(
        [FromQuery()] CompanySiteFindManyArgs filter
    )
    {
        return Ok(await _service.CompanySites(filter));
    }

    /// <summary>
    /// Meta data about CompanySite records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CompanySitesMeta(
        [FromQuery()] CompanySiteFindManyArgs filter
    )
    {
        return Ok(await _service.CompanySitesMeta(filter));
    }

    /// <summary>
    /// Get one CompanySite
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<CompanySite>> CompanySite(
        [FromRoute()] CompanySiteWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.CompanySite(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one CompanySite
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateCompanySite(
        [FromRoute()] CompanySiteWhereUniqueInput uniqueId,
        [FromQuery()] CompanySiteUpdateInput companySiteUpdateDto
    )
    {
        try
        {
            await _service.UpdateCompanySite(uniqueId, companySiteUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
