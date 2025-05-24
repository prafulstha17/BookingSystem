using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.FullName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.PasswordHash)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(u => u.Role)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(u => u.IsVerified)
               .IsRequired();

        builder.Property(u => u.CreatedAt)
               .IsRequired();

        builder.Property(u => u.LastLogin);
    }
}
