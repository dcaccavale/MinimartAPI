using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ItemProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddProductCart_Carts_CartId",
                table: "AddProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_AddProductCart_Products_ProductId",
                table: "AddProductCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddProductCart",
                table: "AddProductCart");

            migrationBuilder.RenameTable(
                name: "AddProductCart",
                newName: "ItemProduct");

            migrationBuilder.RenameIndex(
                name: "IX_AddProductCart_ProductId",
                table: "ItemProduct",
                newName: "IX_ItemProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AddProductCart_CartId",
                table: "ItemProduct",
                newName: "IX_ItemProduct_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemProduct",
                table: "ItemProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProduct_Carts_CartId",
                table: "ItemProduct",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProduct_Products_ProductId",
                table: "ItemProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProduct_Carts_CartId",
                table: "ItemProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemProduct_Products_ProductId",
                table: "ItemProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemProduct",
                table: "ItemProduct");

            migrationBuilder.RenameTable(
                name: "ItemProduct",
                newName: "AddProductCart");

            migrationBuilder.RenameIndex(
                name: "IX_ItemProduct_ProductId",
                table: "AddProductCart",
                newName: "IX_AddProductCart_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemProduct_CartId",
                table: "AddProductCart",
                newName: "IX_AddProductCart_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddProductCart",
                table: "AddProductCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddProductCart_Carts_CartId",
                table: "AddProductCart",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddProductCart_Products_ProductId",
                table: "AddProductCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
