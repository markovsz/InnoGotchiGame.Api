using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class RemoveIsAliveProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7a5f86b-df22-41ab-8aaf-5c328930745d"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("4be4cdd6-d01f-4ac4-8abc-36716625d014"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("50a1708c-c974-4301-93aa-bd878cae7c6e"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("70057dfe-7f2b-4b00-8172-3c4ddbd278f0"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("758b0a50-2a2c-4e9d-8e37-9d0fdd58378a"));

            migrationBuilder.DeleteData(
                table: "PetBodies",
                keyColumn: "Id",
                keyValue: new Guid("d78cbaee-85ff-4751-b7dc-d7b6eb643efd"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("2cff9355-e5f8-4531-b055-466df7af0f60"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("3c05be97-c855-42c3-93b1-f73541080a4e"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("7780469f-8b3c-4cda-9dab-72841f6fb480"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("8a2905ca-3644-4d82-9b17-123a6014bc63"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("a319b320-c551-4e47-a719-d12857d2b065"));

            migrationBuilder.DeleteData(
                table: "PetEyes",
                keyColumn: "Id",
                keyValue: new Guid("ea15bce9-8585-4a9e-9aab-ca1149254fc4"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("358f962c-b4b6-4b7a-b5f4-4204f5b7ea45"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("b4f33b5a-306f-4ca7-97c3-6f4b8a542c1c"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("bab6c8dd-b2fc-41a2-bef9-56462f31c1dd"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("bbda15ef-cd54-4bc0-866b-3c108fdc1833"));

            migrationBuilder.DeleteData(
                table: "PetMouths",
                keyColumn: "Id",
                keyValue: new Guid("ef5ab534-8349-4111-a069-a7967b977ee8"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("32f9dbea-ae69-4a72-b267-014bc769d9ee"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("9bc6dfeb-67f3-4e70-b662-dc7a3265da66"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("b2deb895-1d14-4774-8fba-7ffc4ed4711d"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("d64abfc8-e5f1-4344-8699-47356d146d2b"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("df853877-2040-49fa-ae4d-7bec04e376f5"));

            migrationBuilder.DeleteData(
                table: "PetNoses",
                keyColumn: "Id",
                keyValue: new Guid("e5cf70db-3ce3-4570-8f35-c0ebc9527328"));

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "Pets");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f7a5f86b-df22-41ab-8aaf-5c328930745d"), "11d0f27e-4e46-4854-b8cf-c68f90722475", "user", "USER" });

            migrationBuilder.InsertData(
                table: "PetBodies",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("d78cbaee-85ff-4751-b7dc-d7b6eb643efd"), "body5.svg" },
                    { new Guid("4be4cdd6-d01f-4ac4-8abc-36716625d014"), "body4.svg" },
                    { new Guid("50a1708c-c974-4301-93aa-bd878cae7c6e"), "body1.svg" },
                    { new Guid("758b0a50-2a2c-4e9d-8e37-9d0fdd58378a"), "body2.svg" },
                    { new Guid("70057dfe-7f2b-4b00-8172-3c4ddbd278f0"), "body3.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetEyes",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("7780469f-8b3c-4cda-9dab-72841f6fb480"), "eyes1.svg" },
                    { new Guid("a319b320-c551-4e47-a719-d12857d2b065"), "eyes2.svg" },
                    { new Guid("3c05be97-c855-42c3-93b1-f73541080a4e"), "eyes3.svg" },
                    { new Guid("2cff9355-e5f8-4531-b055-466df7af0f60"), "eyes4.svg" },
                    { new Guid("ea15bce9-8585-4a9e-9aab-ca1149254fc4"), "eyes5.svg" },
                    { new Guid("8a2905ca-3644-4d82-9b17-123a6014bc63"), "eyes6.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetMouths",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("ef5ab534-8349-4111-a069-a7967b977ee8"), "mouth5.svg" },
                    { new Guid("b4f33b5a-306f-4ca7-97c3-6f4b8a542c1c"), "mouth4.svg" },
                    { new Guid("bbda15ef-cd54-4bc0-866b-3c108fdc1833"), "mouth3.svg" },
                    { new Guid("358f962c-b4b6-4b7a-b5f4-4204f5b7ea45"), "mouth2.svg" },
                    { new Guid("bab6c8dd-b2fc-41a2-bef9-56462f31c1dd"), "mouth1.svg" }
                });

            migrationBuilder.InsertData(
                table: "PetNoses",
                columns: new[] { "Id", "PictureName" },
                values: new object[,]
                {
                    { new Guid("9bc6dfeb-67f3-4e70-b662-dc7a3265da66"), "nose6.svg" },
                    { new Guid("32f9dbea-ae69-4a72-b267-014bc769d9ee"), "nose1.svg" },
                    { new Guid("b2deb895-1d14-4774-8fba-7ffc4ed4711d"), "nose2.svg" },
                    { new Guid("df853877-2040-49fa-ae4d-7bec04e376f5"), "nose3.svg" },
                    { new Guid("d64abfc8-e5f1-4344-8699-47356d146d2b"), "nose4.svg" },
                    { new Guid("e5cf70db-3ce3-4570-8f35-c0ebc9527328"), "nose5.svg" }
                });
        }
    }
}
