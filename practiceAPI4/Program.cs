global using Microsoft.EntityFrameworkCore;
global using practiceAPI4.Data;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigin = "_myAllowSpecificOrigin";

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigin,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
