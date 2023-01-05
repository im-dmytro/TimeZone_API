using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeZoneAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryCapital",
                columns: table => new
                {
                    CapitalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    capital = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CountryC__D3DFD193FC2D8284", x => x.CapitalID);
                });

            migrationBuilder.CreateTable(
                name: "CountryFlag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "varchar(58)", unicode: false, maxLength: 58, nullable: false),
                    Code = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    URL = table.Column<string>(type: "varchar(68)", unicode: false, maxLength: 68, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CountryF__3214EC2719C3C517", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountryTimeZones",
                columns: table => new
                {
                    TimeZoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CountryCode = table.Column<string>(name: "Country_Code", type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    TimeZoneName = table.Column<string>(name: "Time_Zone_Name", type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    GMTOffset = table.Column<string>(name: "GMT_Offset", type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CountryT__78D387CF5E57B2FB", x => x.TimeZoneID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCapital");

            migrationBuilder.DropTable(
                name: "CountryFlag");

            migrationBuilder.DropTable(
                name: "CountryTimeZones");
        }
    }
}
