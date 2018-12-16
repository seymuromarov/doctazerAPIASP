using System;
using Doctazer.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Doctazer.API.Data
{
    public partial class doctazerAPIContext : IdentityDbContext
    {
        public doctazerAPIContext()
        {
        }

        public doctazerAPIContext(DbContextOptions<doctazerAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<ClinicDoctors> ClinicDoctors { get; set; }
        public virtual DbSet<Clinics> Clinics { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<PatientAttemps> PatientAttemps { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Reasons> Reasons { get; set; }
        public virtual DbSet<Slots> Slots { get; set; }
        public virtual DbSet<Specialities> Specialities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=doctazerAPI;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasMaxLength(191);

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasMaxLength(191);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("addresses_cities_id_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("addresses_aspnetusers_id_fk");
            });

            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.ToTable("appointments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClinicId).HasColumnName("clinic_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.Property(e => e.SlotId).HasColumnName("slot_id");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("time without time zone");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("appointments_clinics_id_fk");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_doctors_id_fk");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_patients_id_fk");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("appointments_slots_id_fk");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new {e.LoginProvider, e.ProviderKey});

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new {e.UserId, e.RoleId});

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new {e.UserId, e.LoginProvider, e.Name});

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasColumnType("timestamp with time zone");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Az)
                    .HasColumnName("az")
                    .HasMaxLength(191);

                entity.Property(e => e.En)
                    .HasColumnName("en")
                    .HasMaxLength(191);

                entity.Property(e => e.Ru)
                    .HasColumnName("ru")
                    .HasMaxLength(191);
            });

            modelBuilder.Entity<ClinicDoctors>(entity =>
            {
                entity.ToTable("clinic_doctors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClinicId).HasColumnName("clinic_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.ClinicDoctors)
                    .HasForeignKey(d => d.ClinicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clinic_doctors_clinics_id_fk");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ClinicDoctors)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clinic_doctors_doctors_id_fk");
            });

            modelBuilder.Entity<Clinics>(entity =>
            {
                entity.ToTable("clinics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.About).HasColumnName("about");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(191);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(191);

                entity.Property(e => e.UserId).HasColumnName("user_id");

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.Clinics)
//                    .HasForeignKey(d => d.UserId)
//                    .HasConstraintName("clinics_aspnetusers_id_fk");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.ToTable("doctors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.About).HasColumnName("about");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(191);

                entity.Property(e => e.FromAvailabilities)
                    .HasColumnName("from_availabilities")
                    .HasColumnType("date");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(191);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(191);

                entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");

                entity.Property(e => e.ToAvailabilities)
                    .HasColumnName("to_availabilities")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecialityId)
                    .HasConstraintName("doctors_specialities_id_fk");

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.Doctors)
//                    .HasForeignKey(d => d.UserId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("doctors_aspnetusers_id_fk");
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.ToTable("favorites");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("favorites_doctors_id_fk");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("favorites_patients_id_fk");
            });

            modelBuilder.Entity<PatientAttemps>(entity =>
            {
                entity.ToTable("patient_attemps");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.PatientId).HasColumnName("patient_id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.PatientAttemps)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("patient_attemps_doctors_id_fk");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientAttemps)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("patient_attemps_patients_id_fk");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.ToTable("patients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(191);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(191);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(191);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id");

//                entity.HasOne(d => d.User)
//                    .WithMany(p => p.Patients)
//                    .HasForeignKey(d => d.UserId)
//                    .OnDelete(DeleteBehavior.ClientSetNull)
//                    .HasConstraintName("patients_aspnetusers_id_fk");
            });

            modelBuilder.Entity<Reasons>(entity =>
            {
                entity.ToTable("reasons");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Reasons)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reasons_doctors_id_fk");
            });

            modelBuilder.Entity<Slots>(entity =>
            {
                entity.ToTable("slots");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.DoctorId).HasColumnName("doctor_id");

                entity.Property(e => e.Filled)
                    .HasColumnName("filled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("time without time zone");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("slots_doctors_id_fk");
            });

            modelBuilder.Entity<Specialities>(entity =>
            {
                entity.ToTable("specialities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Az)
                    .HasColumnName("az")
                    .HasMaxLength(191);

                entity.Property(e => e.En)
                    .HasColumnName("en")
                    .HasMaxLength(191);

                entity.Property(e => e.Ru)
                    .HasColumnName("ru")
                    .HasMaxLength(191);
            });
        }
    }
}