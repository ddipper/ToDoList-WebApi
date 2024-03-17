using System.ComponentModel.DataAnnotations;

namespace SQLite;

public class Note
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Title { get; set; }
    public string Descripton { get; set; }

    public Note(string title, string descripton)
    {
        Title = title;
        Descripton = descripton;
    }
}