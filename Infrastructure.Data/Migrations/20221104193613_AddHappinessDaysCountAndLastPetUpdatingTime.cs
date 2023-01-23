using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddHappinessDaysCountAndLastPetUpdatingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3f9e1a6-8f6d-448b-a7b9-4f28a63e3924"));

            migrationBuilder.AddColumn<string>(
                name: "InvitationKey",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HappinessDaysCount",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPetDetailsUpdatingTime",
                table: "Pets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d67bae94-494d-40bd-9e15-82a1e2c22a49"), "b220e640-ca0a-4d35-9813-6c401ce55519", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d67bae94-494d-40bd-9e15-82a1e2c22a49"));

            migrationBuilder.DropColumn(
                name: "InvitationKey",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "HappinessDaysCount",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "LastPetDetailsUpdatingTime",
                table: "Pets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c3f9e1a6-8f6d-448b-a7b9-4f28a63e3924"), "5d5296d6-7c8e-48ac-9fce-46ec423d95fd", "user", "USER" });
        }
    }
}
