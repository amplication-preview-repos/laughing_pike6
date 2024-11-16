using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class TeamsService : TeamsServiceBase
{
    public TeamsService(FieldManagementSystemDbContext context)
        : base(context) { }
}
