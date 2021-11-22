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

        public DbSet<Review> Reviews {get;set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUserCategory> AppUserCategories { get; set; }
        public DbSet<AppUserSkill> AppUserSkills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments{get;set;}
        public DbSet<UserFollowing> UserFollowings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CategorySkill> CategorySkills { get; set; }

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
                .WithMany(c => c.Mentors)
                .HasForeignKey(ac => ac.CategoryId);

            builder.Entity<AppUserSkill>(x => x.HasKey(aus => new { aus.MentorId, aus.SkillId }));

            builder.Entity<AppUserSkill>()
                .HasOne(aus => aus.Mentor)
                .WithMany(c => c.Skills)
                .HasForeignKey(aus => aus.MentorId);

            builder.Entity<AppUserSkill>()
                .HasOne(aus => aus.Skill)
                .WithMany(s => s.Mentors)
                .HasForeignKey(aus => aus.SkillId);

            builder.Entity<AppUserLevel>(x=> x.HasKey(al => new{al.AppUserId,al.LevelId}));

            builder.Entity<AppUserLevel>()
                .HasOne(u => u.AppUser)
                .WithMany(l => l.Levels)
                .HasForeignKey(al => al.AppUserId);

            builder.Entity<AppUserLevel>()
                .HasOne(u => u.Level)
                .WithMany(c => c.Mentors)
                .HasForeignKey(al => al.LevelId);

            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserFollowing>(b =>
            {
                b.HasKey(k => new{k.ObserverId,k.TargetId});

                b.HasOne(o => o.Observer)
                    .WithMany(f => f.Followings)
                    .HasForeignKey(o => o.ObserverId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(o => o.Target)
                    .WithMany(f => f.Followers)
                    .HasForeignKey(o => o.TargetId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Review>(b =>
            {
                b.HasKey(r => new{r.MentorId,r.ClientId});

                b.HasOne(r => r.Mentor)
                    .WithMany(cl => cl.ClientReviews)
                    .HasForeignKey(r => r.MentorId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(r => r.Client)
                    .WithMany(c => c.MentorReviews)
                    .HasForeignKey(r => r.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<CategorySkill>(x => x.HasKey(cs => new { cs.SkillId , cs.CategoryId }));

            builder.Entity<CategorySkill>()
                .HasOne(cs => cs.Skill)
                .WithMany(s => s.Categories)
                .HasForeignKey(cs => cs.SkillId);

            builder.Entity<CategorySkill>()
                .HasOne(cs => cs.Category)
                .WithMany(c => c.Skills)
                .HasForeignKey(cs => cs.CategoryId);
        }
    }
}