using AcademyG.Week8.Esercitazione.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Essercitazione.EF.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.Name) // suppongo che il nome sia unique
                   .IsUnique();

            builder.Property(m => m.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(m => m.Plates)
                   .WithOne(p => p.Menu);

            builder.HasData(
                new Menu
                {
                    Id = 1,
                    Name = "Menù di natale"
                },
                new Menu
                {
                    Id = 2,
                    Name = "Menù di pasqua"
                },
                new Menu
                {
                    Id = 3,
                    Name = "Menù estivo"
                }
            );
        }
    }
}
