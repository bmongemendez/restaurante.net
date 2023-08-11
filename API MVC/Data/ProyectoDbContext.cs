using Microsoft.EntityFrameworkCore;
using API_MVC.Models;

namespace API_MVC.Data
{
    public partial class ProyectoDbContext : DbContext
    {
        public ProyectoDbContext()
        {
        }

        public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriasModel> Categorias { get; set; }

        public virtual DbSet<PlatosModel> Platos { get; set; }

        public virtual DbSet<ReservasModel> Reservas { get; set; }

        public virtual DbSet<VentasModel> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatosModel>(entity =>
            {
                entity.HasIndex(e => e.CategoriaId, "IX_Platos_CategoriaId");

                entity.HasOne(d => d.Categoria).WithMany(p => p.Platos).HasForeignKey(d => d.CategoriaId);
            });

            modelBuilder.Entity<ReservasModel>(entity =>
            {
                entity.HasKey(e => e.NumeroReserva);
            });

            modelBuilder.Entity<VentasModel>(entity =>
            {
                entity.HasKey(e => e.NumeroOrden);

                entity.HasIndex(e => e.PlatoId, "IX_Ventas_PlatoId");

                entity.HasOne(d => d.Plato).WithMany(p => p.Venta).HasForeignKey(d => d.PlatoId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}