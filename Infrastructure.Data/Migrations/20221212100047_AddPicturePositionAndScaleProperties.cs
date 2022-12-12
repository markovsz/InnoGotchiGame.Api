using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddPicturePositionAndScaleProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<float>(
                name: "BodyPictureScale",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "BodyPictureX",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodyPictureY",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "EyesPictureScale",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "EyesPictureX",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EyesPictureY",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MouthPictureScale",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "MouthPictureX",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MouthPictureY",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "NosePictureScale",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NosePictureX",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NosePictureY",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("84192b58-815d-47f0-a05d-c4370ec8ab2b"), "d84b4c8f-e265-482d-9344-04e8d35d7ac0", "user", "USER" });

            migrationBuilder.InsertData(
                table: "PetBodies",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("6097c11f-168a-4a9b-bf72-85e135c428b3"), "body5.svg" },
                    { new Guid("64740897-c7c1-45be-8487-03eb46f4c885"), "body4.svg" },
                    { new Guid("686fcc2b-bc4c-462c-b1d8-0626fa83b79f"), "body1.svg" },
                    { new Guid("e06841c3-b0be-494b-9945-e2bdbf939f62"), "body2.svg" },
                    { new Guid("66042d94-c41d-4b22-ad9f-188bec102e76"), "body3.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetEyes",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("16aca063-e1d6-4565-9428-eb70796524f7"), "eyes1.svg" },
                    { new Guid("afa33b26-5134-45a3-ae0b-53835444cde2"), "eyes2.svg" },
                    { new Guid("eb96250d-7352-4372-a66b-e57e1f7b3fe2"), "eyes3.svg" },
                    { new Guid("46cbdf3d-9f2e-47c2-ac18-540b8164ef29"), "eyes4.svg" },
                    { new Guid("e9b80f5a-df15-4989-84ef-7cfe45a77048"), "eyes5.svg" },
                    { new Guid("b55778f4-d8e9-49a6-b5fb-5def3c3cffcd"), "eyes6.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetMouths",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("1d9c2b6e-a515-4602-bcfc-27221d241375"), "mouth5.svg" },
                    { new Guid("e6d5b118-02b4-41ba-9ed0-520314a0755d"), "mouth4.svg" },
                    { new Guid("ac9c2ac8-2c69-41fb-9c28-2d7c9e9a5b37"), "mouth3.svg" },
                    { new Guid("620b66c1-160c-4c81-ac10-49375aab26ce"), "mouth2.svg" },
                    { new Guid("9727d94f-2ddd-4e88-a542-9adf6133c3dc"), "mouth1.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetNoses",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("6ff5eeb0-3a7b-4483-949a-fdf329b91fde"), "nose6.svg" },
                    { new Guid("f03fbc63-088f-4d53-bf7a-a775a73d4182"), "nose1.svg" },
                    { new Guid("a0662f61-fd12-4fb3-aa64-6b5054195243"), "nose2.svg" },
                    { new Guid("c6aa1087-2cec-4d4f-8362-37ae2c6bc0f4"), "nose3.svg" },
                    { new Guid("da30c7bd-f2db-4793-8ae4-b5817ee83860"), "nose4.svg" },
                    { new Guid("c7393c86-2a6a-44b7-aef9-4c15559c51ed"), "nose5.svg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("84192b58-815d-47f0-a05d-c4370ec8ab2b"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("6097c11f-168a-4a9b-bf72-85e135c428b3"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("64740897-c7c1-45be-8487-03eb46f4c885"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("66042d94-c41d-4b22-ad9f-188bec102e76"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("686fcc2b-bc4c-462c-b1d8-0626fa83b79f"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("e06841c3-b0be-494b-9945-e2bdbf939f62"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("16aca063-e1d6-4565-9428-eb70796524f7"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("46cbdf3d-9f2e-47c2-ac18-540b8164ef29"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("afa33b26-5134-45a3-ae0b-53835444cde2"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("b55778f4-d8e9-49a6-b5fb-5def3c3cffcd"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("e9b80f5a-df15-4989-84ef-7cfe45a77048"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("eb96250d-7352-4372-a66b-e57e1f7b3fe2"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("1d9c2b6e-a515-4602-bcfc-27221d241375"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("620b66c1-160c-4c81-ac10-49375aab26ce"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("9727d94f-2ddd-4e88-a542-9adf6133c3dc"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("ac9c2ac8-2c69-41fb-9c28-2d7c9e9a5b37"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("e6d5b118-02b4-41ba-9ed0-520314a0755d"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("6ff5eeb0-3a7b-4483-949a-fdf329b91fde"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("a0662f61-fd12-4fb3-aa64-6b5054195243"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("c6aa1087-2cec-4d4f-8362-37ae2c6bc0f4"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("c7393c86-2a6a-44b7-aef9-4c15559c51ed"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("da30c7bd-f2db-4793-8ae4-b5817ee83860"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("f03fbc63-088f-4d53-bf7a-a775a73d4182"));

            migrationBuilder.DropColumn(
                name: "BodyPictureScale",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BodyPictureX",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "BodyPictureY",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "EyesPictureScale",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "EyesPictureX",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "EyesPictureY",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "MouthPictureScale",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "MouthPictureX",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "MouthPictureY",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "NosePictureScale",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "NosePictureX",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "NosePictureY",
                table: "Pets");

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
    }
}
