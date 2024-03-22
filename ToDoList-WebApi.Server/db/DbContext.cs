using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace SQLite
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Env.Load();
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            optionsBuilder.UseSqlite(connectionString);
        }

        public User FindUserByName(string name)
        {
            return Users.FirstOrDefault(u => u.Name == name);
        }

        public User FindUserByNameAndPassword(string name, string password)
        {
            return Users.FirstOrDefault(u => u.Name == name && u.Password == password);
        }

        public List<Note> FindNotesByUsername(string name)
        {
            return Notes.Where(u => u.Username == name).ToList();
        }

        public Note FindNote(string name, string title, string description)
        {
            return Notes.FirstOrDefault(u => u.Username == name && u.Title == title && u.Description == description);
        }
    }
}