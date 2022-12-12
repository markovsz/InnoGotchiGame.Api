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

                    b.Property<int>("BodyPictureX")
                        .HasColumnType("int");

                    b.Property<int>("BodyPictureY")
                        .HasColumnType("int");

                    b.Property<long>("DeathDate")
                        .HasColumnType("bigint");

                    b.Property<Guid>("EyesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("EyesPictureScale")
                        .HasColumnType("real");

                    b.Property<int>("EyesPictureX")
                        .HasColumnType("int");

                    b.Property<int>("EyesPictureY")
                        .HasColumnType("int");

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

                    b.Property<int>("MouthPictureX")
                        .HasColumnType("int");

                    b.Property<int>("MouthPictureY")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NoseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("NosePictureScale")
                        .HasColumnType("real");

                    b.Property<int>("NosePictureX")
                        .HasColumnType("int");

                    b.Property<int>("NosePictureY")
                        .HasColumnType("int");

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
                            Id = new Guid("686fcc2b-bc4c-462c-b1d8-0626fa83b79f"),
                            PictureName = "body1.svg"
                        },
                        new
                        {
                            Id = new Guid("e06841c3-b0be-494b-9945-e2bdbf939f62"),
                            PictureName = "body2.svg"
                        },
                        new
                        {
                            Id = new Guid("66042d94-c41d-4b22-ad9f-188bec102e76"),
                            PictureName = "body3.svg"
                        },
                        new
                        {
                            Id = new Guid("64740897-c7c1-45be-8487-03eb46f4c885"),
                            PictureName = "body4.svg"
                        },
                        new
                        {
                            Id = new Guid("6097c11f-168a-4a9b-bf72-85e135c428b3"),
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
                            Id = new Guid("16aca063-e1d6-4565-9428-eb70796524f7"),
                            PictureName = "eyes1.svg"
                        },
                        new
                        {
                            Id = new Guid("afa33b26-5134-45a3-ae0b-53835444cde2"),
                            PictureName = "eyes2.svg"
                        },
                        new
                        {
                            Id = new Guid("eb96250d-7352-4372-a66b-e57e1f7b3fe2"),
                            PictureName = "eyes3.svg"
                        },
                        new
                        {
                            Id = new Guid("46cbdf3d-9f2e-47c2-ac18-540b8164ef29"),
                            PictureName = "eyes4.svg"
                        },
                        new
                        {
                            Id = new Guid("e9b80f5a-df15-4989-84ef-7cfe45a77048"),
                            PictureName = "eyes5.svg"
                        },
                        new
                        {
                            Id = new Guid("b55778f4-d8e9-49a6-b5fb-5def3c3cffcd"),
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
                            Id = new Guid("9727d94f-2ddd-4e88-a542-9adf6133c3dc"),
                            PictureName = "mouth1.svg"
                        },
                        new
                        {
                            Id = new Guid("620b66c1-160c-4c81-ac10-49375aab26ce"),
                            PictureName = "mouth2.svg"
                        },
                        new
                        {
                            Id = new Guid("ac9c2ac8-2c69-41fb-9c28-2d7c9e9a5b37"),
                            PictureName = "mouth3.svg"
                        },
                        new
                        {
                            Id = new Guid("e6d5b118-02b4-41ba-9ed0-520314a0755d"),
                            PictureName = "mouth4.svg"
                        },
                        new
                        {
                            Id = new Guid("1d9c2b6e-a515-4602-bcfc-27221d241375"),
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
                            Id = new Guid("f03fbc63-088f-4d53-bf7a-a775a73d4182"),
                            PictureName = "nose1.svg"
                        },
                        new
                        {
                            Id = new Guid("a0662f61-fd12-4fb3-aa64-6b5054195243"),
                            PictureName = "nose2.svg"
                        },
                        new
                        {
                            Id = new Guid("c6aa1087-2cec-4d4f-8362-37ae2c6bc0f4"),
                            PictureName = "nose3.svg"
                        },
                        new
                        {
                            Id = new Guid("da30c7bd-f2db-4793-8ae4-b5817ee83860"),
                            PictureName = "nose4.svg"
                        },
                        new
                        {
                            Id = new Guid("c7393c86-2a6a-44b7-aef9-4c15559c51ed"),
                            PictureName = "nose5.svg"
                        },
                        new
                        {
                            Id = new Guid("6ff5eeb0-3a7b-4483-949a-fdf329b91fde"),
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
                            Id = new Guid("84192b58-815d-47f0-a05d-c4370ec8ab2b"),
                            ConcurrencyStamp = "d84b4c8f-e265-482d-9344-04e8d35d7ac0",
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
