using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[ApiController()]
public class LocationsController : LocationsControllerBase
{
    public LocationsController(ILocationsService service)
        : base(service) { }
}
