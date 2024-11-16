using Microsoft.AspNetCore.Mvc;

namespace FieldManagementSystem.APIs;

[ApiController()]
public class FieldModelsController : FieldModelsControllerBase
{
    public FieldModelsController(IFieldModelsService service)
        : base(service) { }
}
