﻿using BarberTech.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class FeedbackMapping : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("feedbacks");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired();

            //builder.HasOne(f => f.User)
            //    .WithMany(u => u.Feedbacks)
            //    .HasForeignKey(f => f.UserId)
            //    .IsRequired();

            builder.Property(f => f.Comment)
                .HasColumnName("comment");

            builder.Property(f => f.QntStars)
                .HasColumnName("qnt_stars")
                .IsRequired();
        }
    }
}
