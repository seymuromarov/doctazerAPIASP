﻿// <auto-generated />
using System;
using Doctazer.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Doctazer.API.Migrations
{
    [DbContext(typeof(doctazerAPIContext))]
    [Migration("20181211202331_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Doctazer.API.Models.Appointments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("ClinicId")
                        .HasColumnName("clinic_id");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<int>("DoctorId")
                        .HasColumnName("doctor_id");

                    b.Property<int>("PatientId")
                        .HasColumnName("patient_id");

                    b.Property<int>("SlotId")
                        .HasColumnName("slot_id");

                    b.Property<TimeSpan>("Time")
                        .HasColumnName("time")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("Doctazer.API.Models.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Az")
                        .HasColumnName("az")
                        .HasMaxLength(191);

                    b.Property<string>("En")
                        .HasColumnName("en")
                        .HasMaxLength(191);

                    b.Property<string>("Ru")
                        .HasColumnName("ru")
                        .HasMaxLength(191);

                    b.HasKey("Id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Doctazer.API.Models.ClinicDoctors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("ClinicId")
                        .HasColumnName("clinic_id");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("DoctorId")
                        .HasColumnName("doctor_id");

                    b.HasKey("Id");

                    b.ToTable("clinic_doctors");
                });

            modelBuilder.Entity("Doctazer.API.Models.Clinics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("About")
                        .HasColumnName("about");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(191);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(191);

                    b.HasKey("Id");

                    b.ToTable("clinics");
                });

            modelBuilder.Entity("Doctazer.API.Models.Doctors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("About")
                        .HasColumnName("about");

                    b.Property<string>("Firstname")
                        .HasColumnName("firstname")
                        .HasMaxLength(191);

                    b.Property<DateTime?>("FromAvailabilities")
                        .HasColumnName("from_availabilities")
                        .HasColumnType("date");

                    b.Property<string>("Lastname")
                        .HasColumnName("lastname")
                        .HasMaxLength(191);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(191);

                    b.Property<int?>("SpecialityId")
                        .HasColumnName("speciality_id");

                    b.Property<DateTime?>("ToAvailabilities")
                        .HasColumnName("to_availabilities")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("Doctazer.API.Models.Patients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("Dob")
                        .HasColumnName("dob")
                        .HasColumnType("date");

                    b.Property<string>("Firstname")
                        .HasColumnName("firstname")
                        .HasMaxLength(191);

                    b.Property<int?>("Gender")
                        .HasColumnName("gender");

                    b.Property<string>("Lastname")
                        .HasColumnName("lastname")
                        .HasMaxLength(191);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasMaxLength(191);

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("Doctazer.API.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(191);

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Doctazer.API.Models.Slots", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnName("deleted_at");

                    b.Property<int?>("Filled")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("filled")
                        .HasDefaultValueSql("0");

                    b.Property<TimeSpan>("Time")
                        .HasColumnName("time")
                        .HasColumnType("time without time zone");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("slots");
                });

            modelBuilder.Entity("Doctazer.API.Models.Specialities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Az")
                        .HasColumnName("az")
                        .HasMaxLength(191);

                    b.Property<string>("En")
                        .HasColumnName("en")
                        .HasMaxLength(191);

                    b.Property<string>("Ru")
                        .HasColumnName("ru")
                        .HasMaxLength(191);

                    b.HasKey("Id");

                    b.ToTable("specialities");
                });

            modelBuilder.Entity("Doctazer.API.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(191);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(191);

                    b.Property<int?>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<string>("ValidMessage")
                        .HasColumnName("valid_message")
                        .HasMaxLength(191);

                    b.Property<int?>("ValidType")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("valid_type")
                        .HasDefaultValueSql("0");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("users_email_uindex");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}