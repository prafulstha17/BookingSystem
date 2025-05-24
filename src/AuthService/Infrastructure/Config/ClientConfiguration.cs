using Domain.Common;
using Domain.Entities.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Config
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c=>c.Province)
                     .IsRequired()
                     .HasMaxLength(100);
            builder.Property(c => c.District)
                        .IsRequired()
                        .HasMaxLength(100);
            builder.Property(c => c.City)
                        .IsRequired()
                        .HasMaxLength(100);
            builder.Property(c => c.PhoneNumber)
                        .IsRequired()
                        .HasMaxLength(15);


            builder.Property(c => c.status)
                   .HasDefaultValue("Active");

            builder.Property(c => c.CreatedAt)
       .HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(c => c.LastUpdated)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP")
                   .IsRequired(false);
            builder.Property(c => c.Email)
                     .IsRequired()
                     .HasMaxLength(100);
            builder.Property(c => c.status)
                        .HasDefaultValue("Active");


            builder.Property(c => c.LastUpdated)
                   .IsRequired(false);
            builder.Property(c => c.PrilePicture)
                   .IsRequired(false);
            builder.Property(c => c.Description)
                     .IsRequired(false);
            builder.Property(c => c.GoogleMapLink)
                     .IsRequired(false);
            builder.HasMany(c => c.ClientGalleries)
                     .WithOne(cg => cg.Client)
                     .HasForeignKey(cg => cg.ClientId)
                     .OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}
