using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IO.Models
{
    public partial class NexoDataBase : DbContext
    {
        public NexoDataBase()
        {
        }

        public NexoDataBase(DbContextOptions<NexoDataBase> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorPaciente> DoctorPacientes { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\SBD\\Proyectos2020\\LibreriasYPruebas\\Nexos\\IO\\DataBase\\DatabaseNexo.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);

                entity.ToTable("Doctor");

                entity.Property(e => e.Credencial)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Edad)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Especialidad).IsRequired();

                entity.Property(e => e.Hospital).IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DoctorPaciente>(entity =>
            {
                entity.HasKey(e => e.IdDoctorPaciente)
                    .HasName("PK__DoctorPa__EB873A7264936731");

                entity.ToTable("DoctorPaciente");

                entity.HasOne(d => d.DoctorNavigation)
                    .WithMany(p => p.DoctorPacientes)
                    .HasForeignKey(d => d.Doctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DoctorPac__Docto__276EDEB3");

                entity.HasOne(d => d.PacienteNavigation)
                    .WithMany(p => p.DoctorPacientes)
                    .HasForeignKey(d => d.Paciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DoctorPac__Pacie__286302EC");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente);

                entity.ToTable("Paciente");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Edad)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Identificacion).IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Seguro).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
