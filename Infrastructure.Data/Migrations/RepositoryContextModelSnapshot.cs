﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Core.Models.Farm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("Domain.Core.Models.FarmFriend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

                    b.HasIndex("UserId");

                    b.ToTable("FarmFriends");
                });

            modelBuilder.Entity("Domain.Core.Models.FeedingEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("FeedingTime")
                        .HasColumnType("bigint");

                    b.Property<float>("HungerValueBefore")
                        .HasColumnType("real");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("FeedingEvents");
                });

            modelBuilder.Entity("Domain.Core.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("BirthDate")
                        .HasColumnType("bigint");

                    b.Property<Guid>("BodyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("BodyPictureScale")
                        .HasColumnType("real");

                    b.Property<float>("BodyPictureX")
                        .HasColumnType("real");

                    b.Property<float>("BodyPictureY")
                        .HasColumnType("real");

                    b.Property<long>("DeathDate")
                        .HasColumnType("bigint");

                    b.Property<Guid>("EyesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("EyesPictureScale")
                        .HasColumnType("real");

                    b.Property<float>("EyesPictureX")
                        .HasColumnType("real");

                    b.Property<float>("EyesPictureY")
                        .HasColumnType("real");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("HappinessDaysCount")
                        .HasColumnType("int");

                    b.Property<float>("HungerValue")
                        .HasColumnType("real");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<long>("LastPetDetailsUpdatingTime")
                        .HasColumnType("bigint");

                    b.Property<Guid>("MouthId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("MouthPictureScale")
                        .HasColumnType("real");

                    b.Property<float>("MouthPictureX")
                        .HasColumnType("real");

                    b.Property<float>("MouthPictureY")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NoseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("NosePictureScale")
                        .HasColumnType("real");

                    b.Property<float>("NosePictureX")
                        .HasColumnType("real");

                    b.Property<float>("NosePictureY")
                        .HasColumnType("real");

                    b.Property<float>("ThirstValue")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("EyesId");

                    b.HasIndex("FarmId");

                    b.HasIndex("MouthId");

                    b.HasIndex("NoseId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Domain.Core.Models.PetBody", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PetBodies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("50a1708c-c974-4301-93aa-bd878cae7c6e"),
                            PictureName = "body1.svg"
                        },
                        new
                        {
                            Id = new Guid("758b0a50-2a2c-4e9d-8e37-9d0fdd58378a"),
                            PictureName = "body2.svg"
                        },
                        new
                        {
                            Id = new Guid("70057dfe-7f2b-4b00-8172-3c4ddbd278f0"),
                            PictureName = "body3.svg"
                        },
                        new
                        {
                            Id = new Guid("4be4cdd6-d01f-4ac4-8abc-36716625d014"),
                            PictureName = "body4.svg"
                        },
                        new
                        {
                            Id = new Guid("d78cbaee-85ff-4751-b7dc-d7b6eb643efd"),
                            PictureName = "body5.svg"
                        });
                });

            modelBuilder.Entity("Domain.Core.Models.PetEyes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PetEyes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7780469f-8b3c-4cda-9dab-72841f6fb480"),
                            PictureName = "eyes1.svg"
                        },
                        new
                        {
                            Id = new Guid("a319b320-c551-4e47-a719-d12857d2b065"),
                            PictureName = "eyes2.svg"
                        },
                        new
                        {
                            Id = new Guid("3c05be97-c855-42c3-93b1-f73541080a4e"),
                            PictureName = "eyes3.svg"
                        },
                        new
                        {
                            Id = new Guid("2cff9355-e5f8-4531-b055-466df7af0f60"),
                            PictureName = "eyes4.svg"
                        },
                        new
                        {
                            Id = new Guid("ea15bce9-8585-4a9e-9aab-ca1149254fc4"),
                            PictureName = "eyes5.svg"
                        },
                        new
                        {
                            Id = new Guid("8a2905ca-3644-4d82-9b17-123a6014bc63"),
                            PictureName = "eyes6.svg"
                        });
                });

            modelBuilder.Entity("Domain.Core.Models.PetMouth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PetMouths");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bab6c8dd-b2fc-41a2-bef9-56462f31c1dd"),
                            PictureName = "mouth1.svg"
                        },
                        new
                        {
                            Id = new Guid("358f962c-b4b6-4b7a-b5f4-4204f5b7ea45"),
                            PictureName = "mouth2.svg"
                        },
                        new
                        {
                            Id = new Guid("bbda15ef-cd54-4bc0-866b-3c108fdc1833"),
                            PictureName = "mouth3.svg"
                        },
                        new
                        {
                            Id = new Guid("b4f33b5a-306f-4ca7-97c3-6f4b8a542c1c"),
                            PictureName = "mouth4.svg"
                        },
                        new
                        {
                            Id = new Guid("ef5ab534-8349-4111-a069-a7967b977ee8"),
                            PictureName = "mouth5.svg"
                        });
                });

            modelBuilder.Entity("Domain.Core.Models.PetNose", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PetNoses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("32f9dbea-ae69-4a72-b267-014bc769d9ee"),
                            PictureName = "nose1.svg"
                        },
                        new
                        {
                            Id = new Guid("b2deb895-1d14-4774-8fba-7ffc4ed4711d"),
                            PictureName = "nose2.svg"
                        },
                        new
                        {
                            Id = new Guid("df853877-2040-49fa-ae4d-7bec04e376f5"),
                            PictureName = "nose3.svg"
                        },
                        new
                        {
                            Id = new Guid("d64abfc8-e5f1-4344-8699-47356d146d2b"),
                            PictureName = "nose4.svg"
                        },
                        new
                        {
                            Id = new Guid("e5cf70db-3ce3-4570-8f35-c0ebc9527328"),
                            PictureName = "nose5.svg"
                        },
                        new
                        {
                            Id = new Guid("9bc6dfeb-67f3-4e70-b662-dc7a3265da66"),
                            PictureName = "nose6.svg"
                        });
                });

            modelBuilder.Entity("Domain.Core.Models.ThirstQuenchingEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("ThirstQuenchingTime")
                        .HasColumnType("bigint");

                    b.Property<float>("ThirstValueBefore")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("ThirstQuenchingEvents");
                });

            modelBuilder.Entity("Domain.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Core.Models.UserInfo", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureSrc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7a5f86b-df22-41ab-8aaf-5c328930745d"),
                            ConcurrencyStamp = "11d0f27e-4e46-4854-b8cf-c68f90722475",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Core.Models.Farm", b =>
                {
                    b.HasOne("Domain.Core.Models.UserInfo", "UserInfo")
                        .WithOne("Farm")
                        .HasForeignKey("Domain.Core.Models.Farm", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Domain.Core.Models.FarmFriend", b =>
                {
                    b.HasOne("Domain.Core.Models.Farm", "Farm")
                        .WithMany("FarmFriends")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.Models.UserInfo", "UserInfo")
                        .WithMany("FarmFriends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Domain.Core.Models.FeedingEvent", b =>
                {
                    b.HasOne("Domain.Core.Models.Pet", "Pet")
                        .WithMany("FeedingEvents")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Domain.Core.Models.Pet", b =>
                {
                    b.HasOne("Domain.Core.Models.PetBody", "Body")
                        .WithMany("RelatedPets")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.Models.PetEyes", "Eyes")
                        .WithMany("RelatedPets")
                        .HasForeignKey("EyesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.Models.Farm", "Farm")
                        .WithMany("Pets")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.Models.PetMouth", "Mouth")
                        .WithMany("RelatedPets")
                        .HasForeignKey("MouthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.Models.PetNose", "Nose")
                        .WithMany("RelatedPets")
                        .HasForeignKey("NoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Body");

                    b.Navigation("Eyes");

                    b.Navigation("Farm");

                    b.Navigation("Mouth");

                    b.Navigation("Nose");
                });

            modelBuilder.Entity("Domain.Core.Models.ThirstQuenchingEvent", b =>
                {
                    b.HasOne("Domain.Core.Models.Pet", "Pet")
                        .WithMany("ThirstQuenchingEvents")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Domain.Core.Models.UserInfo", b =>
                {
                    b.HasOne("Domain.Core.Models.User", "User")
                        .WithOne("UserInfo")
                        .HasForeignKey("Domain.Core.Models.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Domain.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Domain.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Core.Models.Farm", b =>
                {
                    b.Navigation("FarmFriends");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Domain.Core.Models.Pet", b =>
                {
                    b.Navigation("FeedingEvents");

                    b.Navigation("ThirstQuenchingEvents");
                });

            modelBuilder.Entity("Domain.Core.Models.PetBody", b =>
                {
                    b.Navigation("RelatedPets");
                });

            modelBuilder.Entity("Domain.Core.Models.PetEyes", b =>
                {
                    b.Navigation("RelatedPets");
                });

            modelBuilder.Entity("Domain.Core.Models.PetMouth", b =>
                {
                    b.Navigation("RelatedPets");
                });

            modelBuilder.Entity("Domain.Core.Models.PetNose", b =>
                {
                    b.Navigation("RelatedPets");
                });

            modelBuilder.Entity("Domain.Core.Models.User", b =>
                {
                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Domain.Core.Models.UserInfo", b =>
                {
                    b.Navigation("Farm");

                    b.Navigation("FarmFriends");
                });
#pragma warning restore 612, 618
        }
    }
}
