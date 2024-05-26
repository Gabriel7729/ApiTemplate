using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTemplate.Infrastructure.Migrations;

public partial class InitialMigration : Migration
  {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "Personas",
              columns: table => new
              {
                  Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  FelicidadAcumulada = table.Column<int>(type: "int", nullable: false),
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
                  table.PrimaryKey("PK_Personas", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "PersonaEventos",
              columns: table => new
              {
                  Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                  Duracion = table.Column<int>(type: "int", nullable: false),
                  Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                  table.PrimaryKey("PK_PersonaEventos", x => x.Id);
                  table.ForeignKey(
                      name: "FK_PersonaEventos_Personas_PersonaId",
                      column: x => x.PersonaId,
                      principalTable: "Personas",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
              });

          migrationBuilder.CreateIndex(
              name: "IX_PersonaEventos_PersonaId",
              table: "PersonaEventos",
              column: "PersonaId");
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "PersonaEventos");

          migrationBuilder.DropTable(
              name: "Personas");
      }
  }
