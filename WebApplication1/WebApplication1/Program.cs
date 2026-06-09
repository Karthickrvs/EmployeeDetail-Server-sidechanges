using WebApplication1.EmployeeDetailesFunctionalService;
using WebApplication1.EmployeeDetailsRepository;
using WebApplication1.FunctionalService;
using WebApplication1.ObjectModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

IServiceCollection serviceCollection = builder.Services.AddDbContext<EmployeeDetails>(Options => Options.usesqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));

builder.Services.AddScoped<IEmployeeDetailsRepo, EmployeeDetailsRepo>();

builder.Services.AddScoped<IEmployeeDetailsFunctionalService, EmployeeDetailsFunctionalService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
