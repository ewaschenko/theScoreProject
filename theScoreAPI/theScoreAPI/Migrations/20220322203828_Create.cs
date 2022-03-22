using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theScoreAPI.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rushings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Att = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AttG = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Yds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YdsG = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Avg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LngDistance = table.Column<int>(type: "int", nullable: false),
                    FirstDowns = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstDownPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RushingTwenty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RushingFourty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FUM = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rushings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rushings");
        }
    }
}
