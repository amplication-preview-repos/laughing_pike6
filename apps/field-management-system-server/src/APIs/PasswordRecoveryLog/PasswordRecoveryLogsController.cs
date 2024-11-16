using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[ApiController()]
public class PasswordRecoveryLogsController : PasswordRecoveryLogsControllerBase
{
    public PasswordRecoveryLogsController(IPasswordRecoveryLogsService service)
        : base(service) { }
}
