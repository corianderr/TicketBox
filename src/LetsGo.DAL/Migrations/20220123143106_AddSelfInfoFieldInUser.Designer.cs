﻿// <auto-generated />
using System;
using LetsGo.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LetsGo.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220123143106_AddSelfInfoFieldInUser")]
    partial class AddSelfInfoFieldInUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("LetsGo.Core.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgeLimit")
                        .HasColumnType("int");

                    b.Property<string>("Categories")
                        .HasColumnType("longtext");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EventEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EventStart")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<double>("MinPrice")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<string>("PosterImage")
                        .HasColumnType("longtext");

                    b.Property<int>("Sold")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StatusDescription")
                        .HasColumnType("longtext");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StatusUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TicketLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.EventCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("HasParent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EventCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasParent = false,
                            Name = "Концерты"
                        },
                        new
                        {
                            Id = 2,
                            HasParent = false,
                            Name = "Фестивали"
                        },
                        new
                        {
                            Id = 3,
                            HasParent = false,
                            Name = "Спектакли"
                        },
                        new
                        {
                            Id = 4,
                            HasParent = false,
                            Name = "Детям"
                        },
                        new
                        {
                            Id = 5,
                            HasParent = false,
                            Name = "Классика"
                        },
                        new
                        {
                            Id = 6,
                            HasParent = false,
                            Name = "Экскурсии"
                        },
                        new
                        {
                            Id = 7,
                            HasParent = false,
                            Name = "Другое"
                        },
                        new
                        {
                            Id = 8,
                            HasParent = true,
                            Name = "Поп-Музыка",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 9,
                            HasParent = true,
                            Name = "Рок",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 10,
                            HasParent = true,
                            Name = "Хип-Хоп",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 11,
                            HasParent = true,
                            Name = "Комедии",
                            ParentId = 3
                        },
                        new
                        {
                            Id = 12,
                            HasParent = true,
                            Name = "Драмы",
                            ParentId = 3
                        },
                        new
                        {
                            Id = 13,
                            HasParent = true,
                            Name = "Мелодрамы",
                            ParentId = 3
                        },
                        new
                        {
                            Id = 14,
                            HasParent = true,
                            Name = "Опера",
                            ParentId = 5
                        },
                        new
                        {
                            Id = 15,
                            HasParent = true,
                            Name = "Балет",
                            ParentId = 5
                        },
                        new
                        {
                            Id = 16,
                            HasParent = true,
                            Name = "Вокал",
                            ParentId = 5
                        });
                });

            modelBuilder.Entity("LetsGo.Core.Entities.EventTicketType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Sold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventTicketTypes");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Categories")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("LocationImage")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Phones")
                        .HasColumnType("longtext");

                    b.Property<double>("X")
                        .HasColumnType("double");

                    b.Property<double>("Y")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "21, 11 Аалы Токомбаева көчөсү, Бишкек",
                            Categories = "[{\"Id\":\"7\",\"Name\":\"Клубы\"}, {\"Id\":\"8\",\"Name\":\"Бары\"}]",
                            Description = "Художественный центр в Бишкеке",
                            Name = "Асанбай Центр",
                            Phones = "[\"+996775979500\"]",
                            X = 42.817987000000002,
                            Y = 74.620718999999994
                        },
                        new
                        {
                            Id = 2,
                            Address = "24 просп. Мира, Бишкек",
                            Categories = "[{\"Id\":\"7\",\"Name\":\"Клубы\"}, {\"Id\":\"8\",\"Name\":\"Бары\"}]",
                            Description = "Концертный зал",
                            Name = "Ретро-Метро",
                            Phones = "[\"+996705 000 888\"]",
                            X = 42.855733999999998,
                            Y = 74.587316000000001
                        },
                        new
                        {
                            Id = 3,
                            Address = "17 ул. Тоголок Молдо, Бишкек",
                            Categories = "[{\"Id\":\"5\",\"Name\":\"Cпортивные комплексы\"}, {\"Id\":\"10\",\"Name\":\"Другое\"}]",
                            Description = "Концертный зал",
                            Name = "Стадион Спартак",
                            Phones = "[\"+996705 000 888\"]",
                            X = 42.880873000000001,
                            Y = 74.596663000000007
                        },
                        new
                        {
                            Id = 4,
                            Address = "167 Советская, Бишкек",
                            Categories = "[{\"Id\":\"1\",\"Name\":\"Театры\"}]",
                            Description = "Театр оперы и балета",
                            Name = "Театр Оперы и Балета",
                            Phones = "[\"0312 621 619\"]",
                            X = 42.878090999999998,
                            Y = 74.612414999999999
                        });
                });

            modelBuilder.Entity("LetsGo.Core.Entities.LocationCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LocationCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Концерты"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Фестивали"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Спектакли"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Детям"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Классика"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Экскурсии"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Другое"
                        });
                });

            modelBuilder.Entity("LetsGo.Core.Entities.PurchasedTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerName")
                        .HasColumnType("longtext");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("longtext");

                    b.Property<int>("EventTicketTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("QR")
                        .HasColumnType("longtext");

                    b.Property<bool>("Scanned")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TicketIdentifier")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EventTicketTypeId");

                    b.ToTable("PurchasedTickets");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AvatarLink")
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("SelfInfo")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.UserToRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId1")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.Event", b =>
                {
                    b.HasOne("LetsGo.Core.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LetsGo.Core.Entities.User", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.EventTicketType", b =>
                {
                    b.HasOne("LetsGo.Core.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.PurchasedTicket", b =>
                {
                    b.HasOne("LetsGo.Core.Entities.EventTicketType", "EventTicketType")
                        .WithMany()
                        .HasForeignKey("EventTicketTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EventTicketType");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.UserToRole", b =>
                {
                    b.HasOne("LetsGo.Core.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LetsGo.Core.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LetsGo.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LetsGo.Core.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("LetsGo.Core.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("LetsGo.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("LetsGo.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("LetsGo.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("LetsGo.Core.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("LetsGo.Core.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
