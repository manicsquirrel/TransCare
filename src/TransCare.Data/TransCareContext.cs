using Microsoft.EntityFrameworkCore;
using TransCare.Data.Entities;

namespace TransCare.Data
{
    public class TransCareContext : DbContext
    {
        public TransCareContext(DbContextOptions<TransCareContext> options)
            : base(options)
        {
        }

        public DbSet<HealthProviderData> HealthProviders { get; set; }
        public DbSet<StateData> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransCareContext).Assembly);
        }
    }
}