using AspektJob.DataAccess;
using AspektJob.DataAccess.Repositories;
using AspektJob.Domain;
using AspektJob.Domain.Models;
using AspektJob.Services.Implementations;
using AspektJob.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = "Server=DESKTOP-8J7TN63\\SQLEXPRESS;Database=AspektDb;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddControllers();
builder.Services.AddDbContext<AspektDbContext>(
        options => options.UseSqlServer(connectionString)
    ); ;
builder.Services.AddTransient<IRepository<Company>, CompanyRepository>();
builder.Services.AddTransient<IRepository<Country>, CountryRepository>();
builder.Services.AddTransient<IRepository<Contact>, ContactRepository>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IContactService, ContactService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
