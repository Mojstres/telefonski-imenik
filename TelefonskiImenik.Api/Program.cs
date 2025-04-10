using TelefonskiImenik.DataAccess;
using TelefonskiImenik.Logic;

var builder = WebApplication.CreateBuilder(args);

// Povezava na bazo
var connectionString = builder.Configuration.GetConnectionString("conn")
    ?? throw new InvalidOperationException("Connection string 'conn' not found.");


var repository = new ContactRepository(connectionString);
var contactService = new ContactService(repository);

builder.Services.AddSingleton(contactService);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();