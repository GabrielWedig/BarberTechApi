﻿using BarberTech.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class HaircutMapping : IEntityTypeConfiguration<Haircut>
    {
        public void Configure(EntityTypeBuilder<Haircut> builder)
        {
            builder.ToTable("haircut");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired();

            builder.Property(h => h.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(h => h.Description)
                .HasColumnName("description");

            builder.Property(h => h.PhotoURL)
                .HasColumnName("photo_url")
                .IsRequired();

            builder.Property(h => h.Price)
                .HasColumnName("price")
                .IsRequired();
        }
    }
}