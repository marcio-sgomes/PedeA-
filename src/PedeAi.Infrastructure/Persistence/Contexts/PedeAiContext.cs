using Microsoft.EntityFrameworkCore;
using PedeAi.Infrastructure.Persistence.PersistenceModels;

namespace PedeAi.Infrastructure.Persistence.Contexts
{
    public class PedeAiContext(DbContextOptions<PedeAiContext> options) : DbContext(options)
    {
        public DbSet<CustomerPersistenceModel> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedeAiContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}