using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using UploadImage.Data.Context;
using UploadImage.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("EcommerceDb");
builder.Services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductRepo, ProductRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Assets")),
    RequestPath = new PathString("/Assets")
});
app.UseAuthorization();

app.MapControllers();

app.Run();
