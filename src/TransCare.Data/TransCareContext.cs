using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using TransCare.Data.Configurations;
using Microsoft.Data.SqlClient;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace TransCare.Data
{
    public partial class TransCareContext : DbContext
    {
        public TransCareContext()
        {
        }

        public TransCareContext(DbContextOptions<TransCareContext> options)
            : base(options)
        {
        }

        public  DbSet<Provider> Providers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured) {
        //        //optionsBuilder.UseSqlServer("TransCareDatabase");
        //        optionsBuilder.UseSqlServer("Data Source=pglaptop262;Initial Catalog=OpenTrans;Integrated Security=True");

        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new Configurations.ProviderConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
