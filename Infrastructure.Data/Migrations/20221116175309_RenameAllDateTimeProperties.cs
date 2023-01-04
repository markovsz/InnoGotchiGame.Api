using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RenameAllDateTimeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d67bae94-494d-40bd-9e15-82a1e2c22a49"));

            migrationBuilder.DropColumn(
                name: "InvitationKey",
                table: "UsersInfo");

            migrationBuilder.RenameColumn(
                name: "ThirstQuenchingTime",
                table: "ThirstQuenchingEvents",
                newName: "ThirstQuenchingTimeD");

            migrationBuilder.RenameColumn(
                name: "LastPetDetailsUpdatingTime",
                table: "Pets",
                newName: "LastPetDetailsUpdatingTimeD");

            migrationBuilder.RenameColumn(
                name: "DeathDate",
                table: "Pets",
                newName: "DeathDateD");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Pets",
                newName: "BirthDateD");

            migrationBuilder.RenameColumn(
                name: "FeedingTime",
                table: "FeedingEvents",
                newName: "FeedingTimeD");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("66596692-a9c7-4e5d-9dd4-ee0d548ae110"), "e3d0774f-b815-4a66-98ae-73bdaa04a33d", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66596692-a9c7-4e5d-9dd4-ee0d548ae110"));

            migrationBuilder.RenameColumn(
                name: "ThirstQuenchingTimeD",
                table: "ThirstQuenchingEvents",
                newName: "ThirstQuenchingTime");

            migrationBuilder.RenameColumn(
                name: "LastPetDetailsUpdatingTimeD",
                table: "Pets",
                newName: "LastPetDetailsUpdatingTime");

            migrationBuilder.RenameColumn(
                name: "DeathDateD",
                table: "Pets",
                newName: "DeathDate");

            migrationBuilder.RenameColumn(
                name: "BirthDateD",
                table: "Pets",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "FeedingTimeD",
                table: "FeedingEvents",
                newName: "FeedingTime");

            migrationBuilder.AddColumn<string>(
                name: "InvitationKey",
                table: "UsersInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d67bae94-494d-40bd-9e15-82a1e2c22a49"), "b220e640-ca0a-4d35-9813-6c401ce55519", "user", "USER" });
        }
    }
}
