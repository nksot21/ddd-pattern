using DDDParttern.API.IServices;
using DDDParttern.API.Services;
using DDDParttern.Infrastructure;
using DDDParttern.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middlewares
app.UseMiddleware<ResponseHandleMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
