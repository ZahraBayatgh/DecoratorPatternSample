using AdapterPatternSample.Interfaces;
using AdapterPatternSample.Services;
using DecoratorPatternSample.Decorators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMemoryCache(); // Add this line for .NET 2.1

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.Decorate<IEmployeeService, EmployeeServiceCachingDecorator>();
builder.Services.Decorate<IEmployeeService, EmployeeServiceLoggingDecorator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsProduction())
//{
//    builder.Services.Decorate<IEmployeeService, EmployeeServiceCachingDecorator>();
//}

//if (Convert.ToBoolean(builder.Configuration["EnableCaching"]))
//{
//    builder.Services.Decorate<IEmployeeService, EmployeeServiceCachingDecorator>();
//}

//if (Convert.ToBoolean(builder.Configuration["EnableLogging"]))
//{
//    builder.Services.Decorate<IEmployeeService, EmployeeServiceLoggingDecorator>();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
