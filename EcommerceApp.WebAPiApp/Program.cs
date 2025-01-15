using ECommerceApp.ApplicationCore.Contracts.Repository;
using ECommerceApp.ApplicationCore.Contracts.Service;
using ECommerceApp.ApplicationCore.Helper.Mapping;
using ECommerceApp.Infrastructure.Data;
using ECommerceApp.Infrastructure.Repository;
using ECommerceApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcommerceAppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceNov2024Db"));

});

//services dependencies
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();


// repositories dependencies 
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();


builder.Services.AddAutoMapper(typeof(ApplicationMapper));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
