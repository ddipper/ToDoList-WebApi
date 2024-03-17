using Microsoft.EntityFrameworkCore;
 
namespace SQLite
{
    public class ApplicationContextNote : DbContext
    {
        public DbSet<SQLite.Note> Notes {get;set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./db/users.sqlite");
        }
        
        public List<Note> FindNotesByUsername(string name)
        {
            List<Note> notes = Notes.Where(u => u.Username == name).ToList();
            return notes;
        }

        public Note FindNote(string name, string title, string description)
        {
            return Notes.FirstOrDefault(u => u.Username == name && u.Title == title && u.Descripton == description);
        }
    }
}