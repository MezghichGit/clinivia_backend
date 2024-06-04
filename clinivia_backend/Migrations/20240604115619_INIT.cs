using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clinivia_backend.Migrations
{
    /// <inheritdoc />
    public partial class INIT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    D_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_no = table.Column<int>(type: "int", nullable: false),
                    D_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_head = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    D_status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.D_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departements");
        }
    }
}
