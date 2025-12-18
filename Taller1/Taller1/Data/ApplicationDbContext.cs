using Microsoft.EntityFrameworkCore;
using Taller1.Models;

namespace Taller1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tus DbSet aquí
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<VentaProducto> VentaProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relaciones aquí
            modelBuilder.Entity<VentaProducto>()
                .HasKey(vp => new { vp.VentaId, vp.ProductoId });

            modelBuilder.Entity<VentaProducto>()
                .HasOne(vp => vp.Venta)
                .WithMany(v => v.VentaProductos)
                .HasForeignKey(vp => vp.VentaId);

            modelBuilder.Entity<VentaProducto>()
                .HasOne(vp => vp.Producto)
                .WithMany(p => p.VentaProductos)
                .HasForeignKey(vp => vp.ProductoId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
