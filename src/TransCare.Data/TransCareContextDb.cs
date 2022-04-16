using Microsoft.EntityFrameworkCore;
using TransCare.Models;

namespace TransCare.Data
{
    public class TransCareContextDb : DbContext
    {
        public TransCareContextDb()
        {
        }

        public TransCareContextDb(DbContextOptions<TransCareContextDb> options)
            : base(options)
        {
        }

        public virtual DbSet<HealthProvider> HealthProviders { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfiguration(new Configurations.HealthProviderConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.StateConfiguration());
            modelBuilder.Entity<HealthProvider>().Navigation(e => e.State).AutoInclude();
            modelBuilder.Entity<HealthProvider>().Ignore(c => c.Distance);
        }
    }
}