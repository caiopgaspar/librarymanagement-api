using LibraryManagement.API;
using LibraryManagement.Application.Commands.RegisterNewBook;
using LibraryManagement.Core.Repositories;
using LibraryManagement.Infrastructure.Persistence;
using LibraryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the dependency injection container
builder.Services.AddControllers();

// Configure the database based on the environment (development or production)
if (builder.Environment.IsDevelopment())
{
    // Use in-memory database for development environment
    builder.Services.AddDbContext<BooksDbContext>(options =>
        options.UseInMemoryDatabase("BooksDb"));
}
else
{
    // Use SQL Server for production environment
    var connectionString = builder.Configuration.GetConnectionString("LibraryManagementCs");
    builder.Services.AddDbContext<BooksDbContext>(options =>
        options.UseSqlServer(connectionString));
}

builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<RegisterNewBookCommand>());


// Configure Swagger/OpenAPI for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryManagement API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Use developer exception page and Swagger in development environment
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseAuthorization(); // Configure authorization
app.MapControllers(); // Map controller endpoints

app.Run(); // Run the application