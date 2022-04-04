using Microsoft.EntityFrameworkCore;
using TransCare.Entities;

namespace TransCare.Data
{
    public class TransCareContext : DbContext
    {
        
        public TransCareContext(DbContextOptions<TransCareContext> options)
            : base(options)
        {
        }

        public DbSet<HealthProvider> HealthProviders { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransCareContext).Assembly);
        }
    }
}