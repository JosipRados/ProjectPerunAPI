using ProjectPerunAPI;
using ProjectPerunAPI.Repository;
using ProjectPerunAPI.Services;
using ProjectPerunAPI.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IElementsService, ElementsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<IShiftsService, ShiftsService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();


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
