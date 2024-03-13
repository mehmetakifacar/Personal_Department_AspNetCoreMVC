using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal_Department_AspNetCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartId",
                table: "PersonalsDb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartId",
                table: "PersonalsDb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
