using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitialVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddProductCart_Products_productId",
                table: "AddProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Products_productId",
                table: "StockProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Stores_storeId",
                table: "StockProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_RangeDate_rangeDateId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "dayOfWeek",
                table: "Vouchers");

            migrationBuilder.RenameColumn(
                name: "rangeDateId",
                table: "Vouchers",
                newName: "RangeDateId");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Vouchers",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_Vouchers_rangeDateId",
                table: "Vouchers",
                newName: "IX_Vouchers_RangeDateId");

            migrationBuilder.RenameColumn(
                name: "workdays",
                table: "Stores",
                newName: "Workdays");

            migrationBuilder.RenameColumn(
                name: "hours",
                table: "Stores",
                newName: "Hours");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Stores",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "storeId",
                table: "StockProducts",
                newName: "StoreId");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "StockProducts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "StockProducts",
                newName: "Amoun");

            migrationBuilder.RenameIndex(
                name: "IX_StockProducts_storeId",
                table: "StockProducts",
                newName: "IX_StockProducts_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_StockProducts_productId",
                table: "StockProducts",
                newName: "IX_StockProducts_ProductId");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "AddProductCart",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "AddProductCart",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "priceUnit",
                table: "AddProductCart",
                newName: "PriceUnit");

            migrationBuilder.RenameIndex(
                name: "IX_AddProductCart_productId",
                table: "AddProductCart",
                newName: "IX_AddProductCart_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Vouchers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Client",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_AddProductCart_Products_ProductId",
                table: "AddProductCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Products_ProductId",
                table: "StockProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Stores_StoreId",
                table: "StockProducts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_RangeDate_RangeDateId",
                table: "Vouchers",
                column: "RangeDateId",
                principalTable: "RangeDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddProductCart_Products_ProductId",
                table: "AddProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Products_ProductId",
                table: "StockProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Stores_StoreId",
                table: "StockProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_RangeDate_RangeDateId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Vouchers");

            migrationBuilder.RenameColumn(
                name: "RangeDateId",
                table: "Vouchers",
                newName: "rangeDateId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Vouchers",
                newName: "code");

            migrationBuilder.RenameIndex(
                name: "IX_Vouchers_RangeDateId",
                table: "Vouchers",
                newName: "IX_Vouchers_rangeDateId");

            migrationBuilder.RenameColumn(
                name: "Workdays",
                table: "Stores",
                newName: "workdays");

            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "Stores",
                newName: "hours");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Stores",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "StockProducts",
                newName: "storeId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "StockProducts",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Amoun",
                table: "StockProducts",
                newName: "amount");

            migrationBuilder.RenameIndex(
                name: "IX_StockProducts_StoreId",
                table: "StockProducts",
                newName: "IX_StockProducts_storeId");

            migrationBuilder.RenameIndex(
                name: "IX_StockProducts_ProductId",
                table: "StockProducts",
                newName: "IX_StockProducts_productId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "AddProductCart",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "AddProductCart",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "PriceUnit",
                table: "AddProductCart",
                newName: "priceUnit");

            migrationBuilder.RenameIndex(
                name: "IX_AddProductCart_ProductId",
                table: "AddProductCart",
                newName: "IX_AddProductCart_productId");

            migrationBuilder.AddColumn<int>(
                name: "dayOfWeek",
                table: "Vouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Client",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AddProductCart_Products_productId",
                table: "AddProductCart",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Products_productId",
                table: "StockProducts",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Stores_storeId",
                table: "StockProducts",
                column: "storeId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_RangeDate_rangeDateId",
                table: "Vouchers",
                column: "rangeDateId",
                principalTable: "RangeDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
