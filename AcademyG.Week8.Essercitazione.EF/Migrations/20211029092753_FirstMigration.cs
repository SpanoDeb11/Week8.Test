using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademyG.Week8.Essercitazione.EF.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<int>(maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plates_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Menù di natale" },
                    { 2, "Menù di pasqua" },
                    { 3, "Menù estivo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "mrossi@gmail.com", "1234", 0 },
                    { 2, "lverdi@gmail.com", "1111", 1 }
                });

            migrationBuilder.InsertData(
                table: "Plates",
                columns: new[] { "Id", "Description", "MenuId", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Molto buona", 1, "Pasta al sugo", 10.2m, 0 },
                    { 4, "Croccanti", 1, "Patate al forno", 6.8m, 2 },
                    { 2, "Morbidissima", 2, "Fettina di maiale", 17.5m, 1 },
                    { 5, "Dolcissimo", 2, "Tiramisù", 3.2m, 3 },
                    { 3, "Fresco", 3, "Pesce", 20.0m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Name",
                table: "Menus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plates_MenuId",
                table: "Plates",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
