using AuthFlow.Domain.Core.RefreshToken;
using AuthFlow.Domain.Core.Users;
using Microsoft.EntityFrameworkCore;

namespace AuthFlow.Infrastructure.Persistence;

public class AuthFlowDbContext : DbContext
{
    public AuthFlowDbContext(DbContextOptions<AuthFlowDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(AuthFlowDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}