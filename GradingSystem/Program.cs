using GradeDO;
using GradingSystem.Configurations;
using GradingSystem.Services;
using Microsoft.AspNetCore.Builder;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Percents>(builder.Configuration.GetSection("Percents"));
builder.Services.Configure<Teacher>(builder.Configuration.GetSection("Teacher"));
builder.Services.AddSingleton<IStudents, Students>();
builder.Services.AddScoped<IPasswordManager, PasswordManager>();
builder.Services.AddSingleton<IGradeManagement,GradeManagement> ();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(builder.Configuration.GetValue<string>("Logging:LogFilePath"), rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();
app.UseStaticFiles();
app.UseExceptionHandler("/error");
app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.MapControllers();
app.Run();
