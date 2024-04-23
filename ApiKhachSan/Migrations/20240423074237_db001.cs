using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiKhachSan.Migrations
{
    /// <inheritdoc />
    public partial class db001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CusId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CusId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CusId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "CCCD",
                table: "Bookings",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bookings",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bookings",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Sdt",
                table: "Bookings",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CCCD",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Sdt",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "CusId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Sdt = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CusId",
                table: "Bookings",
                column: "CusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CusId",
                table: "Bookings",
                column: "CusId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
