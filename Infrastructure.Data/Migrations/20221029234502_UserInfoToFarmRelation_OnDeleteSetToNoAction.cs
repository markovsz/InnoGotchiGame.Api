using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UserInfoToFarmRelation_OnDeleteSetToNoAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmFriends_UsersInfo_UserId",
                table: "FarmFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_UsersInfo_UserId",
                table: "Farms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a501116-95a0-4fee-b734-f9dde8ee89da"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c3f9e1a6-8f6d-448b-a7b9-4f28a63e3924"), "5d5296d6-7c8e-48ac-9fce-46ec423d95fd", "user", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_FarmFriends_UsersInfo_UserId",
                table: "FarmFriends",
                column: "UserId",
                principalTable: "UsersInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_UsersInfo_UserId",
                table: "Farms",
                column: "UserId",
                principalTable: "UsersInfo",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmFriends_UsersInfo_UserId",
                table: "FarmFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_UsersInfo_UserId",
                table: "Farms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3f9e1a6-8f6d-448b-a7b9-4f28a63e3924"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4a501116-95a0-4fee-b734-f9dde8ee89da"), "11dc74f8-62c2-426e-954d-bd6d18026d58", "user", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_FarmFriends_UsersInfo_UserId",
                table: "FarmFriends",
                column: "UserId",
                principalTable: "UsersInfo",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_UsersInfo_UserId",
                table: "Farms",
                column: "UserId",
                principalTable: "UsersInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
