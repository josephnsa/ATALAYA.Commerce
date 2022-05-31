using Customer.Persistence.Database.Configuration;
using Customer.Domain;
using Microsoft.EntityFrameworkCore;

namespace Customer.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //DataBase schema
            modelBuilder.HasDefaultSchema("Client");

            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new ClientConfiguration(modelBuilder.Entity<Client>());

        }
    }
}
