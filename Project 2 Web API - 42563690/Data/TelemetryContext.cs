using Microsoft.EntityFrameworkCore;
using Project_2_Web_API___42563690.Repository.Models;


namespace Project_2_Web_API___42563690.Data
{
    public class TelemetryContext : DbContext
    {
        public TelemetryContext(DbContextOptions<TelemetryContext> options)
        : base(options)
        {
        }

        public DbSet<JobTelemetry> JobTelemetries { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<JobTelemetry>()
                .HasOne(jt => jt.Project)
                .WithMany(p => p.JobTelemetries)
                .HasForeignKey(jt => jt.ProjectID);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientID);
        }
    }
}
