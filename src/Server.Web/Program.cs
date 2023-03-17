using DataLayer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataLayer();
builder.Services.AddControllers();

var app = builder.Build();

app.UseDataLayer();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
