using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddBodyPartEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e07be452-e6dd-4b49-8553-1f329ed9e43a"));

            migrationBuilder.CreateTable(
                name: "PetBodies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetBodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetEyes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetEyes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetMouths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetMouths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetNoses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetNoses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("29ad261a-48a0-4b6a-9a8a-f3611e37370a"), "633087c0-9059-4692-92a9-dd907cc5d26d", "user", "USER" });

            migrationBuilder.InsertData(
                table: "PetBodies",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("f605429b-6ae6-45bc-9b44-b62f14f013c7"), "body5.svg" },
                    { new Guid("0f4c9045-2933-4ae4-8536-d4df34dd92bf"), "body4.svg" },
                    { new Guid("87bca347-99da-4630-8604-44908fd77263"), "body1.svg" },
                    { new Guid("5dfb68a9-f6f6-424f-a350-ae4533d8e7f7"), "body2.svg" },
                    { new Guid("0584bff3-1ed0-43fd-84f0-19064ce042f2"), "body3.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetEyes",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("a3135cb4-dfa8-4582-ad64-c294209b4d19"), "eyes1.svg" },
                    { new Guid("a5651b42-f29a-41d5-b0ba-6adc4a972961"), "eyes2.svg" },
                    { new Guid("1e10173c-c415-4281-9784-b9fd1c0a4eb8"), "eyes3.svg" },
                    { new Guid("bc89c2e3-9c01-4952-a82a-73aa3a65706b"), "eyes4.svg" },
                    { new Guid("57e6b495-1dca-4145-8b48-f92126fc29d3"), "eyes5.svg" },
                    { new Guid("a0b7dbcd-659c-4144-ada3-147096fd2b51"), "eyes6.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetMouths",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("4c088aa9-d75a-49a1-ac80-fc235b73ef7e"), "mouth5.svg" },
                    { new Guid("0002a49c-5c2f-4b03-897e-6cc1290a74ec"), "mouth4.svg" },
                    { new Guid("70d849c5-d04c-421e-99f8-b647bba4a0fe"), "mouth3.svg" },
                    { new Guid("92da74ba-9ad3-4255-873e-ab7f9dfd4b89"), "mouth2.svg" },
                    { new Guid("08ec721f-fe6e-4397-8ebc-0eecd2512b13"), "mouth1.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetNoses",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("b0619bbd-7127-4381-a9fd-6da66be791cc"), "nose6.svg" },
                    { new Guid("9b59c5b4-7504-46c1-b73f-483845c06e78"), "nose1.svg" },
                    { new Guid("31e257c1-55a2-49fc-b111-9f2963593441"), "nose2.svg" },
                    { new Guid("409544da-d5ae-418d-b834-6366cdddb1e2"), "nose3.svg" },
                    { new Guid("231484c4-4407-4b69-85bb-ad42eabfa15d"), "nose4.svg" },
                    { new Guid("784f6e08-affe-4dca-8657-a5440288a218"), "nose5.svg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetBodies");

            migrationBuilder.DropTable(
                name: "PetEyes");

            migrationBuilder.DropTable(
                name: "PetMouths");

            migrationBuilder.DropTable(
                name: "PetNoses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("29ad261a-48a0-4b6a-9a8a-f3611e37370a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e07be452-e6dd-4b49-8553-1f329ed9e43a"), "ff090b6d-3c16-45a3-a511-abea8e2afad8", "user", "USER" });
        }
    }
}
