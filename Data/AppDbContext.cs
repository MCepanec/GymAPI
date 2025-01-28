using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<GymAPI.Models.Member> Member { get; set; } = default!;

        public DbSet<GymAPI.Models.WorkoutLog> WorkoutLog { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WorkoutLog>()
            .HasOne(w => w.Member)
            .WithMany(m => m.WorkoutLogs)
            .HasForeignKey(w => w.MemberId);
    }
    }
