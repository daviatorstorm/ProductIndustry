using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIENN.WebApi.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Types_Products_Code",
                table: "Types");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Products_Code",
                table: "Units");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeCode",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UnitCode",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeCode",
                table: "Products",
                column: "TypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitCode",
                table: "Products",
                column: "UnitCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_TypeCode",
                table: "Products",
                column: "TypeCode",
                principalTable: "Types",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_UnitCode",
                table: "Products",
                column: "UnitCode",
                principalTable: "Units",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_TypeCode",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Units_UnitCode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypeCode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitCode",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Types_Products_Code",
                table: "Types",
                column: "Code",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Products_Code",
                table: "Units",
                column: "Code",
                principalTable: "Products",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
