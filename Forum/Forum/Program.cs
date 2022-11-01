using FluentValidation;
using FluentValidation.AspNetCore;
using Forum;
using Forum.Entities;
using Forum.Models;
using Forum.Models.Validators;
using Forum.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ForumDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("ForumDbConnection")));
builder.Services.AddScoped<ForumSeeder>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
SeedDatabase();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void SeedDatabase()
{
    var scope = app.Services.CreateScope();
    
    var dbInitializer = scope.ServiceProvider.GetRequiredService<ForumSeeder>();
    dbInitializer.Seed();
    
}