using Kanban.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Infra.Database.Contexts
{
    public class KanbanContext : DbContext
    {
        public KanbanContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<ArtifactAttachment> ArtifactAttachments { get; set; }
        public DbSet<ArtifactStatus> ArtifactStatuses { get; set; }
        public DbSet<ArtifactType> ArtifactTypes { get; set; }
        public DbSet<Iteration> Iterations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artifact>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Artifact>()
                .HasOne(a => a.Type);

            modelBuilder.Entity<Artifact>()
                .HasOne(a => a.Project);

            modelBuilder.Entity<Artifact>()
                .HasOne(a => a.AssignedUser);

            modelBuilder.Entity<Artifact>()
                .HasOne(a => a.Status);

            modelBuilder.Entity<Artifact>()
                .HasOne(a => a.Iteration)
                .WithMany(i => i.Artifacts);

            modelBuilder.Entity<ArtifactAttachment>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<ArtifactAttachment>()
                .HasOne(aa => aa.Artifact)
                .WithMany(a => a.Attachments);
                
            modelBuilder.Entity<ArtifactStatus>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<ArtifactStatus>()
                .HasOne(s => s.Type)
                .WithMany(at => at.Statuses);

            modelBuilder.Entity<ArtifactType>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Iteration>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Iteration>()
                .HasOne(i => i.Team)
                .WithMany(t => t.Iterations);

            modelBuilder.Entity<Project>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Owner);

            modelBuilder.Entity<Team>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<User>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Team)
                .WithMany(t => t.Members);
        }
    }
}