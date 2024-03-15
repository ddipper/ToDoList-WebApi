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

ApplicationContext db = new ApplicationContext();


app.MapPost("/register", async context =>
{
    var userCredentials = await context.Request.ReadFromJsonAsync<Models.UserCredentials>();
    
    db.Database.EnsureCreated();
    User User = new User(userCredentials.Username, userCredentials.Password);
    db.Users.Add(User);
    db.SaveChanges();
    
    Console.WriteLine($"/register !!! Username: {userCredentials?.Username}");
    
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsJsonAsync(new { username = userCredentials?.Username, error = "0"});
});

app.Run();