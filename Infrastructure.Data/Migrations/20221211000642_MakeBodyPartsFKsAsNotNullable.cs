using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class MakeBodyPartsFKsAsNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2815fc3b-77fd-4f3a-aa0f-51a7e038b179"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("1c362acf-c7c1-4cec-9a98-188d0a638ce0"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("2cd0fcf5-445c-4db7-8230-091106f2678e"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("6a810767-e665-483a-b5d0-454d002b462c"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("9d20a4a5-7e72-4b0c-b200-506e143deba7"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("adb04539-36b2-44af-8b27-a8085e684131"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("0eac09d8-a68d-4c5a-8bb7-7762e89b5737"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("553fec7b-1951-4093-91ff-95d8f290a58d"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("56bafcc5-5895-48fe-8d43-0d176f559ec2"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("5f3d130e-d0d1-43a0-adcb-2798698da8da"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("690f72a2-add7-44d4-89ec-f0a804c36069"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("8d0424d6-bacb-4ece-af97-bd5c69fd6735"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("2b098a09-b3c5-4f34-9504-3c022501a2d8"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("37db6fd5-18c9-4e93-96c3-b8c87bf8a7f4"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("446371b4-6151-4d6f-8a78-0c068812bab3"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("6293b4da-84e0-46df-93bb-332f00cc9322"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("e6fe3c44-ae45-465d-99d5-1b22c1328a86"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("5ca558cf-409f-4ec1-bde4-8632216bc6b3"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("7f6aaff4-e6f4-4806-b042-d571db120802"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("98630e08-6485-4e15-bc49-0853b29c1502"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("9b2207d0-2d03-4a2a-a107-8368ab1218ea"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("d51d5890-1e1c-44f3-bcd3-5c65d1909ffb"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("e879e1a6-c97d-4316-bf16-688768ea4086"));

            migrationBuilder.AlterColumn<Guid>(
                name: "NoseId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MouthId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EyesId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BodyId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d10077b0-1f6f-4af3-91af-6f21dab5c507"), "fe2a8b13-4eca-4cdd-9508-5b1c80cf8599", "user", "USER" });

            migrationBuilder.InsertData(
                table: "PetBodies",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("4238c4aa-4e98-4d8f-afc1-2cc5f6f78d33"), "body5.svg" },
                    { new Guid("d961ed82-9f5c-4a54-997e-82d222eeb310"), "body4.svg" },
                    { new Guid("eeb3126f-5421-401a-9f5e-eb101936d30c"), "body1.svg" },
                    { new Guid("3285f353-f5d9-4390-8429-08c63465a1f3"), "body2.svg" },
                    { new Guid("f8c0cf9b-9221-4b46-8e61-386434c9f124"), "body3.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetEyes",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("734bf663-48f5-4bb8-922f-a70004d78cad"), "eyes1.svg" },
                    { new Guid("b12cbcdc-c0f0-4cdf-8fec-f6810893f765"), "eyes2.svg" },
                    { new Guid("c6b70385-1f68-4f16-b1dc-9ca2d37ae0ff"), "eyes3.svg" },
                    { new Guid("64562f69-6e1e-4112-aaaa-c2419285fc48"), "eyes4.svg" },
                    { new Guid("0ac4c0aa-b4c5-46d3-a63d-c03f0804578b"), "eyes5.svg" },
                    { new Guid("d4eecee5-bcad-4447-9bd2-fd90691c5f52"), "eyes6.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetMouths",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("91274d57-d0ef-4cc5-a61a-21fa44ed49a0"), "mouth5.svg" },
                    { new Guid("1398a244-a1df-4979-bd76-724c16cce7c8"), "mouth4.svg" },
                    { new Guid("30d729b8-942c-43f1-a024-93165821c0ad"), "mouth3.svg" },
                    { new Guid("5fb6493f-891b-47fd-90e8-618c6c8b4858"), "mouth2.svg" },
                    { new Guid("754db423-3ce9-4d23-a8fa-73305ba840d2"), "mouth1.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetNoses",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("aa18337c-aa14-4ba9-a166-f9dea84d84bd"), "nose6.svg" },
                    { new Guid("92a44395-bf44-4ad7-a6f9-a1e5c3b3a399"), "nose1.svg" },
                    { new Guid("51e6953f-1b87-43da-98fc-1fac21a142a1"), "nose2.svg" },
                    { new Guid("a400fab5-369e-497f-a33d-c0bf3c732164"), "nose3.svg" },
                    { new Guid("a821f41e-9103-41de-89b3-490536a4226c"), "nose4.svg" },
                    { new Guid("b61ce33f-31ed-4dd3-b057-ad38d6a94a4a"), "nose5.svg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d10077b0-1f6f-4af3-91af-6f21dab5c507"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("3285f353-f5d9-4390-8429-08c63465a1f3"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("4238c4aa-4e98-4d8f-afc1-2cc5f6f78d33"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("d961ed82-9f5c-4a54-997e-82d222eeb310"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("eeb3126f-5421-401a-9f5e-eb101936d30c"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("f8c0cf9b-9221-4b46-8e61-386434c9f124"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("0ac4c0aa-b4c5-46d3-a63d-c03f0804578b"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("64562f69-6e1e-4112-aaaa-c2419285fc48"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("734bf663-48f5-4bb8-922f-a70004d78cad"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("b12cbcdc-c0f0-4cdf-8fec-f6810893f765"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("c6b70385-1f68-4f16-b1dc-9ca2d37ae0ff"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("d4eecee5-bcad-4447-9bd2-fd90691c5f52"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("1398a244-a1df-4979-bd76-724c16cce7c8"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("30d729b8-942c-43f1-a024-93165821c0ad"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("5fb6493f-891b-47fd-90e8-618c6c8b4858"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("754db423-3ce9-4d23-a8fa-73305ba840d2"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("91274d57-d0ef-4cc5-a61a-21fa44ed49a0"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("51e6953f-1b87-43da-98fc-1fac21a142a1"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("92a44395-bf44-4ad7-a6f9-a1e5c3b3a399"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("a400fab5-369e-497f-a33d-c0bf3c732164"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("a821f41e-9103-41de-89b3-490536a4226c"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("aa18337c-aa14-4ba9-a166-f9dea84d84bd"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("b61ce33f-31ed-4dd3-b057-ad38d6a94a4a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "NoseId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MouthId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EyesId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BodyId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2815fc3b-77fd-4f3a-aa0f-51a7e038b179"), "e84e1524-9e46-4805-8928-e22a66c7c072", "user", "USER" });

            migrationBuilder.InsertData(
                table: "PetBodies",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("6a810767-e665-483a-b5d0-454d002b462c"), "body5.svg" },
                    { new Guid("adb04539-36b2-44af-8b27-a8085e684131"), "body4.svg" },
                    { new Guid("9d20a4a5-7e72-4b0c-b200-506e143deba7"), "body1.svg" },
                    { new Guid("2cd0fcf5-445c-4db7-8230-091106f2678e"), "body2.svg" },
                    { new Guid("1c362acf-c7c1-4cec-9a98-188d0a638ce0"), "body3.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetEyes",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("0eac09d8-a68d-4c5a-8bb7-7762e89b5737"), "eyes1.svg" },
                    { new Guid("56bafcc5-5895-48fe-8d43-0d176f559ec2"), "eyes2.svg" },
                    { new Guid("5f3d130e-d0d1-43a0-adcb-2798698da8da"), "eyes3.svg" },
                    { new Guid("8d0424d6-bacb-4ece-af97-bd5c69fd6735"), "eyes4.svg" },
                    { new Guid("553fec7b-1951-4093-91ff-95d8f290a58d"), "eyes5.svg" },
                    { new Guid("690f72a2-add7-44d4-89ec-f0a804c36069"), "eyes6.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetMouths",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("e6fe3c44-ae45-465d-99d5-1b22c1328a86"), "mouth5.svg" },
                    { new Guid("6293b4da-84e0-46df-93bb-332f00cc9322"), "mouth4.svg" },
                    { new Guid("446371b4-6151-4d6f-8a78-0c068812bab3"), "mouth3.svg" },
                    { new Guid("2b098a09-b3c5-4f34-9504-3c022501a2d8"), "mouth2.svg" },
                    { new Guid("37db6fd5-18c9-4e93-96c3-b8c87bf8a7f4"), "mouth1.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetNoses",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("5ca558cf-409f-4ec1-bde4-8632216bc6b3"), "nose6.svg" },
                    { new Guid("9b2207d0-2d03-4a2a-a107-8368ab1218ea"), "nose1.svg" },
                    { new Guid("98630e08-6485-4e15-bc49-0853b29c1502"), "nose2.svg" },
                    { new Guid("e879e1a6-c97d-4316-bf16-688768ea4086"), "nose3.svg" },
                    { new Guid("7f6aaff4-e6f4-4806-b042-d571db120802"), "nose4.svg" },
                    { new Guid("d51d5890-1e1c-44f3-bcd3-5c65d1909ffb"), "nose5.svg" }
                });
        }
    }
}
