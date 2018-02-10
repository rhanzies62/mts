using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mts.Infrastructure.Data.Migrations
{
    public partial class newtableupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessId",
                table: "Role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ApplicationFeature",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ApplicationFeature",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Role_BusinessId",
                table: "Role",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Business_BusinessId",
                table: "Role",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Business_BusinessId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_BusinessId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ApplicationFeature");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ApplicationFeature");
        }
    }
}
