using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransCare.Models;

namespace TransCare.Data.Configurations
{
    public partial class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> entity)
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("State");

            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}