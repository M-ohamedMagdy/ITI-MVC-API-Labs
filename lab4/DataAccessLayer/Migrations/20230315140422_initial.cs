using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "Id", "Description", "Severity", "Title" },
                values: new object[,]
                {
                    { new Guid("17156556-18ee-4625-812a-98f627ab9ed8"), "ticket number three", 0, "third" },
                    { new Guid("564de363-45aa-45c9-b5fb-03812e68537a"), "ticket number one", 2, "first" },
                    { new Guid("655c2c6c-0d9c-4155-808d-3fac47b8b1a2"), "ticket number four", 2, "fourth" },
                    { new Guid("fce84308-3586-40e4-becb-d7a56fca84f8"), "ticket number two", 1, "second" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tickets");
        }
    }
}
