using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal_Department_AspNetCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentsDb",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsDb", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalsDb",
                columns: table => new
                {
                    PersonalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalsDb", x => x.PersonalId);
                    table.ForeignKey(
                        name: "FK_PersonalsDb_DepartmentsDb_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentsDb",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalsDb_DepartmentId",
                table: "PersonalsDb",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalsDb");

            migrationBuilder.DropTable(
                name: "DepartmentsDb");
        }
    }
}
