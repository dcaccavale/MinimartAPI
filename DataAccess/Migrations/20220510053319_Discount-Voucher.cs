using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class DiscountVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiscountId",
                table: "Vouchers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_DiscountId",
                table: "Vouchers",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Discounts_DiscountId",
                table: "Vouchers",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Discounts_DiscountId",
                table: "Vouchers");

            migrationBuilder.DropIndex(
                name: "IX_Vouchers_DiscountId",
                table: "Vouchers");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Vouchers");
        }
    }
}
