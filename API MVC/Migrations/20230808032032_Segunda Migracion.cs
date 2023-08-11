using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_MVC.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_PlatosModel_platoId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_PlatosModel_VentasModel_VentaNumeroOrden",
                table: "PlatosModel");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_platoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "platoId",
                table: "Categorias");

            migrationBuilder.RenameColumn(
                name: "VentaNumeroOrden",
                table: "PlatosModel",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_PlatosModel_VentaNumeroOrden",
                table: "PlatosModel",
                newName: "IX_PlatosModel_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Categorias",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "PlatoId",
                table: "VentasModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VentasModel_PlatoId",
                table: "VentasModel",
                column: "PlatoId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlatosModel_Categorias_CategoriaId",
                table: "PlatosModel");

            migrationBuilder.DropForeignKey(
                name: "FK_VentasModel_PlatosModel_PlatoId",
                table: "VentasModel");

            migrationBuilder.DropIndex(
                name: "IX_VentasModel_PlatoId",
                table: "VentasModel");

            migrationBuilder.DropColumn(
                name: "PlatoId",
                table: "VentasModel");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "PlatosModel",
                newName: "VentaNumeroOrden");

            migrationBuilder.RenameIndex(
                name: "IX_PlatosModel_CategoriaId",
                table: "PlatosModel",
                newName: "IX_PlatosModel_VentaNumeroOrden");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Categorias",
                newName: "nombre");

            migrationBuilder.AddColumn<int>(
                name: "platoId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_platoId",
                table: "Categorias",
                column: "platoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_PlatosModel_platoId",
                table: "Categorias",
                column: "platoId",
                principalTable: "PlatosModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlatosModel_VentasModel_VentaNumeroOrden",
                table: "PlatosModel",
                column: "VentaNumeroOrden",
                principalTable: "VentasModel",
                principalColumn: "NumeroOrden",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
