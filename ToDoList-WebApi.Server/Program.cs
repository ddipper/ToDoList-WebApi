var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

app.UseHttpsRedirection();

//app.MapFallbackToFile("/index.html");

app.Map("/dev", async (context) =>
{
    await context.Response.WriteAsync("you select /dev");
});

app.Run();