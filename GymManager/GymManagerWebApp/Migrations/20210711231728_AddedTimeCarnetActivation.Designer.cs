﻿// <auto-generated />
using System;
using GymManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymManagerWebApp.Migrations
{
    [DbContext(typeof(GymManagerContext))]
    [Migration("20210711231728_AddedTimeCarnetActivation")]
    partial class AddedTimeCarnetActivation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoachExercise", b =>
                {
                    b.Property<string>("CoachesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExercisesId")
                        .HasColumnType("int");

                    b.HasKey("CoachesId", "ExercisesId");

                    b.HasIndex("ExercisesId");

                    b.ToTable("CoachExercise");
                });

            modelBuilder.Entity("ExerciseRoom", b =>
                {
                    b.Property<int>("ExercisesId")
                        .HasColumnType("int");

                    b.Property<int>("RoomsId")
                        .HasColumnType("int");

                    b.HasKey("ExercisesId", "RoomsId");

                    b.HasIndex("RoomsId");

                    b.ToTable("ExerciseRoom");
                });

            modelBuilder.Entity("GymManagerWebApp.Carnet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carnet");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Carnet");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.CalendarEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoachId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("VacanciesLeft")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("RoomId");

                    b.ToTable("CalendarEvents");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarnetId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<int>("PurchaseActivationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarnetId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PurchaseActivationId")
                        .IsUnique();

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.PurchaseActivation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExploited")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PurchaseActivations");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PurchaseActivation");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CalendarEventId")
                        .HasColumnType("int");

                    b.Property<bool>("CanBeCanceled")
                        .HasColumnType("bit");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CalendarEventId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxCustomersCapacity")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GymManagerWebApp.QuantityCarnet", b =>
                {
                    b.HasBaseType("GymManagerWebApp.Carnet");

                    b.Property<int>("TotalEtrances")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("QuantityCarnet");
                });

            modelBuilder.Entity("GymManagerWebApp.TimeCarnet", b =>
                {
                    b.HasBaseType("GymManagerWebApp.Carnet");

                    b.Property<int>("PeriodInDays")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("TimeCarnet");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.TimeCarnetActivation", b =>
                {
                    b.HasBaseType("GymManagerWebApp.Models.PurchaseActivation");

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ActiveUntil")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("TimeCarnetActivation");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Coach", b =>
                {
                    b.HasBaseType("GymManagerWebApp.Models.User");

                    b.HasDiscriminator().HasValue("Coach");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Customer", b =>
                {
                    b.HasBaseType("GymManagerWebApp.Models.User");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("CoachExercise", b =>
                {
                    b.HasOne("GymManagerWebApp.Models.Coach", null)
                        .WithMany()
                        .HasForeignKey("CoachesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagerWebApp.Models.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExerciseRoom", b =>
                {
                    b.HasOne("GymManagerWebApp.Models.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagerWebApp.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymManagerWebApp.Models.CalendarEvent", b =>
                {
                    b.HasOne("GymManagerWebApp.Models.Coach", "Coach")
                        .WithMany("CalendarEvents")
                        .HasForeignKey("CoachId");

                    b.HasOne("GymManagerWebApp.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");

                    b.HasOne("GymManagerWebApp.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.Navigation("Coach");

                    b.Navigation("Exercise");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Purchase", b =>
                {
                    b.HasOne("GymManagerWebApp.Carnet", "Carnet")
                        .WithMany()
                        .HasForeignKey("CarnetId");

                    b.HasOne("GymManagerWebApp.Models.Customer", "Customer")
                        .WithMany("Purchases")
                        .HasForeignKey("CustomerId");

                    b.HasOne("GymManagerWebApp.Models.PurchaseActivation", "Activation")
                        .WithOne("Purchase")
                        .HasForeignKey("GymManagerWebApp.Models.Purchase", "PurchaseActivationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activation");

                    b.Navigation("Carnet");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Reservation", b =>
                {
                    b.HasOne("GymManagerWebApp.Models.CalendarEvent", "CalendarEvent")
                        .WithMany()
                        .HasForeignKey("CalendarEventId");

                    b.HasOne("GymManagerWebApp.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId");

                    b.Navigation("CalendarEvent");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GymManagerWebApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GymManagerWebApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagerWebApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GymManagerWebApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymManagerWebApp.Models.PurchaseActivation", b =>
                {
                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Coach", b =>
                {
                    b.Navigation("CalendarEvents");
                });

            modelBuilder.Entity("GymManagerWebApp.Models.Customer", b =>
                {
                    b.Navigation("Purchases");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
