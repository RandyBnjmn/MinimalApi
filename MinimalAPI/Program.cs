using Microsoft.EntityFrameworkCore;
using MinimalAPI;
using MinimalAPI.Models;
using MinimalAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddScoped<ITasksRespository, TasksRepository>();


var app = builder.Build();

app.MapGet("/", async (ITasksRespository _taskRepository) => await _taskRepository.GetTasks());

app.MapGet("/tasks/{id}", async (int id, ITasksRespository _taskRepository) =>
{
    var tasks = await _taskRepository.GetTasks();
    if (id > tasks.Count())
        return Results.BadRequest();
    if (id == 0)
        return Results.BadRequest();



    return Results.Ok(await _taskRepository.GetTasks());

});

app.MapGet("/tasks-completed", async (ITasksRespository _tasksrepository) => await _tasksrepository.GetTasksCompleted());

app.MapGet("/tasks-incompleted", async (ITasksRespository _tasksrepository) => await _tasksrepository.GetTasksIncompleted());

app.MapPost("/tasks", async (ITasksRespository _tasksRepository, Tasks task) => await _tasksRepository.SaveTask(task));

app.Run();
