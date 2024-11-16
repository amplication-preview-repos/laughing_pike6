using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class BookingsService : BookingsServiceBase
{
    public BookingsService(FieldManagementSystemDbContext context)
        : base(context) { }
}
