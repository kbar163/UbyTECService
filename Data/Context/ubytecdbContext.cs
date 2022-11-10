using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UbyTECService.Models.Generated;

namespace UbyTECService.Data.Context
{
    public partial class ubytecdbContext : DbContext
    {
        public ubytecdbContext()
        {
        }

        public ubytecdbContext(DbContextOptions<ubytecdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminAfiTelefono> AdminAfiTelefonos { get; set; } = null!;
        public virtual DbSet<AdminUbyTelefono> AdminUbyTelefonos { get; set; } = null!;
        public virtual DbSet<AdministradorAfiliado> AdministradorAfiliados { get; set; } = null!;
        public virtual DbSet<AdministradorUby> AdministradorUbies { get; set; } = null!;
        public virtual DbSet<Afiliado> Afiliados { get; set; } = null!;
        public virtual DbSet<AfiliadoTelefono> AfiliadoTelefonos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteTelefono> ClienteTelefonos { get; set; } = null!;
        public virtual DbSet<TipoComercio> TipoComercios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=ubytec-pg.postgres.database.azure.com;Database=ubytecdb;Port=5432;User Id=adminubytec;Password=Bases2022!;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminAfiTelefono>(entity =>
            {
                entity.ToTable("admin_afi_telefonos");

                entity.HasIndex(e => e.Telefono, "u_admin_afi_telefono")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .HasColumnName("telefono");

                entity.Property(e => e.UsuarioAdminAfi)
                    .HasMaxLength(9)
                    .HasColumnName("usuario_admin_afi");

                entity.HasOne(d => d.UsuarioAdminAfiNavigation)
                    .WithMany(p => p.AdminAfiTelefonos)
                    .HasForeignKey(d => d.UsuarioAdminAfi)
                    .HasConstraintName("fk_telefonos_admin_afi");
            });

            modelBuilder.Entity<AdminUbyTelefono>(entity =>
            {
                entity.ToTable("admin_uby_telefonos");

                entity.HasIndex(e => e.Telefono, "u_admin_uby_telefono")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CedulaAdminUby)
                    .HasMaxLength(9)
                    .HasColumnName("cedula_admin_uby");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CedulaAdminUbyNavigation)
                    .WithMany(p => p.AdminUbyTelefonos)
                    .HasForeignKey(d => d.CedulaAdminUby)
                    .HasConstraintName("fk_telefonos_admin_uby");
            });

            modelBuilder.Entity<AdministradorAfiliado>(entity =>
            {
                entity.HasKey(e => e.UsuarioAdminAfi)
                    .HasName("administrador_afiliado_pkey");

                entity.ToTable("administrador_afiliado");

                entity.HasIndex(e => e.CorreoElectronico, "u_admin_afi_email")
                    .IsUnique();

                entity.Property(e => e.UsuarioAdminAfi)
                    .HasMaxLength(50)
                    .HasColumnName("usuario_admin_afi");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Canton)
                    .HasMaxLength(50)
                    .HasColumnName("canton");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .HasColumnName("distrito");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.PasswordAdminAfi)
                    .HasMaxLength(50)
                    .HasColumnName("password_admin_afi");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .HasColumnName("segundo_apellido");
            });

            modelBuilder.Entity<AdministradorUby>(entity =>
            {
                entity.HasKey(e => e.CedulaAdminUby)
                    .HasName("administrador_uby_pkey");

                entity.ToTable("administrador_uby");

                entity.HasIndex(e => e.CorreoElectronico, "u_admin_email")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioAdminUby, "u_admin_user")
                    .IsUnique();

                entity.Property(e => e.CedulaAdminUby)
                    .HasMaxLength(9)
                    .HasColumnName("cedula_admin_uby");

                entity.Property(e => e.Canton)
                    .HasMaxLength(50)
                    .HasColumnName("canton");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .HasColumnName("distrito");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.PasswordAdminUby)
                    .HasMaxLength(50)
                    .HasColumnName("password_admin_uby");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .HasColumnName("segundo_apellido");

                entity.Property(e => e.UsuarioAdminUby)
                    .HasMaxLength(50)
                    .HasColumnName("usuario_admin_uby");
            });

            modelBuilder.Entity<Afiliado>(entity =>
            {
                entity.HasKey(e => e.CedulaJuridica)
                    .HasName("afiliado_pkey");

                entity.ToTable("afiliado");

                entity.HasIndex(e => e.Correo, "u_afiliado_correo")
                    .IsUnique();

                entity.Property(e => e.CedulaJuridica)
                    .HasMaxLength(12)
                    .HasColumnName("cedula_juridica");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Canton)
                    .HasMaxLength(50)
                    .HasColumnName("canton");

                entity.Property(e => e.ComentarioSolicitud)
                    .HasMaxLength(200)
                    .HasColumnName("comentario_solicitud");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .HasColumnName("distrito");

                entity.Property(e => e.NombreComercio)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_comercio");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.SinpeMovil)
                    .HasMaxLength(8)
                    .HasColumnName("sinpe_movil");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.Afiliados)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_afiliado_tipo");
            });

            modelBuilder.Entity<AfiliadoTelefono>(entity =>
            {
                entity.ToTable("afiliado_telefonos");

                entity.HasIndex(e => e.Telefono, "u_afiliado_telefono")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CedulaJuridica)
                    .HasMaxLength(12)
                    .HasColumnName("cedula_juridica");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CedulaJuridicaNavigation)
                    .WithMany(p => p.AfiliadoTelefonos)
                    .HasForeignKey(d => d.CedulaJuridica)
                    .HasConstraintName("fk_telefonos_afiliado");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CedulaCliente)
                    .HasName("cliente_pkey");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.CorreoElectronico, "u_cliente_email")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioCliente, "u_cliente_user")
                    .IsUnique();

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(9)
                    .HasColumnName("cedula_cliente");

                entity.Property(e => e.Canton)
                    .HasMaxLength(50)
                    .HasColumnName("canton");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .HasColumnName("distrito");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.PasswordCliente)
                    .HasMaxLength(50)
                    .HasColumnName("password_cliente");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .HasColumnName("segundo_apellido");

                entity.Property(e => e.UsuarioCliente)
                    .HasMaxLength(50)
                    .HasColumnName("usuario_cliente");
            });

            modelBuilder.Entity<ClienteTelefono>(entity =>
            {
                entity.ToTable("cliente_telefonos");

                entity.HasIndex(e => e.Telefono, "u_cliente_telefono")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(9)
                    .HasColumnName("cedula_cliente");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CedulaClienteNavigation)
                    .WithMany(p => p.ClienteTelefonos)
                    .HasForeignKey(d => d.CedulaCliente)
                    .HasConstraintName("fk_telefonos_cliente");
            });

            modelBuilder.Entity<TipoComercio>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("tipo_comercio_pkey");

                entity.ToTable("tipo_comercio");

                entity.Property(e => e.IdTipo)
                    .ValueGeneratedNever()
                    .HasColumnName("id_tipo");

                entity.Property(e => e.NombreTipo)
                    .HasMaxLength(30)
                    .HasColumnName("nombre_tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
