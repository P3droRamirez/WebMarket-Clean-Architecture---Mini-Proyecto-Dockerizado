
using Microsoft.EntityFrameworkCore;
using PRG.WebMarket.Backend.Domain.Entities;

namespace PRG.WebMarket.Backend.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        //Tenemos que crear en el contexto un constructor vacio para que el framework lo pueda usar
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

        /// <summary>
        /// Este metodo se usa para configurar el modelo de datos.Relaciones,keys etc
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId);


            // Configuración de las entidades
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderProduct>().ToTable("OrderProducts");

        }

        //Configuracion del AppDbContextFactory(Para hacer migraciones con tablas nuevas y relaciones)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WebMarket;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }


    }
}
