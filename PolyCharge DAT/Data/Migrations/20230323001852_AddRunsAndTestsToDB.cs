using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolyCharge_DAT.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRunsAndTestsToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Runs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Run_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Project_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Run = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pre_Run_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oiler_Offset = table.Column<float>(type: "real", nullable: true),
                    Evap_Tank_Temp = table.Column<int>(type: "int", nullable: true),
                    Evap_Nozzel_Temp = table.Column<int>(type: "int", nullable: true),
                    Slit_Gap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Target_Thickness = table.Column<int>(type: "int", nullable: true),
                    Mono_Flow_Rate = table.Column<int>(type: "int", nullable: true),
                    Mono_Pump = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wire_Inner_Speed = table.Column<int>(type: "int", nullable: true),
                    Wire_Outer_Boat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wire_2nd_Outer_Boat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Target_OD = table.Column<float>(type: "real", nullable: true),
                    E_Gun_KV = table.Column<int>(type: "int", nullable: true),
                    E_Gun_mA = table.Column<int>(type: "int", nullable: true),
                    E_Gun_Ar_Flow = table.Column<int>(type: "int", nullable: true),
                    Magnetron_Supply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Magnetron_Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Magnetron_Ar_Gas_Flow = table.Column<int>(type: "int", nullable: true),
                    Magnetron_O2_Gas_Flow = table.Column<int>(type: "int", nullable: true),
                    Shadow_Mask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shadow_Mask_Start_Position = table.Column<float>(type: "real", nullable: true),
                    Shadow_Mask_Movement = table.Column<int>(type: "int", nullable: true),
                    Oiler_Faceplates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oiler_Temperature = table.Column<int>(type: "int", nullable: true),
                    Oiler_Gas_Flow = table.Column<int>(type: "int", nullable: true),
                    Oiler_Start_Position = table.Column<int>(type: "int", nullable: true),
                    Oiler_Shift = table.Column<float>(type: "real", nullable: true),
                    Oiler_Step_back = table.Column<int>(type: "int", nullable: true),
                    Drum_Temp = table.Column<int>(type: "int", nullable: true),
                    Web_Speed = table.Column<int>(type: "int", nullable: true),
                    Film = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Release = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bottom_Mono_Only_Layers = table.Column<int>(type: "int", nullable: true),
                    Bottom_Inactive_Layers = table.Column<int>(type: "int", nullable: true),
                    Active_Layers = table.Column<int>(type: "int", nullable: true),
                    Top_Inactive_Layers = table.Column<int>(type: "int", nullable: true),
                    Top_Mono_Only_Layers = table.Column<int>(type: "int", nullable: true),
                    Total_layers = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
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
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Runs");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
