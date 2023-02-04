using AuthFlow.Domain.Core.RefreshToken;
using AuthFlow.Domain.Core.RefreshToken.ValueObjects;
using AuthFlow.Domain.Core.Users;
using AuthFlow.Domain.Core.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthFlow.Infrastructure.Persistence.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        ConfigureRefreshTokensTable(builder);
    }

    private static void ConfigureRefreshTokensTable(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(nameof(RefreshToken.Id), nameof(RefreshToken.UserId));

        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                id => RefreshTokenId.Create(id)
            );

        builder.Property(r => r.UserId)
            .HasConversion(
                id => id.Value,
                id => UserId.Create(id)
            )
            .IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .IsRequired();

        builder.Property(r => r.Token)
            .IsRequired()
            .HasMaxLength(255);
    }
}