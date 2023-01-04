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

            migrationBuilder.AddColumn<float>(
                name: "BodyPictureX",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "BodyPictureY",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "EyesPictureScale",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "EyesPictureX",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "EyesPictureY",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MouthPictureScale",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MouthPictureX",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MouthPictureY",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "NosePictureScale",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "NosePictureX",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "NosePictureY",
                table: "Pets",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
