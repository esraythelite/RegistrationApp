using DomainLayer.Entities;
using MediatR;
using RepositoryLayer.AbstractRepositories;
using RepositoryLayer.ConcreteRepositories;
using ServiceLayer.AbstractServices;
using ServiceLayer.ConcreteServices;
using Microsoft.Extensions.DependencyInjection;
using DomainLayer.RegistrationContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString: "Server = DESKTOP-TMFM5HV; Database = RegistrationDb; User Id = sa; Password = 123"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddMediatR(typeof(UserRepository));

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
