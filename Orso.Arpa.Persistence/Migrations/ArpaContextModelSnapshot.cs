﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orso.Arpa.Persistence.DataAccess;

namespace Orso.Arpa.Persistence.Migrations
{
    [DbContext(typeof(ArpaContext))]
    partial class ArpaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<Guid?>("PersonId");

                    b.Property<Guid?>("RegionId");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RegionId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<Guid?>("EmolumentId");

                    b.Property<Guid?>("EmolumentPatternId");

                    b.Property<DateTimeOffset>("EndTime");

                    b.Property<string>("InternalDetails");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("PublicDetails");

                    b.Property<DateTimeOffset>("StartTime");

                    b.Property<Guid?>("StatusId");

                    b.Property<Guid?>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EmolumentId");

                    b.HasIndex("EmolumentPatternId");

                    b.HasIndex("StatusId");

                    b.HasIndex("VenueId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.AppointmentParticipation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AppointmentId");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<Guid?>("ExpectationId");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<Guid>("PersonId");

                    b.Property<Guid?>("PredictionId");

                    b.Property<Guid?>("ResultId");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ExpectationId");

                    b.HasIndex("PersonId");

                    b.HasIndex("PredictionId");

                    b.HasIndex("ResultId");

                    b.ToTable("AppointmentParticipation");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.MusicianProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("IsProfessional");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<Guid>("PersonId");

                    b.Property<Guid>("RegisterId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RegisterId");

                    b.ToTable("MusicianProfile");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("GivenName");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<Guid?>("GenreId");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<int>("Number");

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("ParentId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.ProjectAppointment", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<Guid>("AppointmentId");

                    b.HasKey("ProjectId", "AppointmentId");

                    b.HasIndex("AppointmentId");

                    b.ToTable("ProjectAppointment");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Register", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.RegisterAppointment", b =>
                {
                    b.Property<Guid>("RegisterId");

                    b.Property<Guid>("AppointmentId");

                    b.HasKey("RegisterId", "AppointmentId");

                    b.HasIndex("AppointmentId");

                    b.ToTable("RegisterAppointment");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.RehearsalRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<Guid>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("RehearsalRoom");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
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
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.SelectValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("SelectValue");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.SelectValueCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Property");

                    b.Property<string>("Table");

                    b.HasKey("Id");

                    b.ToTable("SelectValueCategory");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.SelectValueMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<Guid>("SelectValueCategoryId");

                    b.Property<Guid>("SelectValueId");

                    b.HasKey("Id");

                    b.HasIndex("SelectValueCategoryId");

                    b.HasIndex("SelectValueId");

                    b.ToTable("SelectValueMap");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<bool>("Deleted");

                    b.Property<string>("DisplayName");

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

                    b.Property<Guid>("PersonId");

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
                        .HasName("UserNameIndex");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<DateTimeOffset>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<DateTimeOffset?>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orso.Arpa.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Address", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId");

                    b.HasOne("Orso.Arpa.Domain.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueMap", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueMap", "Emolument")
                        .WithMany()
                        .HasForeignKey("EmolumentId");

                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueMap", "EmolumentPattern")
                        .WithMany()
                        .HasForeignKey("EmolumentPatternId");

                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueMap", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("Orso.Arpa.Domain.Entities.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.AppointmentParticipation", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Appointment", "Appointment")
                        .WithMany("AppointmentParticipations")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueMap", "Expectation")
                        .WithMany()
                        .HasForeignKey("ExpectationId");

                    b.HasOne("Orso.Arpa.Domain.Entities.Person", "Person")
                        .WithMany("AppointmentParticipations")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueMap", "Prediction")
                        .WithMany()
                        .HasForeignKey("PredictionId");

                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueMap", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.MusicianProfile", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Person", "Person")
                        .WithMany("MusicianProfiles")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orso.Arpa.Domain.Entities.Register", "Register")
                        .WithMany("MusicianProfiles")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Project", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueMap", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("Orso.Arpa.Domain.Entities.Project", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.ProjectAppointment", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Appointment", "Appointment")
                        .WithMany("ProjectAppointments")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orso.Arpa.Domain.Entities.Project", "Project")
                        .WithMany("ProjectAppointments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Register", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Register", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.RegisterAppointment", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Appointment", "Appointment")
                        .WithMany("RegisterAppointments")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orso.Arpa.Domain.Entities.Register", "Register")
                        .WithMany("RegisterAppointments")
                        .HasForeignKey("RegisterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.RehearsalRoom", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Venue", "Venue")
                        .WithMany("RehearsalRooms")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.SelectValueMap", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValueCategory", "SelectValueCategory")
                        .WithMany()
                        .HasForeignKey("SelectValueCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orso.Arpa.Domain.Entities.SelectValue", "SelectValue")
                        .WithMany()
                        .HasForeignKey("SelectValueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.User", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Person", "Person")
                        .WithOne("user")
                        .HasForeignKey("Orso.Arpa.Domain.Entities.User", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orso.Arpa.Domain.Entities.Venue", b =>
                {
                    b.HasOne("Orso.Arpa.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
