using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Infrastructure.Migrations;

public partial class InitialMigration : Migration
  {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "Vehiculos",
              columns: table => new
              {
                  Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Anio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CantidadMillas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Motor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CantidadPasajeros = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                  table.PrimaryKey("PK_Vehiculos", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "VehiculoEventos",
              columns: table => new
              {
                  Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  VehiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                  table.PrimaryKey("PK_VehiculoEventos", x => x.Id);
                  table.ForeignKey(
                      name: "FK_VehiculoEventos_Vehiculos_VehiculoId",
                      column: x => x.VehiculoId,
                      principalTable: "Vehiculos",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
              });

          migrationBuilder.CreateIndex(
              name: "IX_VehiculoEventos_VehiculoId",
              table: "VehiculoEventos",
              column: "VehiculoId");
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "VehiculoEventos");

          migrationBuilder.DropTable(
              name: "Vehiculos");
      }
  }
