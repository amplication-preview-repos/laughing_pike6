using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[ApiController()]
public class TransactionsController : TransactionsControllerBase
{
    public TransactionsController(ITransactionsService service)
        : base(service) { }
}
