using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class RolesService : RolesServiceBase
{
    public RolesService(FieldManagementSystemDbContext context)
        : base(context) { }
}
