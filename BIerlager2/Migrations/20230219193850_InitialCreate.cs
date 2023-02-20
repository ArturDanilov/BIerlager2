using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BIerlager2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flasche",
                columns: table => new
                {
                    FlascheId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GenommenAm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KisteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Raum = table.Column<int>(type: "INTEGER", nullable: false),
                    Regal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flasche", x => x.FlascheId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flasche");
        }
    }
}
