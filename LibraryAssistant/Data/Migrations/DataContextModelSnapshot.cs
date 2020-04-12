﻿// <auto-generated />
using System;
using LibraryAssistant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryAssistant.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryAssistant.Core.Entities.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CoverPrice");

                    b.Property<string>("ISBN");

                    b.Property<int>("PublishYear");

                    b.Property<bool>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoverPrice = 989.05m,
                            ISBN = "986-3-16-148410-0",
                            PublishYear = 1994,
                            Status = true,
                            Title = "To Kill a MockingBird"
                        },
                        new
                        {
                            Id = 2,
                            CoverPrice = 589.05m,
                            ISBN = "886-3-16-148410-0",
                            PublishYear = 2004,
                            Status = true,
                            Title = "The Great GatsBy"
                        },
                        new
                        {
                            Id = 3,
                            CoverPrice = 300.05m,
                            ISBN = "686-3-16-148410-0",
                            PublishYear = 2002,
                            Status = true,
                            Title = "The Lion King"
                        },
                        new
                        {
                            Id = 4,
                            CoverPrice = 350.05m,
                            ISBN = "586-3-16-148410-0",
                            PublishYear = 2001,
                            Status = true,
                            Title = "The Book of THief"
                        },
                        new
                        {
                            Id = 5,
                            CoverPrice = 278.05m,
                            ISBN = "699-3-16-148410-0",
                            PublishYear = 1997,
                            Status = true,
                            Title = "Harry Porter"
                        },
                        new
                        {
                            Id = 6,
                            CoverPrice = 778.05m,
                            ISBN = "199-3-16-148410-0",
                            PublishYear = 1976,
                            Status = true,
                            Title = "Gone with the wind"
                        },
                        new
                        {
                            Id = 7,
                            CoverPrice = 798.05m,
                            ISBN = "779-3-16-148410-0",
                            PublishYear = 2012,
                            Status = true,
                            Title = "Lord of files"
                        },
                        new
                        {
                            Id = 8,
                            CoverPrice = 778.05m,
                            ISBN = "199-3-16-148410-0",
                            PublishYear = 1976,
                            Status = true,
                            Title = "OF Mice and Men"
                        });
                });

            modelBuilder.Entity("LibraryAssistant.Core.Entities.BooksActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BooksId");

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<DateTime>("ExpectedCheckIn");

                    b.Property<int>("LateDays");

                    b.Property<decimal>("PenaltyFee");

                    b.Property<int>("RetUrnDays");

                    b.Property<int>("UsersId");

                    b.HasKey("Id");

                    b.HasIndex("BooksId");

                    b.HasIndex("UsersId");

                    b.ToTable("BooksActivities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BooksId = 1,
                            CheckIn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOut = new DateTime(2020, 4, 12, 18, 1, 16, 198, DateTimeKind.Local).AddTicks(1166),
                            ExpectedCheckIn = new DateTime(2020, 4, 24, 18, 1, 16, 199, DateTimeKind.Local).AddTicks(3651),
                            LateDays = 0,
                            PenaltyFee = 0m,
                            RetUrnDays = 10,
                            UsersId = 1
                        });
                });

            modelBuilder.Entity("LibraryAssistant.Core.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("NIN");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ade@gmail.com",
                            FullName = "ade olawale",
                            NIN = "6778 8999 9090 7689",
                            PhoneNumber = "08036279679"
                        },
                        new
                        {
                            Id = 2,
                            Email = "mark@gmail.com",
                            FullName = "mark micheal",
                            NIN = "3478 8999 9090 7689",
                            PhoneNumber = "08096279679"
                        },
                        new
                        {
                            Id = 3,
                            Email = "pelumi@gmail.com",
                            FullName = "pelumi salami",
                            NIN = "2478 8999 9090 7689",
                            PhoneNumber = "08026279679"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LibraryAssistant.Core.Entities.BooksActivity", b =>
                {
                    b.HasOne("LibraryAssistant.Core.Entities.Books", "Books")
                        .WithMany("BooksActivity")
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryAssistant.Core.Entities.Users", "Users")
                        .WithMany("BooksActivity")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
