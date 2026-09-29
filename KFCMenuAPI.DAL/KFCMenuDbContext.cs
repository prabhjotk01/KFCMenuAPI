using KFCMenuAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace KFCMenuAPI.DAL
{
    public class KFCMenuDbContext : DbContext
    {
        public KFCMenuDbContext(DbContextOptions<KFCMenuDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasPrecision(10, 2);

            // Category 1 : Many MenuItems
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Category)
                .WithMany(c => c.MenuItems)
                .HasForeignKey(m => m.CategoryId);

            // MenuItem Many : Many Ingredient
            modelBuilder.Entity<MenuItem>()
                .HasMany(m => m.Ingredients)
                .WithMany(i => i.MenuItems);

            // Ingredient 1 : 1 Inventory
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Inventory)
                .WithOne(inv => inv.Ingredient)
                .HasForeignKey<Inventory>(inv => inv.IngredientId);
        }
    }
}