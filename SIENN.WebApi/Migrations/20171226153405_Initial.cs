using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIENN.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Code = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Code = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Code = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Code = table.Column<Guid>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TypeCode = table.Column<Guid>(nullable: false),
                    UnitCode = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Products_Types_TypeCode",
                        column: x => x.TypeCode,
                        principalTable: "Types",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitCode",
                        column: x => x.UnitCode,
                        principalTable: "Units",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoryCode = table.Column<Guid>(nullable: false),
                    ProductCode = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoryCode, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoryCode",
                        column: x => x.CategoryCode,
                        principalTable: "Categories",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductCode",
                table: "CategoryProduct",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeCode",
                table: "Products",
                column: "TypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitCode",
                table: "Products",
                column: "UnitCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
