using AcademyG.Week8.Esercitazione.Core.Entities;
using AcademyG.Week8.Essercitazione.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Essercitazione.EF
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<User> Users { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new PlateConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
