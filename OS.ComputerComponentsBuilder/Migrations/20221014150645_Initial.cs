using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OS.ComputerComponentsBuilder.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentralProcessingUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Producer = table.Column<string>(type: "text", nullable: false),
                    Cores = table.Column<int>(type: "integer", nullable: false),
                    Threads = table.Column<int>(type: "integer", nullable: false),
                    BaseClockFrequency = table.Column<double>(type: "double precision", nullable: false),
                    MaxClockFrequency = table.Column<double>(type: "double precision", nullable: false),
                    Socket = table.Column<string>(type: "text", nullable: false),
                    TechnicalProcess = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentralProcessingUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraphicsProcessingUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Producer = table.Column<string>(type: "text", nullable: false),
                    Microarchitecture = table.Column<string>(type: "text", nullable: false),
                    TechnicalProcess = table.Column<string>(type: "text", nullable: false),
                    VideoMemorySize = table.Column<int>(type: "integer", nullable: false),
                    MemoryType = table.Column<string>(type: "text", nullable: false),
                    MemoryFrequency = table.Column<int>(type: "integer", nullable: false),
                    BusWidth = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsProcessingUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Producer = table.Column<string>(type: "text", nullable: false),
                    FormFactor = table.Column<string>(type: "text", nullable: false),
                    Chipset = table.Column<string>(type: "text", nullable: false),
                    Socket = table.Column<string>(type: "text", nullable: false),
                    MemoryType = table.Column<string>(type: "text", nullable: false),
                    MemorySpeed = table.Column<int>(type: "integer", nullable: false),
                    NumberOfMemorySlots = table.Column<int>(type: "integer", nullable: false),
                    MaxMemoryVolume = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandomAccessMemories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    FullVolume = table.Column<int>(type: "integer", nullable: false),
                    Producer = table.Column<string>(type: "text", nullable: false),
                    MemoryType = table.Column<string>(type: "text", nullable: false),
                    FormFactor = table.Column<string>(type: "text", nullable: false),
                    ClockFrequency = table.Column<int>(type: "integer", nullable: false),
                    RegisterMemory = table.Column<bool>(type: "boolean", nullable: false),
                    EccMemory = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomAccessMemories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    Producer = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ReadingSpeed = table.Column<int>(type: "integer", nullable: false),
                    WritingSpeed = table.Column<int>(type: "integer", nullable: false),
                    ConnectionConnector = table.Column<string>(type: "text", nullable: false),
                    MemoryStructure = table.Column<string>(type: "text", nullable: true),
                    WritingTechnology = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CentralProcessingUnits");

            migrationBuilder.DropTable(
                name: "GraphicsProcessingUnits");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "RandomAccessMemories");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}
