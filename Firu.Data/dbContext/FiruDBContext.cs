using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Firu_Core.Models
{
    public partial class FiruDBContext : DbContext
    {
        //public FiruDBContext()
        //{
        //}

        public FiruDBContext(DbContextOptions<FiruDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Organizacion> Organizacion { get; set; }
        public virtual DbSet<Responsable> Responsable { get; set; }
        public virtual DbSet<TamanoMascota> TamanoMascota { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Voluntario> Voluntario { get; set; }
        public virtual DbSet<MeraPrueba> MeraPrueba { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\firuDB;Database=FiruDB;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascota>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Castrado)
                    .HasColumnName("castrado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Peso)
                    .HasColumnName("peso")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Raza)
                    .HasColumnName("raza")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsableId).HasColumnName("responsable_id");

                entity.Property(e => e.Tamano)
                    .HasColumnName("tamano")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Responsable)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.ResponsableId)
                    .HasConstraintName("fk_Responsable");

                entity.HasOne(d => d.TamanoNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.Tamano)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tamano_mascota");
            });

            modelBuilder.Entity<Organizacion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuit).HasColumnName("cuit");

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Responsable>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TamanoMascota>(entity =>
            {
                entity.ToTable("tamano_mascota");

                entity.HasIndex(e => e.Tamano)
                    .HasName("UQ__tamano_m__3862C979AE815927")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tamano)
                    .IsRequired()
                    .HasColumnName("tamano")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CEE6797C3");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Voluntario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Localidad)
                    .HasColumnName("localidad")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizacionId).HasColumnName("organizacion_id");

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Organizacion)
                    .WithMany(p => p.Voluntario)
                    .HasForeignKey(d => d.OrganizacionId)
                    .HasConstraintName("fk_Organizacion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
