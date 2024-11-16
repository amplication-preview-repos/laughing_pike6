using FieldManagementSystem.APIs.Dtos;
using FieldManagementSystem.Infrastructure.Models;

namespace FieldManagementSystem.APIs.Extensions;

public static class TransactionsExtensions
{
    public static Transaction ToDto(this TransactionDbModel model)
    {
        return new Transaction
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TransactionDbModel ToModel(
        this TransactionUpdateInput updateDto,
        TransactionWhereUniqueInput uniqueId
    )
    {
        var transaction = new TransactionDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            transaction.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            transaction.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return transaction;
    }
}
