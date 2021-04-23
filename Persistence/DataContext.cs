using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUserCategory> AppUserCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserCategory>(x => x.HasKey(ac => new { ac.AppUserId, ac.CategoryId }));

            builder.Entity<AppUserCategory>()
                .HasOne(u => u.AppUser)
                .WithMany(c => c.Categories)
                .HasForeignKey(ac => ac.AppUserId);

            builder.Entity<AppUserCategory>()
                .HasOne(u => u.Category)
                .WithMany(c => c.Consultants)
                .HasForeignKey(ac => ac.CategoryId);

            builder.Entity<AppUserLevel>(x=> x.HasKey(al => new{al.AppUserId,al.LevelId}));

            builder.Entity<AppUserLevel>()
                .HasOne(u => u.AppUser)
                .WithMany(l => l.Levels)
                .HasForeignKey(al => al.AppUserId);

            builder.Entity<AppUserLevel>()
                .HasOne(u => u.Level)
                .WithMany(c => c.Consultants)
                .HasForeignKey(al => al.LevelId);
        }
    }
}