using Microsoft.EntityFrameworkCore;

namespace TransCare.Data
{
    public class TransCareContext : DbContext
    {
        //public TransCareContext()
        //{
        //}

        public TransCareContext(DbContextOptions<TransCareContext> options)
            : base(options)
        {
        }

        public DbSet<HealthProvider> Providers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured) {
        //        //optionsBuilder.UseSqlServer("TransCareDatabase");
        //        optionsBuilder.UseSqlServer("Data Source=pglaptop262;Initial Catalog=OpenTrans;Integrated Security=True");

        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.ApplyConfiguration(new Configurations.ProviderConfiguration());
            //OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<HealthProvider>().ToTable("Provider");
        }

        //private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}