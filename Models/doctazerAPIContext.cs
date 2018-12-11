using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Doctazer.API.Models
{
    public partial class doctazerAPIContext : DbContext
    {
        public doctazerAPIContext()
        {
        }

        public doctazerAPIContext(DbContextOptions<doctazerAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<ClinicDoctors> ClinicDoctors { get; set; }
        public virtual DbSet<Clinics> Clinics { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Slots> Slots { get; set; }
        public virtual DbSet<Specialities> Specialities { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456;Database=doctazerAPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

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

                entity.Property(e => e.UserId).HasColumnName("user_id");
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

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(191);
            });

            modelBuilder.Entity<Slots>(entity =>
            {
                entity.ToTable("slots");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.Filled)
                    .HasColumnName("filled")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.UserId).HasColumnName("user_id");
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

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(191);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.ValidMessage)
                    .HasColumnName("valid_message")
                    .HasMaxLength(191);

                entity.Property(e => e.ValidType)
                    .HasColumnName("valid_type")
                    .HasDefaultValueSql("0");
            });
        }
    }
}
