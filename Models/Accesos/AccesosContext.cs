using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhoenixTemplate.Models.Accesos;

public partial class AccesosContext : DbContext
{
    public AccesosContext()
    {
    }

    public AccesosContext(DbContextOptions<AccesosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatGenero> CatGeneros { get; set; }

    public virtual DbSet<CatPerfile> CatPerfiles { get; set; }

    public virtual DbSet<CatTipoDocumento> CatTipoDocumentos { get; set; }

    public virtual DbSet<DetUsuario> DetUsuarios { get; set; }

    public virtual DbSet<PermisosVistaUser> PermisosVistaUsers { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vista> Vistas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=AccesosConnStr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatGenero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__CAT_GENE__F35167E1A5F018A0");

            entity.ToTable("CAT_GENEROS");

            entity.Property(e => e.IdGenero).HasColumnName("ID_GENERO");
            entity.Property(e => e.Estado)
                .HasDefaultValue(1)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .HasColumnName("GENERO");
        });

        modelBuilder.Entity<CatPerfile>(entity =>
        {
            entity.HasKey(e => e.IdPerfil).HasName("PK__CAT_PERF__90BDE809E188B24C");

            entity.ToTable("CAT_PERFILES");

            entity.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL");
            entity.Property(e => e.Estado)
                .HasDefaultValue(1)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Perfil)
                .HasMaxLength(100)
                .HasColumnName("PERFIL");
        });

        modelBuilder.Entity<CatTipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDoc).HasName("PK__CAT_TIPO__49C8351535EF9830");

            entity.ToTable("CAT_TIPO_DOCUMENTO");

            entity.Property(e => e.IdTipoDoc).HasColumnName("ID_TIPO_DOC");
            entity.Property(e => e.Estado)
                .HasDefaultValue(1)
                .HasColumnName("ESTADO");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(100)
                .HasColumnName("TIPO_DOC");
        });

        modelBuilder.Entity<DetUsuario>(entity =>
        {
            entity.HasKey(e => e.IdDetUser).HasName("PK__DET_USUA__66B0D1109E51373F");

            entity.ToTable("DET_USUARIOS");

            entity.Property(e => e.IdDetUser).HasColumnName("ID_DET_USER");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("APELLIDO");
            entity.Property(e => e.Celular)
                .HasMaxLength(25)
                .HasColumnName("CELULAR");
            entity.Property(e => e.Documento)
                .HasMaxLength(25)
                .HasColumnName("DOCUMENTO");
            entity.Property(e => e.IdGenero).HasColumnName("ID_GENERO");
            entity.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL");
            entity.Property(e => e.IdTipoDoc).HasColumnName("ID_TIPO_DOC");
            entity.Property(e => e.IdUser).HasColumnName("ID_USER");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.DetUsuarios)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_GENERO");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.DetUsuarios)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_PERFIL");

            entity.HasOne(d => d.IdTipoDocNavigation).WithMany(p => p.DetUsuarios)
                .HasForeignKey(d => d.IdTipoDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_TIPO_DOC");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.DetUsuarios)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_USER_DET");
        });

        modelBuilder.Entity<PermisosVistaUser>(entity =>
        {
            entity.HasKey(e => e.IdPvu).HasName("PK__PERMISOS__20A8787CC8A949FC");

            entity.ToTable("PERMISOS_VISTA_USER");

            entity.Property(e => e.IdPvu).HasColumnName("ID_PVU");
            entity.Property(e => e.Estado)
                .HasDefaultValue(1)
                .HasColumnName("ESTADO");
            entity.Property(e => e.IdUser).HasColumnName("ID_USER");
            entity.Property(e => e.IdVista).HasColumnName("ID_VISTA");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.PermisosVistaUsers)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_USER");

            entity.HasOne(d => d.IdVistaNavigation).WithMany(p => p.PermisosVistaUsers)
                .HasForeignKey(d => d.IdVista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_VISTA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__USUARIOS__95F484400445CAEF");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.IdUser).HasColumnName("ID_USER");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .HasColumnName("CLAVE");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .HasColumnName("CORREO");
            entity.Property(e => e.Estado)
                .HasDefaultValue(1)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaToken)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_TOKEN");
            entity.Property(e => e.Token)
                .HasMaxLength(200)
                .HasColumnName("TOKEN");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("USER_NAME");
        });

        modelBuilder.Entity<Vista>(entity =>
        {
            entity.HasKey(e => e.IdVista).HasName("PK__VISTAS__55EE97C15C82D90E");

            entity.ToTable("VISTAS");

            entity.Property(e => e.IdVista).HasColumnName("ID_VISTA");
            entity.Property(e => e.Controller)
                .HasMaxLength(100)
                .HasColumnName("CONTROLLER");
            entity.Property(e => e.Estado)
                .HasDefaultValue(1)
                .HasColumnName("ESTADO");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasDefaultValue("NONE")
                .HasColumnName("ICON");
            entity.Property(e => e.Nivel).HasColumnName("NIVEL");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Padre).HasColumnName("PADRE");
            entity.Property(e => e.Vista1)
                .HasMaxLength(100)
                .HasColumnName("VISTA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
