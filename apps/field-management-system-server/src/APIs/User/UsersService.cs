using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(FieldManagementSystemDbContext context)
        : base(context) { }
}
