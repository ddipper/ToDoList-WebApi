using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using SQLite;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();

app.UseRouting();
app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

ApplicationContextUser db = new ApplicationContextUser();


app.MapPost("/register", async context => {
    context.Response.ContentType = "application/json";
    var userCredentials = await context.Request.ReadFromJsonAsync<Models.UserCredentials>();
    
    db.Database.EnsureCreated();
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

    db.Database.EnsureCreated();
    User isCreated = db.FindUserByNameAndPassword(userCredentials!.Username, userCredentials.Password);

    if (isCreated == null)
    {
        await context.Response.WriteAsJsonAsync(new { error = "unregister"}); 
        return;
    }

    await context.Response.WriteAsJsonAsync(new { username = userCredentials!.Username, error = null as string});
});

app.Run();