using ChocoFreseo.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChocoFreseo.Data
{
    public class ChocoFreseoDbContext : DbContext
    {
        public ChocoFreseoDbContext(DbContextOptions<ChocoFreseoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<DireccionCliente> DireccionesCliente { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<Pedido> Pedidos { get; set; } = null!;
        public DbSet<DetallePedido> DetallesPedido { get; set; } = null!;
        public DbSet<Repartidor> Repartidores { get; set; } = null!;
        public DbSet<ZonaEntrega> ZonasEntrega { get; set; } = null!;
        public DbSet<Domicilio> Domicilios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------------------------------------
            // CLIENTE → DIRECCIONES (1 - N)
            // -------------------------------------------------------
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Direcciones)
                .WithOne(d => d.Cliente)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // -------------------------------------------------------
            // PEDIDO → DETALLES (1 - N)
            // -------------------------------------------------------
            modelBuilder.Entity<DetallePedido>()
                .HasOne(d => d.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(d => d.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetallePedido>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.DetallesPedido)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            // -------------------------------------------------------
            // DOMICILIO — TODAS LAS RELACIONES CONFIGURADAS MANUALMENTE
            // -------------------------------------------------------

            // Domicilio → Pedido (1 - 1)
            modelBuilder.Entity<Domicilio>()
                .HasOne(d => d.Pedido)
                .WithOne(p => p.Domicilio)
                .HasForeignKey<Domicilio>(d => d.PedidoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Domicilio → DirecciónCliente (N - 1)
            modelBuilder.Entity<Domicilio>()
                .HasOne(d => d.DireccionCliente)
                .WithMany()
                .HasForeignKey(d => d.DireccionClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Domicilio → ZonaEntrega (N - 1)
            modelBuilder.Entity<Domicilio>()
                .HasOne(d => d.ZonaEntrega)
                .WithMany()
                .HasForeignKey(d => d.ZonaEntregaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Domicilio → Repartidor (N - 1 / opcional)
            modelBuilder.Entity<Domicilio>()
                .HasOne(d => d.Repartidor)
                .WithMany(r => r.Domicilios)
                .HasForeignKey(d => d.RepartidorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
