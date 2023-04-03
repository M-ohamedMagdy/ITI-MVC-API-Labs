using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab3.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dependants",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dependants",
                table: "AspNetUsers");
        }
    }
}
