using FieldManagementSystem.Infrastructure;

namespace FieldManagementSystem.APIs;

public class LocationsService : LocationsServiceBase
{
    public LocationsService(FieldManagementSystemDbContext context)
        : base(context) { }
}
