using Microsoft.EntityFrameworkCore;
 
namespace SQLite
{
    public class ApplicationContextUser : DbContext
    {
        public DbSet<SQLite.User> Users {get;set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
        }
        public User FindUserByName(string name)
        {
            return Users.FirstOrDefault(u => u.Name == name);
        }
        public User FindUserByNameAndPassword(string name, string password)
        {
            return Users.FirstOrDefault(u => u.Name == name && u.Password == password);
        }
    }
}