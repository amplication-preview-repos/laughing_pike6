using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class FieldModelsService : FieldModelsServiceBase
{
    public FieldModelsService(FieldManagementSystemDbContext context)
        : base(context) { }
}
