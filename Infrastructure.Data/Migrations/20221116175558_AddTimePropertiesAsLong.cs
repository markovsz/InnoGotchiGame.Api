using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddTimePropertiesAsLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66596692-a9c7-4e5d-9dd4-ee0d548ae110"));

            migrationBuilder.AddColumn<long>(
                name: "ThirstQuenchingTime",
                table: "ThirstQuenchingEvents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BirthDate",
                table: "Pets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DeathDate",
                table: "Pets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LastPetDetailsUpdatingTime",
                table: "Pets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FeedingTime",
                table: "FeedingEvents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6217fe7c-7ef1-498c-a8e0-3297e7077bec"), "fd6a993b-e4de-409b-b6dd-96efcc26588e", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6217fe7c-7ef1-498c-a8e0-3297e7077bec"));

            migrationBuilder.DropColumn(
                name: "ThirstQuenchingTime",
                table: "ThirstQuenchingEvents");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "DeathDate",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "LastPetDetailsUpdatingTime",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "FeedingTime",
                table: "FeedingEvents");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("66596692-a9c7-4e5d-9dd4-ee0d548ae110"), "e3d0774f-b815-4a66-98ae-73bdaa04a33d", "user", "USER" });
        }
    }
}
