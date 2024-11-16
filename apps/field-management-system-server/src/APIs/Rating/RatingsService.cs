using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class RatingsService : RatingsServiceBase
{
    public RatingsService(FieldManagementSystemDbContext context)
        : base(context) { }
}
