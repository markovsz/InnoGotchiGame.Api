using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddRelationsBetweenBodyPartAndPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("29ad261a-48a0-4b6a-9a8a-f3611e37370a"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("0584bff3-1ed0-43fd-84f0-19064ce042f2"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("0f4c9045-2933-4ae4-8536-d4df34dd92bf"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("5dfb68a9-f6f6-424f-a350-ae4533d8e7f7"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("87bca347-99da-4630-8604-44908fd77263"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("f605429b-6ae6-45bc-9b44-b62f14f013c7"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("1e10173c-c415-4281-9784-b9fd1c0a4eb8"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("57e6b495-1dca-4145-8b48-f92126fc29d3"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("a0b7dbcd-659c-4144-ada3-147096fd2b51"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("a3135cb4-dfa8-4582-ad64-c294209b4d19"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("a5651b42-f29a-41d5-b0ba-6adc4a972961"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("bc89c2e3-9c01-4952-a82a-73aa3a65706b"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("0002a49c-5c2f-4b03-897e-6cc1290a74ec"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("08ec721f-fe6e-4397-8ebc-0eecd2512b13"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("4c088aa9-d75a-49a1-ac80-fc235b73ef7e"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("70d849c5-d04c-421e-99f8-b647bba4a0fe"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("92da74ba-9ad3-4255-873e-ab7f9dfd4b89"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("231484c4-4407-4b69-85bb-ad42eabfa15d"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("31e257c1-55a2-49fc-b111-9f2963593441"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("409544da-d5ae-418d-b834-6366cdddb1e2"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("784f6e08-affe-4dca-8657-a5440288a218"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("9b59c5b4-7504-46c1-b73f-483845c06e78"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("b0619bbd-7127-4381-a9fd-6da66be791cc"));

            migrationBuilder.AddColumn<Guid>(
                name: "BodyId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EyesId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MouthId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NoseId",
                table: "Pets",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BodyId",
                table: "Pets",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_EyesId",
                table: "Pets",
                column: "EyesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_MouthId",
                table: "Pets",
                column: "MouthId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_NoseId",
                table: "Pets",
                column: "NoseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetBodies_BodyId",
                table: "Pets",
                column: "BodyId",
                principalTable: "PetBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetEyes_EyesId",
                table: "Pets",
                column: "EyesId",
                principalTable: "PetEyes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetMouths_MouthId",
                table: "Pets",
                column: "MouthId",
                principalTable: "PetMouths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetNoses_NoseId",
                table: "Pets",
                column: "NoseId",
                principalTable: "PetNoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetBodies_BodyId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetEyes_EyesId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetMouths_MouthId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetNoses_NoseId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_BodyId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_EyesId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_MouthId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_NoseId",
                table: "Pets");

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

            migrationBuilder.DropColumn(
                name: "BodyId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "EyesId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "MouthId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "NoseId",
                table: "Pets");

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
    }
}
