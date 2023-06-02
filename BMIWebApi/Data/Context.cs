using BMIWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BMIWebApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<BMIThresholds> BMIThresholds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacient>()
                .HasOne(p => p.BMIIndex)
                .WithOne(b => b.Pacient)
                .HasForeignKey<BMIIndex>(b => b.PacientId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
