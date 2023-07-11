using DemoAsp.ner.Data.Interfeces.Categories;
using DemoAsp.ner.Data.Repositories.Categories;
using DemoAsp.net.Service.Interfaces.Common;
using DemoAsp.net.Service.Interfaces.ICategories;
using DemoAsp.net.Service.Services.CategotyServise;
using DemoAsp.net.Service.Services.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();  
builder.Services.AddScoped<IFileServise, FileServise>();
builder.Services.AddScoped<ICategory, CategoryServise>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
