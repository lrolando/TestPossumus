using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestPossumus.UnitOfWork;

public partial class ApiBDContext : DbContext
{
    public ApiBDContext()
    {
    }

    public ApiBDContext(DbContextOptions<ApiBDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidato> Candidatos { get; set; }

    public virtual DbSet<Empleo> Empleos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-P0KS4DF\\SQLEXPRESS;Initial Catalog=DBApiPossumus;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidato>(entity =>
        {
            entity.ToTable("Candidato");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaDeNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.IdEmpleoNavigation).WithMany(p => p.Candidatos)
                .HasForeignKey(d => d.IdEmpleo)
                .HasConstraintName("FK_Candidato_Empleo");
        });

        modelBuilder.Entity<Empleo>(entity =>
        {
            entity.ToTable("Empleo");

            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre-Empresa");
            entity.Property(e => e.Periodo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
