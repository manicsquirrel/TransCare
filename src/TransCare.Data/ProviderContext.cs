using Microsoft.EntityFrameworkCore;

namespace TransCare.Data
{
    public class ProviderContext : DbContext
    {
        public ProviderContext(DbContextOptions<ProviderContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "transcare.db");
        }

        public string DbPath { get; }

        public DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                            => options.UseSqlite($"Data Source={DbPath}");
    }
}