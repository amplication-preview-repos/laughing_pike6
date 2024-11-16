using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class PasswordRecoveryLogsService : PasswordRecoveryLogsServiceBase
{
    public PasswordRecoveryLogsService(FieldManagementSystemDbContext context)
        : base(context) { }
}
