using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class lab5initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("17156556-18ee-4625-812a-98f627ab9ed8"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("564de363-45aa-45c9-b5fb-03812e68537a"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("655c2c6c-0d9c-4155-808d-3fac47b8b1a2"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("fce84308-3586-40e4-becb-d7a56fca84f8"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeptId",
                table: "tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "developers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperTicket",
                columns: table => new
                {
                    DevelopersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperTicket", x => new { x.DevelopersId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperTicket_tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0924ac40-8cbe-46f6-bd0b-688bfc0e44c0"), "Mechanical" },
                    { new Guid("40743094-348f-401e-ab04-00c3bd56afb4"), "Civil" },
                    { new Guid("6d2abe1c-c0bc-43e5-a79b-c7467753c640"), "Electrical" },
                    { new Guid("80701952-7ca2-4068-8070-2b543434b446"), "Petroleum" }
                });

            migrationBuilder.InsertData(
                table: "developers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("6467f76c-fc8c-4e82-9c8f-c6316b920c26"), "Mohamed", "Magdy" },
                    { new Guid("7d9ccc13-064d-482a-8faf-c0a9a8d8e59b"), "Mina", "Gerges" },
                    { new Guid("86dd294e-11b0-42fd-8644-77b4e83b47e3"), "Jamal", "Ali" },
                    { new Guid("b5e8ac12-0c2d-4bad-a3ef-16e433357c59"), "Mahmoud", "Hesham" },
                    { new Guid("c0113a8a-e058-425b-9e30-40f7dcd3c9fd"), "Ahmed", "Khairy" }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "Id", "DepartmentId", "DeptId", "Description", "Severity", "Title" },
                values: new object[,]
                {
                    { new Guid("5cb4d103-bd27-4b67-b02f-f26560aa905b"), null, null, "ticket number one", 2, "first" },
                    { new Guid("8a549678-c889-4520-a582-bff12f66c4f5"), null, null, "ticket number two", 1, "second" },
                    { new Guid("9fdbaa65-e6d3-4a16-82b6-bfb9559452db"), null, null, "ticket number three", 0, "third" },
                    { new Guid("f835eff3-3aa9-4e17-85cf-45070902c258"), null, null, "ticket number four", 2, "fourth" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickets_DepartmentId",
                table: "tickets",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperTicket_TicketsId",
                table: "DeveloperTicket",
                column: "TicketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_departments_DepartmentId",
                table: "tickets",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_departments_DepartmentId",
                table: "tickets");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "DeveloperTicket");

            migrationBuilder.DropTable(
                name: "developers");

            migrationBuilder.DropIndex(
                name: "IX_tickets_DepartmentId",
                table: "tickets");

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("5cb4d103-bd27-4b67-b02f-f26560aa905b"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("8a549678-c889-4520-a582-bff12f66c4f5"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("9fdbaa65-e6d3-4a16-82b6-bfb9559452db"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("f835eff3-3aa9-4e17-85cf-45070902c258"));

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "tickets");

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
    }
}
