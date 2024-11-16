using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class TransactionsService : TransactionsServiceBase
{
    public TransactionsService(FieldManagementSystemDbContext context)
        : base(context) { }
}
