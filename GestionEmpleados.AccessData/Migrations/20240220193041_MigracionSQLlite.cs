using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionEmpleados.AccessData.Migrations
{
    /// <inheritdoc />
    public partial class MigracionSQLlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    CatalogoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Catalogo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.CatalogoId);
                });

            migrationBuilder.CreateTable(
                name: "CatalogosDescripciones",
                columns: table => new
                {
                    CatalogoDescripcionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CatalogoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ValorEntero = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorDouble = table.Column<double>(type: "REAL", nullable: false),
                    ValorFecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorAlfanumerico = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogosDescripciones", x => x.CatalogoDescripcionId);
                    table.ForeignKey(
                        name: "FK_CatalogosDescripciones_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "CatalogoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    CargoID = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartamentoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleado_CatalogosDescripciones_CargoID",
                        column: x => x.CargoID,
                        principalTable: "CatalogosDescripciones",
                        principalColumn: "CatalogoDescripcionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_CatalogosDescripciones_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "CatalogosDescripciones",
                        principalColumn: "CatalogoDescripcionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Familiar",
                columns: table => new
                {
                    FamiliarID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpleadoID = table.Column<int>(type: "INTEGER", nullable: false),
                    RelacionID = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiar", x => x.FamiliarID);
                    table.ForeignKey(
                        name: "FK_Familiar_CatalogosDescripciones_RelacionID",
                        column: x => x.RelacionID,
                        principalTable: "CatalogosDescripciones",
                        principalColumn: "CatalogoDescripcionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Familiar_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudVacaciones",
                columns: table => new
                {
                    SolicitudID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpleadoID = table.Column<int>(type: "INTEGER", nullable: false),
                    EstatusID = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ComentarioJefe = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudVacaciones", x => x.SolicitudID);
                    table.ForeignKey(
                        name: "FK_SolicitudVacaciones_CatalogosDescripciones_EstatusID",
                        column: x => x.EstatusID,
                        principalTable: "CatalogosDescripciones",
                        principalColumn: "CatalogoDescripcionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitudVacaciones_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpleadoID = table.Column<int>(type: "INTEGER", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    HashedPassword = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuario_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    RolID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => new { x.UsuarioID, x.RolID });
                    table.ForeignKey(
                        name: "FK_UsuarioRol_CatalogosDescripciones_RolID",
                        column: x => x.RolID,
                        principalTable: "CatalogosDescripciones",
                        principalColumn: "CatalogoDescripcionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Catalogos",
                columns: new[] { "CatalogoId", "Catalogo" },
                values: new object[,]
                {
                    { 1, "Cargo" },
                    { 2, "Departamento" },
                    { 3, "Rol" },
                    { 4, "EstatusVacaciones" },
                    { 5, "Tipo de Relacion" }
                });

            migrationBuilder.InsertData(
                table: "CatalogosDescripciones",
                columns: new[] { "CatalogoDescripcionId", "CatalogoId", "Descripcion", "ValorAlfanumerico", "ValorDouble", "ValorEntero", "ValorFecha" },
                values: new object[,]
                {
                    { 1000, 1, "Director", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1001, 1, "Subdirector", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1002, 1, "Gerente", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1003, 1, "Vendedor", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2000, 2, "Ventas", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3000, 3, "Director", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3001, 3, "Empleado", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4000, 4, "Pendiente", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4001, 4, "Aprobada", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4002, 4, "Rechazada", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5000, 5, "Padre", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5001, 5, "Madre", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5002, 5, "Esposo/a", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5003, 5, "Hijo/a", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5004, 5, "Conyuge", "", 0.0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogosDescripciones_CatalogoId_CatalogoDescripcionId",
                table: "CatalogosDescripciones",
                columns: new[] { "CatalogoId", "CatalogoDescripcionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CargoID",
                table: "Empleado",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DepartamentoID",
                table: "Empleado",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Familiar_EmpleadoID",
                table: "Familiar",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Familiar_RelacionID",
                table: "Familiar",
                column: "RelacionID");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudVacaciones_EmpleadoID",
                table: "SolicitudVacaciones",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudVacaciones_EstatusID",
                table: "SolicitudVacaciones",
                column: "EstatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpleadoID",
                table: "Usuario",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_RolID",
                table: "UsuarioRol",
                column: "RolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Familiar");

            migrationBuilder.DropTable(
                name: "SolicitudVacaciones");

            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "CatalogosDescripciones");

            migrationBuilder.DropTable(
                name: "Catalogos");
        }
    }
}
