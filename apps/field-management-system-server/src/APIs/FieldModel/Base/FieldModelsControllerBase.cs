using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FieldModelsControllerBase : ControllerBase
{
    protected readonly IFieldModelsService _service;

    public FieldModelsControllerBase(IFieldModelsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Field
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<FieldModel>> CreateFieldModel(FieldModelCreateInput input)
    {
        var fieldModel = await _service.CreateFieldModel(input);

        return CreatedAtAction(nameof(FieldModel), new { id = fieldModel.Id }, fieldModel);
    }

    /// <summary>
    /// Delete one Field
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteFieldModel(
        [FromRoute()] FieldModelWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteFieldModel(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Fields
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<FieldModel>>> FieldModels(
        [FromQuery()] FieldModelFindManyArgs filter
    )
    {
        return Ok(await _service.FieldModels(filter));
    }

    /// <summary>
    /// Meta data about Field records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FieldModelsMeta(
        [FromQuery()] FieldModelFindManyArgs filter
    )
    {
        return Ok(await _service.FieldModelsMeta(filter));
    }

    /// <summary>
    /// Get one Field
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<FieldModel>> FieldModel(
        [FromRoute()] FieldModelWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.FieldModel(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Field
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateFieldModel(
        [FromRoute()] FieldModelWhereUniqueInput uniqueId,
        [FromQuery()] FieldModelUpdateInput fieldModelUpdateDto
    )
    {
        try
        {
            await _service.UpdateFieldModel(uniqueId, fieldModelUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
