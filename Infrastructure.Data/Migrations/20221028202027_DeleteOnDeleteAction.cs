using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class DeleteOnDeleteAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmFriends_Farms_FarmId",
                table: "FarmFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_UsersInfo_UserId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedingEvents_Pets_PetId",
                table: "FeedingEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Farms_FarmId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirstQuenchingEvents_Pets_PetId",
                table: "ThirstQuenchingEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_AspNetUsers_UserId",
                table: "UsersInfo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bbcec87c-0122-47ad-8872-204df42106db"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("4a501116-95a0-4fee-b734-f9dde8ee89da"), "11dc74f8-62c2-426e-954d-bd6d18026d58", "user", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_FarmFriends_Farms_FarmId",
                table: "FarmFriends",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_UsersInfo_UserId",
                table: "Farms",
                column: "UserId",
                principalTable: "UsersInfo",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingEvents_Pets_PetId",
                table: "FeedingEvents",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Farms_FarmId",
                table: "Pets",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirstQuenchingEvents_Pets_PetId",
                table: "ThirstQuenchingEvents",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_AspNetUsers_UserId",
                table: "UsersInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmFriends_Farms_FarmId",
                table: "FarmFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_Farms_UsersInfo_UserId",
                table: "Farms");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedingEvents_Pets_PetId",
                table: "FeedingEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Farms_FarmId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_ThirstQuenchingEvents_Pets_PetId",
                table: "ThirstQuenchingEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_AspNetUsers_UserId",
                table: "UsersInfo");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a501116-95a0-4fee-b734-f9dde8ee89da"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("bbcec87c-0122-47ad-8872-204df42106db"), "316eda8f-c653-4aeb-91fb-209500ee3846", "user", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_FarmFriends_Farms_FarmId",
                table: "FarmFriends",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_UsersInfo_UserId",
                table: "Farms",
                column: "UserId",
                principalTable: "UsersInfo",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingEvents_Pets_PetId",
                table: "FeedingEvents",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Farms_FarmId",
                table: "Pets",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThirstQuenchingEvents_Pets_PetId",
                table: "ThirstQuenchingEvents",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_AspNetUsers_UserId",
                table: "UsersInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
