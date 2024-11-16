using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[ApiController()]
public class TeamsController : TeamsControllerBase
{
    public TeamsController(ITeamsService service)
        : base(service) { }
}
