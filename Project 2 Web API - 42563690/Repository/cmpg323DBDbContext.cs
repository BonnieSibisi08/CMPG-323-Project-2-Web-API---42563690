using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project_2_Web_API___42563690.Repository.Models;

namespace Project_2_Web_API___42563690.Repository;

public partial class cmpg323DBDbContext : DbContext
{
    public cmpg323DBDbContext()
    {
    }

    public cmpg323DBDbContext(DbContextOptions<cmpg323DBDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<JobTelemetry> JobTelemetries { get; set; }

    public virtual DbSet<Process> Processes { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=4256369cmpg323.database.windows.net;Initial Catalog=cmpg323DB;User ID=BonnieSibisi08;Encrypt=True;Authentication=ActiveDirectoryInteractive");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.ClientId).ValueGeneratedNever();
        });

        modelBuilder.Entity<JobTelemetry>(entity =>
        {
            entity.Property(e => e.EntryDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ExcludeFromTimeSaving).HasDefaultValue(false);
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity.Property(e => e.ProcessId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateSubmitted).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DefaultBusinessFunction).HasDefaultValue("Unspecified");
            entity.Property(e => e.DefaultGeography).HasDefaultValue("Global");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.ProjectId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ProjectCreationDate).HasDefaultValueSql("(dateadd(hour,(2),getdate()))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
