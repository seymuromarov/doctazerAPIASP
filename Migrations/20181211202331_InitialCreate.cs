using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Doctazer.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    slot_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    time = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    patient_id = table.Column<int>(nullable: false),
                    doctor_id = table.Column<int>(nullable: false),
                    clinic_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    az = table.Column<string>(maxLength: 191, nullable: true),
                    en = table.Column<string>(maxLength: 191, nullable: true),
                    ru = table.Column<string>(maxLength: 191, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clinic_doctors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    doctor_id = table.Column<int>(nullable: false),
                    clinic_id = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinic_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clinics",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 191, nullable: true),
                    phone = table.Column<string>(maxLength: 191, nullable: true),
                    about = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    user_id = table.Column<int>(nullable: false),
                    firstname = table.Column<string>(maxLength: 191, nullable: true),
                    lastname = table.Column<string>(maxLength: 191, nullable: true),
                    phone = table.Column<string>(maxLength: 191, nullable: true),
                    speciality_id = table.Column<int>(nullable: true),
                    about = table.Column<string>(nullable: true),
                    from_availabilities = table.Column<DateTime>(type: "date", nullable: true),
                    to_availabilities = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    user_id = table.Column<int>(nullable: false),
                    firstname = table.Column<string>(maxLength: 191, nullable: true),
                    lastname = table.Column<string>(maxLength: 191, nullable: true),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<int>(nullable: true),
                    phone = table.Column<string>(maxLength: 191, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(maxLength: 191, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "slots",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    user_id = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    time = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    filled = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    deleted_at = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slots", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specialities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    az = table.Column<string>(maxLength: 191, nullable: true),
                    en = table.Column<string>(maxLength: 191, nullable: true),
                    ru = table.Column<string>(maxLength: 191, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    email = table.Column<string>(maxLength: 191, nullable: false),
                    password = table.Column<string>(maxLength: 191, nullable: false),
                    valid_type = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    valid_message = table.Column<string>(maxLength: 191, nullable: true),
                    role_id = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "users_email_uindex",
                table: "users",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "clinic_doctors");

            migrationBuilder.DropTable(
                name: "clinics");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "slots");

            migrationBuilder.DropTable(
                name: "specialities");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
