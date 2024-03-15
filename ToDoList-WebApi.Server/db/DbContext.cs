using Microsoft.EntityFrameworkCore;
 
namespace SQLite
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SQLite.User> Users {get;set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
        }
    }
}