
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; } = null!;

        public DbSet<TopCategory> TopCategories { get; set; } = null!;

        public DbSet<TrendingProduct> TrendingProducts { get; set; } = null!;
        public DbSet<AppUser> AppUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrendingProduct>(entity =>
            {
                entity.Property(p => p.Price)
                      .HasPrecision(18, 2);

                entity.Property(p => p.OriginalPrice)
                      .HasPrecision(18, 2);

                entity.Property(p => p.Rating)
                      .HasPrecision(3, 2);
            });
        }
    }
}
