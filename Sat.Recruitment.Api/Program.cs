using Sat.Recruitment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection.
using var data = new FileStream(builder.Configuration.GetConnectionString("usersPath")!, FileMode.OpenOrCreate, FileAccess.ReadWrite);
builder.Services.AddSingleton(new DataContext(data));
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();