using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Config
{

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            // Seed default roles
            builder.HasData(
                new Role { Id = 1, Name = "User" },
                new Role { Id = 2, Name = "Client" },
                new Role { Id = 3, Name = "Admin" }
            );
        }
    }
}
