using AutoMapper;
using ClothStore.Domain.Brand.BussinessLogic.FetchBrand;
using ClothStore.Models;
using ClothStore.Models.AutoMapping;
using ClothStore.Repository;
using ClothStore.Services.Brand.GetBrandService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.AllowAnyOrigin()
                          //.WithOrigins("http://localhost:3000") // Replace with your React app URL
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RetailDistributionContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
 );

// Registered repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAddOnlyRepository<>), typeof(Repository<>)); // Assuming you have an IAddOnlyRepository interface
builder.Services.AddScoped(typeof(IDeleteOnlyRepository<>), typeof(Repository<>)); // Assuming you have an IDeleteOnlyRepository interface
builder.Services.AddScoped(typeof(IReadOnlyRepository<>), typeof(Repository<>)); // Assuming you have an IReadOnlyRepository interface
builder.Services.AddScoped(typeof(IWriteOnlyRepository<>), typeof(Repository<>)); // Assuming you have an IWriteOnlyRepository interface
builder.Services.AddScoped(typeof(IUpdateOnlyRepository<>), typeof(Repository<>)); // Assuming you have an IUpdateOnlyRepository interface

// Register the mapping profile with AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly); // Register AutoMapper with the assembly containing your mappings

// Register Services layer here
builder.Services.AddScoped<IGetBrandService, GetBrandsService>(); // Assuming you have a service interface and implementation

// Register Domein layer here
builder.Services.AddScoped<IFetchBrandsDomain, FetchBrandsDomain>(); // Assuming you have a domain interface and implementation
// Use services for dependency injection 
var app = builder.Build();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RetailDistributionContext>();
    context.Database.EnsureCreated();  // This will create the database and tables if they don't exist
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin"); // Enable CORS for the specified policy
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.MapControllers();

app.Run();
