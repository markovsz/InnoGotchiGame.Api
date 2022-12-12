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
    [Migration("20221209151043_AddBodyPartEntities")]
    partial class AddBodyPartEntities
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

                    b.Property<long>("DeathDate")
                        .HasColumnType("bigint");

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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ThirstValue")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FarmId");

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
                            Id = new Guid("87bca347-99da-4630-8604-44908fd77263"),
                            PictureName = "body1.svg"
                        },
                        new
                        {
                            Id = new Guid("5dfb68a9-f6f6-424f-a350-ae4533d8e7f7"),
                            PictureName = "body2.svg"
                        },
                        new
                        {
                            Id = new Guid("0584bff3-1ed0-43fd-84f0-19064ce042f2"),
                            PictureName = "body3.svg"
                        },
                        new
                        {
                            Id = new Guid("0f4c9045-2933-4ae4-8536-d4df34dd92bf"),
                            PictureName = "body4.svg"
                        },
                        new
                        {
                            Id = new Guid("f605429b-6ae6-45bc-9b44-b62f14f013c7"),
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
                            Id = new Guid("a3135cb4-dfa8-4582-ad64-c294209b4d19"),
                            PictureName = "eyes1.svg"
                        },
                        new
                        {
                            Id = new Guid("a5651b42-f29a-41d5-b0ba-6adc4a972961"),
                            PictureName = "eyes2.svg"
                        },
                        new
                        {
                            Id = new Guid("1e10173c-c415-4281-9784-b9fd1c0a4eb8"),
                            PictureName = "eyes3.svg"
                        },
                        new
                        {
                            Id = new Guid("bc89c2e3-9c01-4952-a82a-73aa3a65706b"),
                            PictureName = "eyes4.svg"
                        },
                        new
                        {
                            Id = new Guid("57e6b495-1dca-4145-8b48-f92126fc29d3"),
                            PictureName = "eyes5.svg"
                        },
                        new
                        {
                            Id = new Guid("a0b7dbcd-659c-4144-ada3-147096fd2b51"),
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
                            Id = new Guid("08ec721f-fe6e-4397-8ebc-0eecd2512b13"),
                            PictureName = "mouth1.svg"
                        },
                        new
                        {
                            Id = new Guid("92da74ba-9ad3-4255-873e-ab7f9dfd4b89"),
                            PictureName = "mouth2.svg"
                        },
                        new
                        {
                            Id = new Guid("70d849c5-d04c-421e-99f8-b647bba4a0fe"),
                            PictureName = "mouth3.svg"
                        },
                        new
                        {
                            Id = new Guid("0002a49c-5c2f-4b03-897e-6cc1290a74ec"),
                            PictureName = "mouth4.svg"
                        },
                        new
                        {
                            Id = new Guid("4c088aa9-d75a-49a1-ac80-fc235b73ef7e"),
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
                            Id = new Guid("9b59c5b4-7504-46c1-b73f-483845c06e78"),
                            PictureName = "nose1.svg"
                        },
                        new
                        {
                            Id = new Guid("31e257c1-55a2-49fc-b111-9f2963593441"),
                            PictureName = "nose2.svg"
                        },
                        new
                        {
                            Id = new Guid("409544da-d5ae-418d-b834-6366cdddb1e2"),
                            PictureName = "nose3.svg"
                        },
                        new
                        {
                            Id = new Guid("231484c4-4407-4b69-85bb-ad42eabfa15d"),
                            PictureName = "nose4.svg"
                        },
                        new
                        {
                            Id = new Guid("784f6e08-affe-4dca-8657-a5440288a218"),
                            PictureName = "nose5.svg"
                        },
                        new
                        {
                            Id = new Guid("b0619bbd-7127-4381-a9fd-6da66be791cc"),
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
                            Id = new Guid("29ad261a-48a0-4b6a-9a8a-f3611e37370a"),
                            ConcurrencyStamp = "633087c0-9059-4692-92a9-dd907cc5d26d",
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
                    b.HasOne("Domain.Core.Models.Farm", "Farm")
                        .WithMany("Pets")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");
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