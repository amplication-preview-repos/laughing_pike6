using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class CompanySitesService : CompanySitesServiceBase
{
    public CompanySitesService(FieldManagementSystemDbContext context)
        : base(context) { }
}
