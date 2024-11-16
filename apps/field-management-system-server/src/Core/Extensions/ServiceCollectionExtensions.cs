using FieldManagementSystem.APIs;

namespace FieldManagementSystem;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBookingsService, BookingsService>();
        services.AddScoped<ICompanySitesService, CompanySitesService>();
        services.AddScoped<IFieldModelsService, FieldModelsService>();
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<IPasswordRecoveryLogsService, PasswordRecoveryLogsService>();
        services.AddScoped<IRatingsService, RatingsService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddScoped<ITeamsService, TeamsService>();
        services.AddScoped<ITransactionsService, TransactionsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
