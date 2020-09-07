using Configuration.Configuration;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Configuration
{
    public class RecordBookContext : DbContext
    {
        public string ConnectionString { get; set; } =
            @"Data Source=MSQ-WSW-6950\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }


        public DbSet<RecordBook> RecordBooks { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RecordBookConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
           
        }
    }
}