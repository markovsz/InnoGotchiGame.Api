﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20221211000642_MakeBodyPartsFKsAsNotNullable")]
    partial class MakeBodyPartsFKsAsNotNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<long>("DeathDate")
                        .HasColumnType("bigint");

                    b.Property<Guid>("EyesId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NoseId")
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("eeb3126f-5421-401a-9f5e-eb101936d30c"),
                            PictureName = "body1.svg"
                        },
                        new
                        {
                            Id = new Guid("3285f353-f5d9-4390-8429-08c63465a1f3"),
                            PictureName = "body2.svg"
                        },
                        new
                        {
                            Id = new Guid("f8c0cf9b-9221-4b46-8e61-386434c9f124"),
                            PictureName = "body3.svg"
                        },
                        new
                        {
                            Id = new Guid("d961ed82-9f5c-4a54-997e-82d222eeb310"),
                            PictureName = "body4.svg"
                        },
                        new
                        {
                            Id = new Guid("4238c4aa-4e98-4d8f-afc1-2cc5f6f78d33"),
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
                            Id = new Guid("734bf663-48f5-4bb8-922f-a70004d78cad"),
                            PictureName = "eyes1.svg"
                        },
                        new
                        {
                            Id = new Guid("b12cbcdc-c0f0-4cdf-8fec-f6810893f765"),
                            PictureName = "eyes2.svg"
                        },
                        new
                        {
                            Id = new Guid("c6b70385-1f68-4f16-b1dc-9ca2d37ae0ff"),
                            PictureName = "eyes3.svg"
                        },
                        new
                        {
                            Id = new Guid("64562f69-6e1e-4112-aaaa-c2419285fc48"),
                            PictureName = "eyes4.svg"
                        },
                        new
                        {
                            Id = new Guid("0ac4c0aa-b4c5-46d3-a63d-c03f0804578b"),
                            PictureName = "eyes5.svg"
                        },
                        new
                        {
                            Id = new Guid("d4eecee5-bcad-4447-9bd2-fd90691c5f52"),
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
                            Id = new Guid("754db423-3ce9-4d23-a8fa-73305ba840d2"),
                            PictureName = "mouth1.svg"
                        },
                        new
                        {
                            Id = new Guid("5fb6493f-891b-47fd-90e8-618c6c8b4858"),
                            PictureName = "mouth2.svg"
                        },
                        new
                        {
                            Id = new Guid("30d729b8-942c-43f1-a024-93165821c0ad"),
                            PictureName = "mouth3.svg"
                        },
                        new
                        {
                            Id = new Guid("1398a244-a1df-4979-bd76-724c16cce7c8"),
                            PictureName = "mouth4.svg"
                        },
                        new
                        {
                            Id = new Guid("91274d57-d0ef-4cc5-a61a-21fa44ed49a0"),
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
                            Id = new Guid("92a44395-bf44-4ad7-a6f9-a1e5c3b3a399"),
                            PictureName = "nose1.svg"
                        },
                        new
                        {
                            Id = new Guid("51e6953f-1b87-43da-98fc-1fac21a142a1"),
                            PictureName = "nose2.svg"
                        },
                        new
                        {
                            Id = new Guid("a400fab5-369e-497f-a33d-c0bf3c732164"),
                            PictureName = "nose3.svg"
                        },
                        new
                        {
                            Id = new Guid("a821f41e-9103-41de-89b3-490536a4226c"),
                            PictureName = "nose4.svg"
                        },
                        new
                        {
                            Id = new Guid("b61ce33f-31ed-4dd3-b057-ad38d6a94a4a"),
                            PictureName = "nose5.svg"
                        },
                        new
                        {
                            Id = new Guid("aa18337c-aa14-4ba9-a166-f9dea84d84bd"),
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
                            Id = new Guid("d10077b0-1f6f-4af3-91af-6f21dab5c507"),
                            ConcurrencyStamp = "fe2a8b13-4eca-4cdd-9508-5b1c80cf8599",
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