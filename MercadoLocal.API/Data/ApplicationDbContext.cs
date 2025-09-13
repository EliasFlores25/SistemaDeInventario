using Microsoft.EntityFrameworkCore;
using MercadoLocal.API.Models;

namespace MercadoLocal.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Productor> Productores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedidos { get; set; }
        public DbSet<Reseña> Reseñas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Productor>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuarioID);
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Productor)
                .WithMany(pr => pr.Productos)
                .HasForeignKey(p => p.ProductorID);
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.UsuarioID);
            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.PedidoID);
            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Producto)
                .WithMany(p => p.DetallesPedidos)
                .HasForeignKey(dp => dp.ProductoID);
            modelBuilder.Entity<Reseña>()
                .HasOne(r => r.Producto)
                .WithMany(p => p.Reseñas)
                .HasForeignKey(r => r.ProductoID);
            modelBuilder.Entity<Reseña>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reseñas)
                .HasForeignKey(r => r.UsuarioID);
        }
    }
}
