using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class hierarchymappingVoucherAndDiscount2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Vouchers",
                newName: "VoucherType");

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherCategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherProductId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayCount",
                table: "GenericDiscount",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                table: "GenericDiscount",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TakeCount",
                table: "GenericDiscount",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherCategoryId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_VoucherCategoryId",
                table: "Products",
                column: "VoucherCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VoucherProductId",
                table: "Products",
                column: "VoucherProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_VoucherCategoryId",
                table: "Categories",
                column: "VoucherCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Vouchers_VoucherCategoryId",
                table: "Categories",
                column: "VoucherCategoryId",
                principalTable: "Vouchers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vouchers_VoucherCategoryId",
                table: "Products",
                column: "VoucherCategoryId",
                principalTable: "Vouchers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Vouchers_VoucherProductId",
                table: "Products",
                column: "VoucherProductId",
                principalTable: "Vouchers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Vouchers_VoucherCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Vouchers_VoucherCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Vouchers_VoucherProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VoucherCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_VoucherProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_VoucherCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "VoucherCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VoucherProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PayCount",
                table: "GenericDiscount");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "GenericDiscount");

            migrationBuilder.DropColumn(
                name: "TakeCount",
                table: "GenericDiscount");

            migrationBuilder.DropColumn(
                name: "VoucherCategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "VoucherType",
                table: "Vouchers",
                newName: "Discriminator");
        }
    }
}
