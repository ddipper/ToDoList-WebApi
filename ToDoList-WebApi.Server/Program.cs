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

ApplicationContextUser dbUser = new ApplicationContextUser();
ApplicationContextNote dbNote = new ApplicationContextNote();
dbUser.Database.EnsureCreated();
dbNote.Database.EnsureCreated();

app.MapPost("/register", async context => {
    context.Response.ContentType = "application/json";
    var userCredentials = await context.Request.ReadFromJsonAsync<Models.UserCredentials>();
    
    User user = new User(userCredentials!.Username, userCredentials.Password);
    User isCreated = dbUser.FindUserByName(userCredentials.Username);
    
    if (isCreated != null)
    {
        await context.Response.WriteAsJsonAsync(new { error = "taken" });
        return;
    }
    
    dbUser.Users.Add(user);
    dbUser.SaveChanges();
    
    Console.WriteLine($"/register | Username: {userCredentials.Username} Pass: {userCredentials.Password}");
    
    await context.Response.WriteAsJsonAsync(new { username = userCredentials?.Username, error = null as string});
});

app.MapPost("/login", async context => {
    context.Response.ContentType = "application/json";
    var userCredentials = await context.Request.ReadFromJsonAsync<Models.UserCredentials>();
    
    User isCreated = dbUser.FindUserByNameAndPassword(userCredentials!.Username, userCredentials.Password);

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
    
    dbNote.Database.CloseConnection();
    
    Console.WriteLine("/notes");
    await context.Response.WriteAsJsonAsync(new { notes = dbNote.FindNotesByUsername(noteCredentials.Username)});
});

app.MapPost("/notes/add", async context => {
    context.Response.ContentType = "application/json";
    var noteCredentials = await context.Request.ReadFromJsonAsync<Models.NoteCredentials>();
    
    Note note = new Note(noteCredentials!.Username, noteCredentials!.Title, noteCredentials!.Description);
    
    dbNote.Notes.Add(note);
    dbNote.SaveChanges();
    
    Console.WriteLine($"/notes/add | Title: {noteCredentials!.Title} Description: {noteCredentials.Description}");
    await context.Response.WriteAsJsonAsync(new { data = "2"});
});

app.MapPost("/notes/delete", async context => {
    context.Response.ContentType = "application/json";
    var noteCredentials = await context.Request.ReadFromJsonAsync<Models.NoteCredentials>();
    
    Note note = dbNote.FindNote(noteCredentials!.Username, noteCredentials!.Title, noteCredentials!.Description);

    dbNote.Notes.Remove(note);
    dbNote.SaveChanges();
    
    Console.WriteLine($"/notes/delete | Title: {noteCredentials!.Title} Description: {noteCredentials.Description}");
    await context.Response.WriteAsJsonAsync(new { data = "3"});
});

app.MapPost("/notes/edit", async context => {
    context.Response.ContentType = "application/json";
    var editNoteCredentials = await context.Request.ReadFromJsonAsync<Models.EditNoteCredentials>();
    
    Note note = dbNote.FindNote(editNoteCredentials!.Username, editNoteCredentials!.Title, editNoteCredentials!.Description);
    note.Title = editNoteCredentials.NewTitle;
    note.Description = editNoteCredentials.NewDescription;
    
    dbNote.Notes.Update(note);
    dbNote.SaveChanges();
    
    Console.WriteLine($"/notes/edit | Title: {editNoteCredentials!.NewTitle} Description: {editNoteCredentials.NewDescription}");
    await context.Response.WriteAsJsonAsync(new { data = "3"});
});

app.Run();
