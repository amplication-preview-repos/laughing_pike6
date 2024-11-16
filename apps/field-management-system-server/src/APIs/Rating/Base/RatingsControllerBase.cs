using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RatingsControllerBase : ControllerBase
{
    protected readonly IRatingsService _service;

    public RatingsControllerBase(IRatingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Rating
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Rating>> CreateRating(RatingCreateInput input)
    {
        var rating = await _service.CreateRating(input);

        return CreatedAtAction(nameof(Rating), new { id = rating.Id }, rating);
    }

    /// <summary>
    /// Delete one Rating
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteRating([FromRoute()] RatingWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteRating(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Ratings
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Rating>>> Ratings([FromQuery()] RatingFindManyArgs filter)
    {
        return Ok(await _service.Ratings(filter));
    }

    /// <summary>
    /// Meta data about Rating records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RatingsMeta(
        [FromQuery()] RatingFindManyArgs filter
    )
    {
        return Ok(await _service.RatingsMeta(filter));
    }

    /// <summary>
    /// Get one Rating
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Rating>> Rating([FromRoute()] RatingWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Rating(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Rating
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateRating(
        [FromRoute()] RatingWhereUniqueInput uniqueId,
        [FromQuery()] RatingUpdateInput ratingUpdateDto
    )
    {
        try
        {
            await _service.UpdateRating(uniqueId, ratingUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
