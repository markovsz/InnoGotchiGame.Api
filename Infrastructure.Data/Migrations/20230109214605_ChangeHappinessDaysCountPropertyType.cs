using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class ChangeHappinessDaysCountPropertyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5228430a-f33d-44a2-9f72-c7c89342d4c7"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("5d72fdbb-fc4d-4701-b452-2d8fd6433d51"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("79728da6-bb68-46de-80e1-d6407ff04170"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("7bbce661-b7a9-4638-a4c6-93370dd34685"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("9305eed8-561a-40ab-b1c3-419a1b734295"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("ea9f404c-86aa-461e-9cc9-beefe839d1ee"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("806f751d-8e6f-42ce-b3d3-f9e53fb49954"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("85fbd86a-2621-4c40-b34e-b69431cea7eb"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("867dfb5c-ead6-4434-be3d-53e379192fb8"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("8db17680-fb9e-40e1-ad1b-fa0a09897a86"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("b5c3a3ed-e9de-4610-9485-da45f6ca1da7"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("e0c3b0b6-4a7d-47e1-931b-3ba1495acc8d"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("0a63d64e-b7d8-4ba8-88c8-ed707e5a2de8"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("1178251e-7ae9-4bae-82ea-07b8a44ba9cf"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("1e2c214f-49ce-40ff-9e16-8d8aeda36fe3"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("9f6013b1-020f-4121-a8b3-9c3929d687d4"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("a6353dfc-55ea-4e81-82bc-245492089646"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("1c3cce28-e42a-4529-9e6b-fb408de25aea"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("21c584d0-6d46-4f2d-92f3-b374fd3dd0e1"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("22786959-e3bf-43e9-bb35-5eaefcf8f1a8"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("22eb787f-52be-4fae-ab5c-20f1269efa24"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("56bc0350-89c8-453f-9399-d983fbaa1561"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("edb7a31f-f412-470f-b044-62d455c401d2"));

            migrationBuilder.AlterColumn<double>(
                name: "HappinessDaysCount",
                table: "Pets",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0cecf2c7-99f5-4aaa-a838-bdff8a26dcd6"), "ecd1b52f-87e5-431f-9630-dbfbe5fc26a0", "user", "USER" });

            migrationBuilder.InsertData(
                table: "PetBodies",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("3f5e5c0b-3c72-4e62-a104-84f5ca67bc6a"), "body5.svg" },
                    { new Guid("eb944fd4-d048-4841-8eef-122382c16368"), "body4.svg" },
                    { new Guid("638c22cf-c263-4c54-aec2-d61e19926104"), "body1.svg" },
                    { new Guid("3a4105e7-9400-4ca2-b219-4547c1f403df"), "body2.svg" },
                    { new Guid("907b67b6-a734-4484-8803-ca83345dc1fe"), "body3.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetEyes",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("b42b1b86-2951-4a76-a94a-5faf4f8fbeca"), "eyes1.svg" },
                    { new Guid("06d190c6-a65b-4724-bee1-e77f9123a013"), "eyes2.svg" },
                    { new Guid("73e8c8d8-cd0c-489d-9395-5aef716fe6cf"), "eyes3.svg" },
                    { new Guid("6cf7bec9-6a46-4254-9042-6799abc55fe4"), "eyes4.svg" },
                    { new Guid("c95e34a9-c31b-4cea-9448-c75b46543e15"), "eyes5.svg" },
                    { new Guid("cbd51b6a-f471-44b7-8bc5-bba0f6419597"), "eyes6.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetMouths",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("ada1a20c-bae3-44c9-a9c3-a5e6dd3d7e85"), "mouth5.svg" },
                    { new Guid("963084a5-5344-46c6-bd10-f46abd41e248"), "mouth4.svg" },
                    { new Guid("70aa064e-9906-45a9-8836-f45eaeb4365c"), "mouth3.svg" },
                    { new Guid("3f6701dd-0339-4269-bef2-c96b97cd6df1"), "mouth2.svg" },
                    { new Guid("85a51344-9854-4bfd-aa34-514de6f9bfe8"), "mouth1.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetNoses",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("346339df-3558-48c6-99e2-d2e8d891ee3f"), "nose6.svg" },
                    { new Guid("cef37ad9-e5bf-438e-84cf-c07fc6fc77e2"), "nose1.svg" },
                    { new Guid("623107d8-6114-47af-9f7a-611d15728e5d"), "nose2.svg" },
                    { new Guid("7caf962c-30dd-4a6c-98c8-edb403233acd"), "nose3.svg" },
                    { new Guid("709df7fe-d5e5-4283-8900-bc491927776e"), "nose4.svg" },
                    { new Guid("ba1eb6ee-e045-497e-89d3-a272e9c676f5"), "nose5.svg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0cecf2c7-99f5-4aaa-a838-bdff8a26dcd6"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("3a4105e7-9400-4ca2-b219-4547c1f403df"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("3f5e5c0b-3c72-4e62-a104-84f5ca67bc6a"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("638c22cf-c263-4c54-aec2-d61e19926104"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("907b67b6-a734-4484-8803-ca83345dc1fe"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("eb944fd4-d048-4841-8eef-122382c16368"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("06d190c6-a65b-4724-bee1-e77f9123a013"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("6cf7bec9-6a46-4254-9042-6799abc55fe4"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("73e8c8d8-cd0c-489d-9395-5aef716fe6cf"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("b42b1b86-2951-4a76-a94a-5faf4f8fbeca"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("c95e34a9-c31b-4cea-9448-c75b46543e15"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("cbd51b6a-f471-44b7-8bc5-bba0f6419597"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("3f6701dd-0339-4269-bef2-c96b97cd6df1"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("70aa064e-9906-45a9-8836-f45eaeb4365c"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("85a51344-9854-4bfd-aa34-514de6f9bfe8"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("963084a5-5344-46c6-bd10-f46abd41e248"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("ada1a20c-bae3-44c9-a9c3-a5e6dd3d7e85"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("346339df-3558-48c6-99e2-d2e8d891ee3f"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("623107d8-6114-47af-9f7a-611d15728e5d"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("709df7fe-d5e5-4283-8900-bc491927776e"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("7caf962c-30dd-4a6c-98c8-edb403233acd"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("ba1eb6ee-e045-497e-89d3-a272e9c676f5"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("cef37ad9-e5bf-438e-84cf-c07fc6fc77e2"));

            migrationBuilder.AlterColumn<int>(
                name: "HappinessDaysCount",
                table: "Pets",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5228430a-f33d-44a2-9f72-c7c89342d4c7"), "9c8b5d08-bcb1-46e3-9ca2-72df8f5f6861", "user", "USER" });

            migrationBuilder.InsertData(
                table: "PetBodies",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("79728da6-bb68-46de-80e1-d6407ff04170"), "body5.svg" },
                    { new Guid("ea9f404c-86aa-461e-9cc9-beefe839d1ee"), "body4.svg" },
                    { new Guid("9305eed8-561a-40ab-b1c3-419a1b734295"), "body1.svg" },
                    { new Guid("5d72fdbb-fc4d-4701-b452-2d8fd6433d51"), "body2.svg" },
                    { new Guid("7bbce661-b7a9-4638-a4c6-93370dd34685"), "body3.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetEyes",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("e0c3b0b6-4a7d-47e1-931b-3ba1495acc8d"), "eyes1.svg" },
                    { new Guid("85fbd86a-2621-4c40-b34e-b69431cea7eb"), "eyes2.svg" },
                    { new Guid("b5c3a3ed-e9de-4610-9485-da45f6ca1da7"), "eyes3.svg" },
                    { new Guid("8db17680-fb9e-40e1-ad1b-fa0a09897a86"), "eyes4.svg" },
                    { new Guid("806f751d-8e6f-42ce-b3d3-f9e53fb49954"), "eyes5.svg" },
                    { new Guid("867dfb5c-ead6-4434-be3d-53e379192fb8"), "eyes6.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetMouths",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("a6353dfc-55ea-4e81-82bc-245492089646"), "mouth5.svg" },
                    { new Guid("9f6013b1-020f-4121-a8b3-9c3929d687d4"), "mouth4.svg" },
                    { new Guid("1178251e-7ae9-4bae-82ea-07b8a44ba9cf"), "mouth3.svg" },
                    { new Guid("1e2c214f-49ce-40ff-9e16-8d8aeda36fe3"), "mouth2.svg" },
                    { new Guid("0a63d64e-b7d8-4ba8-88c8-ed707e5a2de8"), "mouth1.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetNoses",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("edb7a31f-f412-470f-b044-62d455c401d2"), "nose6.svg" },
                    { new Guid("22786959-e3bf-43e9-bb35-5eaefcf8f1a8"), "nose1.svg" },
                    { new Guid("21c584d0-6d46-4f2d-92f3-b374fd3dd0e1"), "nose2.svg" },
                    { new Guid("56bc0350-89c8-453f-9399-d983fbaa1561"), "nose3.svg" },
                    { new Guid("22eb787f-52be-4fae-ab5c-20f1269efa24"), "nose4.svg" },
                    { new Guid("1c3cce28-e42a-4529-9e6b-fb408de25aea"), "nose5.svg" }
                });
        }
    }
}
