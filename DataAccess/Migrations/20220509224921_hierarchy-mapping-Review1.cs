using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class hierarchymappingReview1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenericDiscount",
                table: "GenericDiscount");

            migrationBuilder.DropColumn(
                name: "VoucherCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VoucherProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VoucherCategoryId",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "GenericDiscount",
                newName: "Discounts");

            migrationBuilder.RenameColumn(
                name: "VoucherType",
                table: "Vouchers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Discounts",
                newName: "Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CategoriesDiscountToApply",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesDiscountToApply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriesDiscountToApply_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesDiscountToApply_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExceptedDiscountProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptedDiscountProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExceptedDiscountProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExceptedDiscountProduct_Vouchers_VoucherCategoryId",
                        column: x => x.VoucherCategoryId,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExceptedDiscountProduct_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDiscountToApply",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscountToApply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDiscountToApply_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDiscountToApply_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDiscountToApply_Vouchers_VoucherProductId",
                        column: x => x.VoucherProductId,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesDiscountToApply_CategoryId",
                table: "CategoriesDiscountToApply",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesDiscountToApply_VoucherId",
                table: "CategoriesDiscountToApply",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptedDiscountProduct_ProductId",
                table: "ExceptedDiscountProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptedDiscountProduct_VoucherCategoryId",
                table: "ExceptedDiscountProduct",
                column: "VoucherCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptedDiscountProduct_VoucherId",
                table: "ExceptedDiscountProduct",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscountToApply_ProductId",
                table: "ProductDiscountToApply",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscountToApply_VoucherId",
                table: "ProductDiscountToApply",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscountToApply_VoucherProductId",
                table: "ProductDiscountToApply",
                column: "VoucherProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesDiscountToApply");

            migrationBuilder.DropTable(
                name: "ExceptedDiscountProduct");

            migrationBuilder.DropTable(
                name: "ProductDiscountToApply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "GenericDiscount");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Vouchers",
                newName: "VoucherType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "GenericDiscount",
                newName: "Discriminator");

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

            migrationBuilder.AddColumn<Guid>(
                name: "VoucherCategoryId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenericDiscount",
                table: "GenericDiscount",
                column: "Id");

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
    }
}
