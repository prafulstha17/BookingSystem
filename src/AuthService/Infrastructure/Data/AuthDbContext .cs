using AuthService.Infrastructure.Configurations;
using Domain.Common;
using Domain.Entities.Client;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
       : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //Client
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientGallery> ClientGalleries { get; set; } 
        //Static Data
        public DbSet<StaticData> StaticData { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new StaticDataConfiguration());
        }
    }
}
