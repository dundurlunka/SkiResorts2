﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SkiResorts.Data;
using SkiResorts.Data.Models;
using System;

namespace SkiResorts.Data.Migrations
{
    [DbContext(typeof(SkiResortsDbContext))]
    [Migration("20171222041452_AddedTotalPriceToUserLiftCard")]
    partial class AddedTotalPriceToUserLiftCard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

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

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SkiResorts.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ManagerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ResortId");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ResortId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SkiResorts.Data.Models.Lift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<int>("Length");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ResortId");

                    b.Property<int>("Seats");

                    b.Property<int>("Status");

                    b.Property<int>("VerticalDrop");

                    b.HasKey("Id");

                    b.HasIndex("ResortId");

                    b.ToTable("Lifts");
                });

            modelBuilder.Entity("SkiResorts.Data.Models.LiftCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaxDaysToUse");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("NumberOfPeople");

                    b.Property<decimal>("Price");

                    b.Property<int>("ResortId");

                    b.Property<int>("Sales");

                    b.HasKey("Id");

                    b.HasIndex("ResortId");

                    b.ToTable("LiftCards");
                });

            modelBuilder.Entity("SkiResorts.Data.Models.Resort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("OwnerId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("Resorts");
                });

            modelBuilder.Entity("SkiResorts.Data.Models.Slope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Difficulty");

                    b.Property<int>("Length");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("ResortId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ResortId");

                    b.ToTable("Slopes");
                });

            modelBuilder.Entity("SkiResorts.Data.Models.User", b =>
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

            modelBuilder.Entity("SkiResorts.Data.Models.UserLiftCard", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("LiftCardId");

                    b.Property<DateTime>("LiftCardDate");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("UserId", "LiftCardId");

                    b.HasIndex("LiftCardId");

                    b.ToTable("UserLiftCard");
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
                    b.HasOne("SkiResorts.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SkiResorts.Data.Models.User")
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

                    b.HasOne("SkiResorts.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SkiResorts.Data.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkiResorts.Data.Models.Event", b =>
                {
                    b.HasOne("SkiResorts.Data.Models.User", "Manager")
                        .WithMany("Events")
                        .HasForeignKey("ManagerId");

                    b.HasOne("SkiResorts.Data.Models.Resort", "Resort")
                        .WithMany("Events")
                        .HasForeignKey("ResortId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkiResorts.Data.Models.Lift", b =>
                {
                    b.HasOne("SkiResorts.Data.Models.Resort", "Resort")
                        .WithMany("Lifts")
                        .HasForeignKey("ResortId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkiResorts.Data.Models.LiftCard", b =>
                {
                    b.HasOne("SkiResorts.Data.Models.Resort", "Resort")
                        .WithMany("LiftCards")
                        .HasForeignKey("ResortId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkiResorts.Data.Models.Resort", b =>
                {
                    b.HasOne("SkiResorts.Data.Models.User", "Owner")
                        .WithOne("Resort")
                        .HasForeignKey("SkiResorts.Data.Models.Resort", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkiResorts.Data.Models.Slope", b =>
                {
                    b.HasOne("SkiResorts.Data.Models.Resort", "Resort")
                        .WithMany("Slopes")
                        .HasForeignKey("ResortId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SkiResorts.Data.Models.UserLiftCard", b =>
                {
                    b.HasOne("SkiResorts.Data.Models.LiftCard", "LiftCard")
                        .WithMany("Users")
                        .HasForeignKey("LiftCardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SkiResorts.Data.Models.User", "User")
                        .WithMany("LiftCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
