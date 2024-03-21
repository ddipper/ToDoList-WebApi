using Microsoft.EntityFrameworkCore;
using Models;
using SQLite;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();

app.UseRouting();
app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

/*ApplicationContextUser dbUser = new ApplicationContextUser();
ApplicationContextNote dbNote = new ApplicationContextNote();
dbUser.Database.EnsureCreated();
dbNote.Database.EnsureCreated();*/
ApplicationContext db = new ApplicationContext();
db.Database.EnsureCreated();

app.MapPost("/register", async context => {
    context.Response.ContentType = "application/json";
    var userCredentials = await context.Request.ReadFromJsonAsync<Models.UserCredentials>();
    
    User user = new User(userCredentials!.Username, userCredentials.Password);
    User isCreated = db.FindUserByName(userCredentials.Username);
    
    if (isCreated != null)
    {
        await context.Response.WriteAsJsonAsync(new { error = "taken" });
        return;
    }
    
    db.Users.Add(user);
    db.SaveChanges();
    
    Console.WriteLine($"/register | Username: {userCredentials.Username} Pass: {userCredentials.Password}");
    
    await context.Response.WriteAsJsonAsync(new { username = userCredentials?.Username, error = null as string});
});

app.MapPost("/login", async context => {
    context.Response.ContentType = "application/json";
    var userCredentials = await context.Request.ReadFromJsonAsync<Models.UserCredentials>();
    
    User isCreated = db.FindUserByNameAndPassword(userCredentials!.Username, userCredentials.Password);

    if (isCreated == null)
    {
        await context.Response.WriteAsJsonAsync(new { error = "unregister"}); 
        return;
    }
    
    Console.WriteLine($"/login | Username: {userCredentials.Username} Pass: {userCredentials.Password}");
    await context.Response.WriteAsJsonAsync(new { username = userCredentials!.Username, error = null as string});
});

app.MapPost("/notes", async context => {
    context.Response.ContentType = "application/json";
    var noteCredentials = await context.Request.ReadFromJsonAsync<Models.NoteCredentials>();
    
    Console.WriteLine("/notes");
    await context.Response.WriteAsJsonAsync(new { notes = db.FindNotesByUsername(noteCredentials.Username)});
});

app.MapPost("/notes/add", async context => {
    context.Response.ContentType = "application/json";
    var noteCredentials = await context.Request.ReadFromJsonAsync<Models.NoteCredentials>();
    
    Note note = new Note(noteCredentials!.Username, noteCredentials!.Title, noteCredentials!.Description);
    
    db.Notes.Add(note);
    db.SaveChanges();
    
    Console.WriteLine($"/notes/add | Title: {noteCredentials!.Title} Description: {noteCredentials.Description}");
    await context.Response.WriteAsJsonAsync(new { data = "2"});
});

app.MapPost("/notes/delete", async context => {
    context.Response.ContentType = "application/json";
    var noteCredentials = await context.Request.ReadFromJsonAsync<Models.NoteCredentials>();
    
    Note note = db.FindNote(noteCredentials!.Username, noteCredentials!.Title, noteCredentials!.Description);

    db.Notes.Remove(note);
    db.SaveChanges();
    
    Console.WriteLine($"/notes/delete | Title: {noteCredentials!.Title} Description: {noteCredentials.Description}");
    await context.Response.WriteAsJsonAsync(new { data = "3"});
});

app.MapPost("/notes/edit", async context => {
    context.Response.ContentType = "application/json";
    var editNoteCredentials = await context.Request.ReadFromJsonAsync<Models.EditNoteCredentials>();
    
    Note note = db.FindNote(editNoteCredentials!.Username, editNoteCredentials!.Title, editNoteCredentials!.Description);
    note.Title = editNoteCredentials.NewTitle;
    note.Description = editNoteCredentials.NewDescription;
    
    db.Notes.Update(note);
    db.SaveChanges();
    
    Console.WriteLine($"/notes/edit | Title: {editNoteCredentials!.NewTitle} Description: {editNoteCredentials.NewDescription}");
    await context.Response.WriteAsJsonAsync(new { data = "3"});
});

app.Run();
