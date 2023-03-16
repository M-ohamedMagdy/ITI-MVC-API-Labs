using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_departments_DepartmentId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_DepartmentId",
                table: "tickets");

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("0924ac40-8cbe-46f6-bd0b-688bfc0e44c0"));

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("40743094-348f-401e-ab04-00c3bd56afb4"));

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("6d2abe1c-c0bc-43e5-a79b-c7467753c640"));

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("80701952-7ca2-4068-8070-2b543434b446"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("6467f76c-fc8c-4e82-9c8f-c6316b920c26"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("7d9ccc13-064d-482a-8faf-c0a9a8d8e59b"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("86dd294e-11b0-42fd-8644-77b4e83b47e3"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("b5e8ac12-0c2d-4bad-a3ef-16e433357c59"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("c0113a8a-e058-425b-9e30-40f7dcd3c9fd"));

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

            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("29c13290-5f3d-4fa3-bae3-356f00f9bb6a"), "Civil" },
                    { new Guid("432aa782-90a0-4598-9d8c-cca574f4fa51"), "Petroleum" },
                    { new Guid("711e3ab5-c12c-4ac9-96ff-8abb9c58daa4"), "Mechanical" },
                    { new Guid("dbc75f3d-98d7-49ad-abe2-9d064426854c"), "Electrical" }
                });

            migrationBuilder.InsertData(
                table: "developers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("11540754-253f-4c0f-9315-5c1d00c1b2a8"), "Ahmed", "Khairy" },
                    { new Guid("49f562e4-02de-44bd-9155-c7c153bdeb76"), "Mahmoud", "Hesham" },
                    { new Guid("5594410a-9672-4634-8bc1-133cda07fc11"), "Mina", "Gerges" },
                    { new Guid("9e77a4a9-c1b7-4c74-8aac-eeecacaeaa48"), "Mohamed", "Magdy" },
                    { new Guid("a82ab199-e6d1-4b3a-8ae4-9324a204a719"), "Jamal", "Ali" }
                });

            migrationBuilder.InsertData(
                table: "tickets",
                columns: new[] { "Id", "DeptId", "Description", "Severity", "Title" },
                values: new object[,]
                {
                    { new Guid("04f9e64c-62e8-4c01-9390-37cbb29345a4"), null, "ticket number four", 2, "fourth" },
                    { new Guid("18648f0b-b9b4-4d66-af4d-a710dd61c67a"), null, "ticket number one", 2, "first" },
                    { new Guid("566c7130-bcd2-4ef4-9166-e7e3d11b600f"), null, "ticket number three", 0, "third" },
                    { new Guid("bc5c1b56-a9f7-4668-9cd1-ff4f9515a7a3"), null, "ticket number two", 1, "second" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tickets_DeptId",
                table: "tickets",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_departments_DeptId",
                table: "tickets",
                column: "DeptId",
                principalTable: "departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_departments_DeptId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_DeptId",
                table: "tickets");

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("29c13290-5f3d-4fa3-bae3-356f00f9bb6a"));

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("432aa782-90a0-4598-9d8c-cca574f4fa51"));

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("711e3ab5-c12c-4ac9-96ff-8abb9c58daa4"));

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("dbc75f3d-98d7-49ad-abe2-9d064426854c"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("11540754-253f-4c0f-9315-5c1d00c1b2a8"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("49f562e4-02de-44bd-9155-c7c153bdeb76"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("5594410a-9672-4634-8bc1-133cda07fc11"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("9e77a4a9-c1b7-4c74-8aac-eeecacaeaa48"));

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: new Guid("a82ab199-e6d1-4b3a-8ae4-9324a204a719"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("04f9e64c-62e8-4c01-9390-37cbb29345a4"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("18648f0b-b9b4-4d66-af4d-a710dd61c67a"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("566c7130-bcd2-4ef4-9166-e7e3d11b600f"));

            migrationBuilder.DeleteData(
                table: "tickets",
                keyColumn: "Id",
                keyValue: new Guid("bc5c1b56-a9f7-4668-9cd1-ff4f9515a7a3"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "tickets",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_departments_DepartmentId",
                table: "tickets",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id");
        }
    }
}
