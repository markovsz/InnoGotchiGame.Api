using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RemoveAllDateTimeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6217fe7c-7ef1-498c-a8e0-3297e7077bec"));

            migrationBuilder.DropColumn(
                name: "ThirstQuenchingTimeD",
                table: "ThirstQuenchingEvents");

            migrationBuilder.DropColumn(
                name: "BirthDateD",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "DeathDateD",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "LastPetDetailsUpdatingTimeD",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "FeedingTimeD",
                table: "FeedingEvents");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e07be452-e6dd-4b49-8553-1f329ed9e43a"), "ff090b6d-3c16-45a3-a511-abea8e2afad8", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e07be452-e6dd-4b49-8553-1f329ed9e43a"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ThirstQuenchingTimeD",
                table: "ThirstQuenchingEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDateD",
                table: "Pets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeathDateD",
                table: "Pets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPetDetailsUpdatingTimeD",
                table: "Pets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FeedingTimeD",
                table: "FeedingEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6217fe7c-7ef1-498c-a8e0-3297e7077bec"), "fd6a993b-e4de-409b-b6dd-96efcc26588e", "user", "USER" });
        }
    }
}
