using FieldManagementSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FieldManagementSystem.Infrastructure;

public class FieldManagementSystemDbContext : IdentityDbContext<IdentityUser>
{
    public FieldManagementSystemDbContext(DbContextOptions<FieldManagementSystemDbContext> options)
        : base(options) { }

    public DbSet<RoleDbModel> Roles { get; set; }

    public DbSet<LocationDbModel> Locations { get; set; }

    public DbSet<BookingDbModel> Bookings { get; set; }

    public DbSet<FieldModelDbModel> FieldModels { get; set; }

    public DbSet<PasswordRecoveryLogDbModel> PasswordRecoveryLogs { get; set; }

    public DbSet<TransactionDbModel> Transactions { get; set; }

    public DbSet<RatingDbModel> Ratings { get; set; }

    public DbSet<CompanySiteDbModel> CompanySites { get; set; }

    public DbSet<TeamDbModel> Teams { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
