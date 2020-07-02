using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RSSWPF.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeStatusHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SettedOn = table.Column<DateTime>(type: "datetime2", maxLength: 250, nullable: false),
                    StatusFromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeStatusHistories_ProductStatuses_StatusFromId",
                        column: x => x.StatusFromId,
                        principalTable: "ProductStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ChangeStatusHistories_ProductStatuses_StatusToId",
                        column: x => x.StatusToId,
                        principalTable: "ProductStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProductStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeStatusHistories_StatusFromId",
                table: "ChangeStatusHistories",
                column: "StatusFromId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeStatusHistories_StatusToId",
                table: "ChangeStatusHistories",
                column: "StatusToId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatusId",
                table: "Products",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeStatusHistories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductStatuses");
        }
    }
}
