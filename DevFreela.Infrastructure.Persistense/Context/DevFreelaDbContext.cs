using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistense.Context
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProvidedService> ProvidedServices { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                    .HasKey(u => u.Id);

            modelBuilder
                .Entity<User>()
                    .HasMany(u => u.UserSkils)
                        .WithOne()
                        .HasForeignKey(us => us.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<UserSkill>()
                    .HasKey(us => us.Id);
            
            modelBuilder
                .Entity<ProvidedService>()
                    .HasKey(ps => ps.Id);

            modelBuilder
                .Entity<ProvidedService>()
                    .HasOne(ps => ps.Freelancer)
                        .WithMany(f => f.ProvidedServices)
                    .HasForeignKey(ps => ps.IdFreelancer)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<ProvidedService>()
                    .HasOne(ps => ps.Client)
                        .WithMany(f => f.OwningProvidedServices)
                    .HasForeignKey(ps => ps.IdClient)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Skill>()
                    .HasKey(s => s.Id);

            modelBuilder
                .Entity<Skill>()
                    .HasMany(s => s.UserSkills)
                        .WithOne()
                        .HasForeignKey(s => s.IdSkill)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
