using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolyCharge_DAT.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIssuesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Issue_CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issue_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issue_CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Issue_ClosedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issue_Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Issue_ClosedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Issue_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");
        }
    }
}
