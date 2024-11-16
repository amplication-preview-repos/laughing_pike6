using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[ApiController()]
public class RolesController : RolesControllerBase
{
    public RolesController(IRolesService service)
        : base(service) { }
}
