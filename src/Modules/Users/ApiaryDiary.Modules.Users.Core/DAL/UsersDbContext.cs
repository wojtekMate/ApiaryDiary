using ApiaryDiary.Modules.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiaryDiary.Modules.Users.Core.DAL;

internal class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) //opcje przekazane w extansions method w shared/postgres addpostgres
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); //czyli konfiguracje z foldery configurations
    }
}