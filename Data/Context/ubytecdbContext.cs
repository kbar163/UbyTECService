using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UbyTECService.Models.Generated;
using UbyTECService.Models.Login;
using UbyTECService.Models.OrderManagement;

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
        public virtual DbSet<AfiliadoAdmin> AfiliadoAdmins { get; set; } = null!;
        public virtual DbSet<AfiliadoTelefono> AfiliadoTelefonos { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<ClienteTelefono> ClienteTelefonos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<PedidoProducto> PedidoProductos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Repartidor> Repartidors { get; set; } = null!;
        public virtual DbSet<RepartidorTelefono> RepartidorTelefonos { get; set; } = null!;
        public virtual DbSet<TipoComercio> TipoComercios { get; set; } = null!;
        public virtual DbSet<ValidateUbyAdmin> ValidateUbyAdmins {get; set; } = null!;
        public virtual DbSet<ValidateAfiAdmin> ValidateAfiAdmins {get; set; } = null!;
        public virtual DbSet<ValidateCustomer> ValidateCustomers {get; set; } = null!;
        public virtual DbSet<OrderID> PostInsertID {get; set; } = null!;

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

            modelBuilder.Entity<AfiliadoAdmin>(entity =>
            {
                entity.HasKey(e => e.UsuarioAdminAfi)
                    .HasName("afiliado_admin_pkey");

                entity.ToTable("afiliado_admin");

                entity.Property(e => e.UsuarioAdminAfi)
                    .HasMaxLength(50)
                    .HasColumnName("usuario_admin_afi");

                entity.Property(e => e.CedulaJuridica)
                    .HasMaxLength(12)
                    .HasColumnName("cedula_juridica");

                entity.HasOne(d => d.CedulaJuridicaNavigation)
                    .WithMany(p => p.AfiliadoAdmins)
                    .HasForeignKey(d => d.CedulaJuridica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_afiliadoadmin_afiliado");

                entity.HasOne(d => d.UsuarioAdminAfiNavigation)
                    .WithOne(p => p.AfiliadoAdmin)
                    .HasForeignKey<AfiliadoAdmin>(d => d.UsuarioAdminAfi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_afiliadoadmin_administradorafiliado");
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

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("categoria_pkey");

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_categoria");
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

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("estado_pkey");

                entity.ToTable("estado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.NombreEstado)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_estado");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("pedido_pkey");

                entity.ToTable("pedido");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.Canton)
                    .HasMaxLength(50)
                    .HasColumnName("canton");

                entity.Property(e => e.CedulaCliente)
                    .HasMaxLength(9)
                    .HasColumnName("cedula_cliente");

                entity.Property(e => e.CedulaJuridica)
                    .HasMaxLength(12)
                    .HasColumnName("cedula_juridica");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .HasColumnName("distrito");

                entity.Property(e => e.FechaPedido)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fecha_pedido");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.UsuarioRepart)
                    .HasMaxLength(50)
                    .HasColumnName("usuario_repart");

                entity.HasOne(d => d.CedulaClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CedulaCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_cliente");

                entity.HasOne(d => d.CedulaJuridicaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CedulaJuridica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_afiliado");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_estado");

                entity.HasOne(d => d.UsuarioRepartNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.UsuarioRepart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedido_repartidor");
            });

            modelBuilder.Entity<PedidoProducto>(entity =>
            {
                entity.HasKey(e => e.IdLinea)
                    .HasName("pedido_producto_pkey");

                entity.ToTable("pedido_producto");

                entity.Property(e => e.IdLinea).HasColumnName("id_linea");

                entity.Property(e => e.IdPedido).HasColumnName("id_pedido");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoProductos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedidoproducto_pedido");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.PedidoProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedidoproducto_producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("producto_pkey");

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.CedulaJuridica)
                    .HasMaxLength(12)
                    .HasColumnName("cedula_juridica");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(50)
                    .HasColumnName("nombre_producto");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.UrlFoto)
                    .HasMaxLength(300)
                    .HasColumnName("url_foto");

                entity.HasOne(d => d.CedulaJuridicaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CedulaJuridica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_admin_afi");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_producto_categoria");
            });

            modelBuilder.Entity<Repartidor>(entity =>
            {
                entity.HasKey(e => e.UsuarioRepart)
                    .HasName("repartidor_pkey");

                entity.ToTable("repartidor");

                entity.HasIndex(e => e.CorreoRepart, "u_repartidor_email")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioRepart, "u_repartidor_usr")
                    .IsUnique();

                entity.Property(e => e.UsuarioRepart)
                    .HasMaxLength(50)
                    .HasColumnName("usuario_repart");

                entity.Property(e => e.Canton)
                    .HasMaxLength(50)
                    .HasColumnName("canton");

                entity.Property(e => e.CorreoRepart)
                    .HasMaxLength(50)
                    .HasColumnName("correo_repart");

                entity.Property(e => e.Disponible).HasColumnName("disponible");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .HasColumnName("distrito");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.PasswordRepart)
                    .HasMaxLength(50)
                    .HasColumnName("password_repart");

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

            modelBuilder.Entity<RepartidorTelefono>(entity =>
            {
                entity.HasKey(e => e.IdLinea)
                    .HasName("repartidor_telefonos_pkey");

                entity.ToTable("repartidor_telefonos");

                entity.HasIndex(e => e.TelefonoRepart, "u_repartidor_tel")
                    .IsUnique();

                entity.Property(e => e.IdLinea).HasColumnName("id_linea");

                entity.Property(e => e.TelefonoRepart)
                    .HasMaxLength(8)
                    .HasColumnName("telefono_repart");

                entity.Property(e => e.UsuarioRepart)
                    .HasMaxLength(50)
                    .HasColumnName("usuario_repart");

                entity.HasOne(d => d.UsuarioRepartNavigation)
                    .WithMany(p => p.RepartidorTelefonos)
                    .HasForeignKey(d => d.UsuarioRepart)
                    .HasConstraintName("fk_reparttelefonos_repartidor");
                
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

            modelBuilder.Entity<ValidateUbyAdmin>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.isValid)
                    .HasColumnName("validate_uby_admin_credentials");
            });

            modelBuilder.Entity<ValidateAfiAdmin>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.isValid)
                    .HasColumnName("validate_afi_admin_credentials");
            });

            modelBuilder.Entity<ValidateCustomer>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.isValid)
                    .HasColumnName("validate_customer_credentials");
            });

            modelBuilder.Entity<OrderID>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.IdPedido)
                    .HasColumnName("id_pedido");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
