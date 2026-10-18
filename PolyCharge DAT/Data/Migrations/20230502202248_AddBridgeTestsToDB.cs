using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolyCharge_DAT.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBridgeTestsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POBITests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Run_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false),
                    Lane = table.Column<int>(type: "int", nullable: false),
                    Note_A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note_B = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Part_Size = table.Column<int>(type: "int", nullable: false),
                    Cap_120Hz_uF = table.Column<float>(type: "real", nullable: false),
                    Cap_1kHz_uF = table.Column<float>(type: "real", nullable: false),
                    DF_1kHz = table.Column<float>(type: "real", nullable: false),
                    ESR1_10kHZ_mOhm = table.Column<float>(type: "real", nullable: false),
                    ESR2_20kHZ_mOhm = table.Column<float>(type: "real", nullable: false),
                    ESR3_100kHz_mOhm = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POBITests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PODCTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Run_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false),
                    Lane = table.Column<int>(type: "int", nullable: false),
                    Note_A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note_B = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Part_Size = table.Column<int>(type: "int", nullable: false),
                    Cap_120Hz_uF = table.Column<float>(type: "real", nullable: false),
                    Cap_1kHz_uF = table.Column<float>(type: "real", nullable: false),
                    DF_1kHz = table.Column<float>(type: "real", nullable: false),
                    ESR1_10kHZ_mOhm = table.Column<float>(type: "real", nullable: false),
                    ESR2_20kHZ_mOhm = table.Column<float>(type: "real", nullable: false),
                    ESR3_100kHz_mOhm = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PODCTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRDCTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Run_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false),
                    Lane = table.Column<int>(type: "int", nullable: false),
                    Note_A = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note_B = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Part_Size = table.Column<int>(type: "int", nullable: false),
                    Cap_120Hz_uF = table.Column<float>(type: "real", nullable: false),
                    Cap_1kHz_uF = table.Column<float>(type: "real", nullable: false),
                    DF_1kHz = table.Column<float>(type: "real", nullable: false),
                    ESR1_10kHZ_mOhm = table.Column<float>(type: "real", nullable: false),
                    ESR2_20kHZ_mOhm = table.Column<float>(type: "real", nullable: false),
                    ESR3_100kHz_mOhm = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRDCTests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POBITests");

            migrationBuilder.DropTable(
                name: "PODCTests");

            migrationBuilder.DropTable(
                name: "PRDCTests");
        }
    }
}
