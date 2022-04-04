using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using TransCare.Data.Entities;

namespace TransCare.Data.Configurations
{
    public  class StateConfiguration : IEntityTypeConfiguration<StateData>
    {
        public void Configure(EntityTypeBuilder<StateData> entity)
        {
            entity.ToTable("State");
            entity.HasKey("Code");                       

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);


            //OnConfigurePartial(entity);
        }

        //partial void OnConfigurePartial(EntityTypeBuilder<StateData> entity);
    }
}
