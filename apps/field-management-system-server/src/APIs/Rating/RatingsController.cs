using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[ApiController()]
public class RatingsController : RatingsControllerBase
{
    public RatingsController(IRatingsService service)
        : base(service) { }
}
