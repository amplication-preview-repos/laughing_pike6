using FieldManagementSystem.APIs;
using FieldManagementSystem.APIs.Common;
using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TransactionsControllerBase : ControllerBase
{
    protected readonly ITransactionsService _service;

    public TransactionsControllerBase(ITransactionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Transaction
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Transaction>> CreateTransaction(TransactionCreateInput input)
    {
        var transaction = await _service.CreateTransaction(input);

        return CreatedAtAction(nameof(Transaction), new { id = transaction.Id }, transaction);
    }

    /// <summary>
    /// Delete one Transaction
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteTransaction(
        [FromRoute()] TransactionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTransaction(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Transactions
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Transaction>>> Transactions(
        [FromQuery()] TransactionFindManyArgs filter
    )
    {
        return Ok(await _service.Transactions(filter));
    }

    /// <summary>
    /// Meta data about Transaction records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TransactionsMeta(
        [FromQuery()] TransactionFindManyArgs filter
    )
    {
        return Ok(await _service.TransactionsMeta(filter));
    }

    /// <summary>
    /// Get one Transaction
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Transaction>> Transaction(
        [FromRoute()] TransactionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Transaction(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Transaction
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateTransaction(
        [FromRoute()] TransactionWhereUniqueInput uniqueId,
        [FromQuery()] TransactionUpdateInput transactionUpdateDto
    )
    {
        try
        {
            await _service.UpdateTransaction(uniqueId, transactionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
