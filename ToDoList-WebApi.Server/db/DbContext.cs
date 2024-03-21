using Microsoft.EntityFrameworkCore;
 
namespace SQLite
{
    public class ApplicationContextUser : DbContext
    {
        public DbSet<User> Users {get;set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./db/users.sqlite");
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
    
    public class ApplicationContextNote : DbContext
    {
        public DbSet<Note> Notes {get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./db/notes.db");
        }
        
        public List<Note> FindNotesByUsername(string name)
        {
            List<Note> notes = Notes.Where(u => u.Username == name).ToList();
            return notes;
        }

        public Note FindNote(string name, string title, string description)
        {
            return Notes.FirstOrDefault(u => u.Username == name && u.Title == title && u.Description == description);
        }
    }
}