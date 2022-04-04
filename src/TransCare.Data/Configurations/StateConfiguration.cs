﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using TransCare.Entities;

namespace TransCare.Data.Configurations
{
    public partial class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> entity)
        {
            entity.ToTable("State");
            entity.HasKey("Code");
            entity.HasMany<HealthProvider>().WithOne().HasForeignKey(e => e.State);                

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);


            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<State> entity);
    }
}
