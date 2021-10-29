using AcademyG.Week8.Esercitazione.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Essercitazione.EF.Configuration
{
    public class PlateConfiguration : IEntityTypeConfiguration<Plate>
    {
        public void Configure(EntityTypeBuilder<Plate> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Type)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasData(
                new Plate
                {
                    Id = 1,
                    Name = "Pasta al sugo",
                    Description = "Molto buona",
                    Type = Typology.First,
                    Price = 10.2M,
                    MenuId = 1
                },
                new Plate
                {
                    Id = 2,
                    Name = "Fettina di maiale",
                    Description = "Morbidissima",
                    Type = Typology.Second,
                    Price = 17.5M,
                    MenuId = 2
                },
                new Plate
                {
                    Id = 3,
                    Name = "Pesce",
                    Description = "Fresco",
                    Type = Typology.Second,
                    Price = 20.0M,
                    MenuId = 3
                },
                new Plate
                {
                    Id = 4,
                    Name = "Patate al forno",
                    Description = "Croccanti",
                    Type = Typology.Side,
                    Price = 6.8M,
                    MenuId = 1
                },
                new Plate
                {
                    Id = 5,
                    Name = "Tiramisù",
                    Description = "Dolcissimo",
                    Type = Typology.Dessert,
                    Price = 3.2M,
                    MenuId = 2
                }
            );
        }
    }
}
