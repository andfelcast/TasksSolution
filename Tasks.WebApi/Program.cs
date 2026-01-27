using Microsoft.EntityFrameworkCore;
using Tasks.Application.Services.Implementation;
using Tasks.Infrastructure.Repositories.Implementation;
using Tasks.WebApi.Services.Interfaces;
using Tasks.Domain.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<TasksDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("TasksDBConnection")));
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<ITasksService, TasksService>();
builder.Services.AddTransient<IGeneralService, GeneralService>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<ITasksRepository, TasksRepository>();
builder.Services.AddTransient<IGeneralRepository, GeneralRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
