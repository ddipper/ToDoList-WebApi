using System.ComponentModel.DataAnnotations;

namespace SQLite;

public class Note
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Note(string username, string title, string description)
    {
        Username = username;
        Title = title;
        Description = description;
    }
}