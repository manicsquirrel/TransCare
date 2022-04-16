using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransCare.Models;

namespace TransCare.Data.Configurations
{
    public partial class HealthProviderConfiguration : IEntityTypeConfiguration<HealthProvider>
    {
        public void Configure(EntityTypeBuilder<HealthProvider> entity)
        {
            entity.ToTable("HealthProvider");

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(35)
                .IsUnicode(false);

            entity.Property(e => e.Notes).IsUnicode(false);

            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.ProviderName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.StateCode)
                .HasColumnName("State")
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.State)
                .WithMany()
                .HasForeignKey(d => d.StateCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HealthProvider_State");
        }
    }
}