using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Config;

public class StaticDataConfiguration : IEntityTypeConfiguration<StaticData>
{
    public void Configure(EntityTypeBuilder<StaticData> builder)
    {
        builder.ToTable("staticdata");  // Name of the table

        builder.HasKey(m => m.Id);  // Setting the primary key

        builder.Property(m => m.Key)
            .IsRequired()
            .HasMaxLength(255);  // Setting the key column to be required with max length

        builder.Property(m => m.Value)
            .HasMaxLength(255);  // Setting the value column max length

        builder.Property(m => m.Description)
            .HasColumnType("text");  // Setting the description column as text

        builder.Property(m => m.Sts)
            .IsRequired()
            .HasDefaultValue("Active");  // Setting default value for status

        builder.Property(m => m.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");  // Default value for created at timestamp

        builder.Property(m => m.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnUpdate();  // Automatically update timestamp on record modification
    }
}
