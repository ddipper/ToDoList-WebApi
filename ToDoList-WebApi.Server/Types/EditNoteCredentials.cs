using System.Text.Json.Serialization;

namespace Models;

public class EditNoteCredentials : NoteCredentials
{
    public required string NewTitle { get; set; }
    public required string NewDescription { get; set; }
    
    [JsonConstructor]
    public EditNoteCredentials(string username, string title, string description, string newTitle, string newDescription) : base(username, title, description)
    {
        NewTitle = newTitle;
        NewDescription = newDescription;
    }
}