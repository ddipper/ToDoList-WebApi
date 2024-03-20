using System.Text.Json.Serialization;

namespace Models;

public class NoteCredentials
{
    public required string Username { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    [JsonConstructor]
    protected NoteCredentials(string username, string title, string description)
    {
        Username = username;
        Title = title;
        Description = description;
    }
}