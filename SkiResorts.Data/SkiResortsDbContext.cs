namespace SkiResorts.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Data.Models;

    public class SkiResortsDbContext : IdentityDbContext<User>
    {
        public SkiResortsDbContext(DbContextOptions<SkiResortsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Lift> Lifts { get; set; }

        public DbSet<LiftCard> LiftCards { get; set; }

        public DbSet<Resort> Resorts { get; set; }

        public DbSet<Slope> Slopes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasOne(u => u.Resort)
                .WithOne(r => r.Owner)
                .HasForeignKey<Resort>(r => r.OwnerId);

            builder
                .Entity<Event>()
                .HasOne(e => e.Resort)
                .WithMany(r => r.Events)
                .HasForeignKey(e => e.ResortId);

            builder
                .Entity<Event>()
                .HasOne(e => e.Manager)
                .WithMany(m => m.Events)
                .HasForeignKey(e => e.ManagerId);

            builder
                .Entity<Lift>()
                .HasOne(l => l.Resort)
                .WithMany(r => r.Lifts)
                .HasForeignKey(l => l.ResortId);

            builder
                .Entity<Slope>()
                .HasOne(s => s.Resort)
                .WithMany(r => r.Slopes)
                .HasForeignKey(s => s.ResortId);

            builder
                .Entity<LiftCard>()
                .HasOne(lc => lc.Resort)
                .WithMany(r => r.LiftCards)
                .HasForeignKey(lc => lc.ResortId);

            builder
                .Entity<UserLiftCard>()
                .HasKey(uc => new { uc.UserId, uc.LiftCardId, uc.LiftCardDate });

            builder
                .Entity<UserLiftCard>()
                .HasOne(uc => uc.LiftCard)
                .WithMany(l => l.Users)
                .HasForeignKey(uc => uc.LiftCardId);

            builder
                .Entity<UserLiftCard>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.LiftCards)
                .HasForeignKey(uc => uc.UserId);

            base.OnModelCreating(builder);
        }
    }
}
