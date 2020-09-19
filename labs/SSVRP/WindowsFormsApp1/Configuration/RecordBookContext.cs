using Configuration.Configuration;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Configuration
{
    public class RecordBookContext : DbContext
    {
       
        public string ConnectionString { get; set; } =
            @"Server=(localdb)\MSSQLLocalDB;Database=Test;Integrated Security=True";
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