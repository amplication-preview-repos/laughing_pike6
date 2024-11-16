using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[ApiController()]
public class CompanySitesController : CompanySitesControllerBase
{
    public CompanySitesController(ICompanySitesService service)
        : base(service) { }
}
