using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MVC.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservasModel",
                columns: table => new
                {
                    NumeroReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreCiente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPersonas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasModel", x => x.NumeroReserva);
                });

            migrationBuilder.CreateTable(
                name: "VentasModel",
                columns: table => new
                {
                    NumeroOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasModel", x => x.NumeroOrden);
                });

            migrationBuilder.CreateTable(
                name: "PlatosModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    VentaNumeroOrden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatosModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatosModel_VentasModel_VentaNumeroOrden",
                        column: x => x.VentaNumeroOrden,
                        principalTable: "VentasModel",
                        principalColumn: "NumeroOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    platoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_PlatosModel_platoId",
                        column: x => x.platoId,
                        principalTable: "PlatosModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_platoId",
                table: "Categorias",
                column: "platoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatosModel_VentaNumeroOrden",
                table: "PlatosModel",
                column: "VentaNumeroOrden");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "ReservasModel");

            migrationBuilder.DropTable(
                name: "PlatosModel");

            migrationBuilder.DropTable(
                name: "VentasModel");
        }
    }
}
