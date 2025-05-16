using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Infrastrucutre.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsOrdereds_Products_ProductId",
                table: "ItemsOrdereds");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ItemsOrdereds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdcutId",
                table: "ItemsOrdereds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsOrdereds_Products_ProductId",
                table: "ItemsOrdereds",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsOrdereds_Products_ProductId",
                table: "ItemsOrdereds");

            migrationBuilder.DropColumn(
                name: "ProdcutId",
                table: "ItemsOrdereds");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ItemsOrdereds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsOrdereds_Products_ProductId",
                table: "ItemsOrdereds",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
