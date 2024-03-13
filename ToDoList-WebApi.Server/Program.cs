var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseRouting();

app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.MapPost("/register", async context =>
{
    var userCredentials = await context.Request.ReadFromJsonAsync<Models.UserCredentials>();
    Console.WriteLine($"/register !!! Username: {userCredentials?.Username}");
    
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsJsonAsync(new { username = userCredentials?.Username, error = "123" });
});

app.Run();