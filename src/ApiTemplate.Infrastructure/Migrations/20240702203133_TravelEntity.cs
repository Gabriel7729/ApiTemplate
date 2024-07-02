using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Infrastructure.Migrations;

  public partial class TravelEntity : Migration
  {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "Travels",
              columns: table => new
              {
                  Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  FechadelViaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                  FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                  Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                  Deleted = table.Column<bool>(type: "bit", nullable: false),
                  DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                  CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                  UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                  CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Travels", x => x.Id);
              });
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "Travels");
      }
  }
