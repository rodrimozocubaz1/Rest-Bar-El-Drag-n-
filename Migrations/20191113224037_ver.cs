using Microsoft.EntityFrameworkCore.Migrations;

namespace Rest_Bar_El_Drag_n_.Migrations
{
    public partial class ver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_AspNetUsers_UsuarioId",
                table: "Compras");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Compras",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Compras",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPago",
                table: "Compras",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_AspNetUsers_UsuarioId",
                table: "Compras",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_AspNetUsers_UsuarioId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "TipoPago",
                table: "Compras");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Compras",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Compras",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_AspNetUsers_UsuarioId",
                table: "Compras",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
