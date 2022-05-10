using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class hierarchymappingVoucherAndDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProduct_Carts_CartId",
                table: "ItemProduct");

            migrationBuilder.RenameColumn(
                name: "Amound",
                table: "StockProducts",
                newName: "Quantity");

            migrationBuilder.AddColumn<string>(
                name: "DaysOfWeek",
                table: "Vouchers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Vouchers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "ItemProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalAmound",
                table: "ItemProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherAppledId",
                table: "ItemProduct",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GenericDiscount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericDiscount", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_StoreId",
                table: "Vouchers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemProduct_VoucherAppledId",
                table: "ItemProduct",
                column: "VoucherAppledId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProduct_Carts_CartId",
                table: "ItemProduct",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProduct_Vouchers_VoucherAppledId",
                table: "ItemProduct",
                column: "VoucherAppledId",
                principalTable: "Vouchers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Stores_StoreId",
                table: "Vouchers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProduct_Carts_CartId",
                table: "ItemProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemProduct_Vouchers_VoucherAppledId",
                table: "ItemProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Stores_StoreId",
                table: "Vouchers");

            migrationBuilder.DropTable(
                name: "GenericDiscount");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_StoreId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_ItemProduct_VoucherAppledId",
                table: "ItemProduct");

            migrationBuilder.DropColumn(
                name: "DaysOfWeek",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "TotalAmound",
                table: "ItemProduct");

            migrationBuilder.DropColumn(
                name: "VoucherAppledId",
                table: "ItemProduct");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "StockProducts",
                newName: "Amound");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "ItemProduct",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProduct_Carts_CartId",
                table: "ItemProduct",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
