using AcademyG.Week8.Esercitazione.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Essercitazione.EF.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Role)
                   .IsRequired();

            builder.HasData(
                new User
                {
                    Id = 1,
                    Email = "mrossi@gmail.com",
                    Password = "1234",
                    Role = Role.Restaurant
                },
                new User
                {
                    Id = 2,
                    Email = "lverdi@gmail.com",
                    Password = "1111",
                    Role = Role.Client
                }
            );
        }
    }
}
