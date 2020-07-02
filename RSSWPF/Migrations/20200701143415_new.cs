using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSSWPF.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SettedOn",
                table: "ChangeStatusHistories",
                newName: "SetOn");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ChangeStatusHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ChangeStatusHistories_ProductId",
                table: "ChangeStatusHistories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeStatusHistories_Products_ProductId",
                table: "ChangeStatusHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeStatusHistories_Products_ProductId",
                table: "ChangeStatusHistories");

            migrationBuilder.DropIndex(
                name: "IX_ChangeStatusHistories_ProductId",
                table: "ChangeStatusHistories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ChangeStatusHistories");

            migrationBuilder.RenameColumn(
                name: "SetOn",
                table: "ChangeStatusHistories",
                newName: "SettedOn");
        }
    }
}
