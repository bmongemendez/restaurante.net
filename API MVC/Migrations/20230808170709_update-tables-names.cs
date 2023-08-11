using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MVC.Migrations
{
    /// <inheritdoc />
    public partial class updatetablesnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatosModel_Categorias_CategoriaId",
                table: "PlatosModel");

            migrationBuilder.DropForeignKey(
                name: "FK_VentasModel_PlatosModel_PlatoId",
                table: "VentasModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentasModel",
                table: "VentasModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservasModel",
                table: "ReservasModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlatosModel",
                table: "PlatosModel");

            migrationBuilder.RenameTable(
                name: "VentasModel",
                newName: "Ventas");

            migrationBuilder.RenameTable(
                name: "ReservasModel",
                newName: "Reservas");

            migrationBuilder.RenameTable(
                name: "PlatosModel",
                newName: "Platos");

            migrationBuilder.RenameIndex(
                name: "IX_VentasModel_PlatoId",
                table: "Ventas",
                newName: "IX_Ventas_PlatoId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatosModel_CategoriaId",
                table: "Platos",
                newName: "IX_Platos_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas",
                column: "NumeroOrden");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas",
                column: "NumeroReserva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Platos",
                table: "Platos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Categorias_CategoriaId",
                table: "Platos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Platos_PlatoId",
                table: "Ventas",
                column: "PlatoId",
                principalTable: "Platos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Categorias_CategoriaId",
                table: "Platos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Platos_PlatoId",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ventas",
                table: "Ventas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservas",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Platos",
                table: "Platos");

            migrationBuilder.RenameTable(
                name: "Ventas",
                newName: "VentasModel");

            migrationBuilder.RenameTable(
                name: "Reservas",
                newName: "ReservasModel");

            migrationBuilder.RenameTable(
                name: "Platos",
                newName: "PlatosModel");

            migrationBuilder.RenameIndex(
                name: "IX_Ventas_PlatoId",
                table: "VentasModel",
                newName: "IX_VentasModel_PlatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Platos_CategoriaId",
                table: "PlatosModel",
                newName: "IX_PlatosModel_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentasModel",
                table: "VentasModel",
                column: "NumeroOrden");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservasModel",
                table: "ReservasModel",
                column: "NumeroReserva");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlatosModel",
                table: "PlatosModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlatosModel_Categorias_CategoriaId",
                table: "PlatosModel",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VentasModel_PlatosModel_PlatoId",
                table: "VentasModel",
                column: "PlatoId",
                principalTable: "PlatosModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
