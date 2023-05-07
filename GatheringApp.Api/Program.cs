
using GatheringApp.Persistence;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
 

GatheringApp.Application.DependencyInjection.AddApplication(builder.Services);
DependencyInjection.addPersistence(builder.Services);
GatheringApp.Presentation.DependencyInjection.addPresentation(builder.Services);
GatheringApp.InfraStructure.DependencyInjection.AddInfrastrucure(builder.Services); 
 

 

string connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<ApplicationDbContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(connectionString));

builder
    .Services
    .AddControllers()
    .AddApplicationPart(typeof(GatheringApp.Presentation.DependencyInjection).Assembly);

builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

