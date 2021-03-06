// <auto-generated />
using AcademyG.Week8.Essercitazione.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcademyG.Week8.Essercitazione.EF.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    partial class RestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AcademyG.Week8.Esercitazione.Core.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Menù di natale"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Menù di pasqua"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Menù estivo"
                        });
                });

            modelBuilder.Entity("AcademyG.Week8.Esercitazione.Core.Entities.Plate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Plates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Molto buona",
                            MenuId = 1,
                            Name = "Pasta al sugo",
                            Price = 10.2m,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Morbidissima",
                            MenuId = 2,
                            Name = "Fettina di maiale",
                            Price = 17.5m,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fresco",
                            MenuId = 3,
                            Name = "Pesce",
                            Price = 20.0m,
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Croccanti",
                            MenuId = 1,
                            Name = "Patate al forno",
                            Price = 6.8m,
                            Type = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Dolcissimo",
                            MenuId = 2,
                            Name = "Tiramisù",
                            Price = 3.2m,
                            Type = 3
                        });
                });

            modelBuilder.Entity("AcademyG.Week8.Esercitazione.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "mrossi@gmail.com",
                            Password = "1234",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "lverdi@gmail.com",
                            Password = "1111",
                            Role = 1
                        });
                });

            modelBuilder.Entity("AcademyG.Week8.Esercitazione.Core.Entities.Plate", b =>
                {
                    b.HasOne("AcademyG.Week8.Esercitazione.Core.Entities.Menu", "Menu")
                        .WithMany("Plates")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
