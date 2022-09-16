using Checkout.Api.Validators;
using Checkout.Application.Query;
using Checkout.Commands;
using Checkout.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddValidatorsFromAssemblyContaining<BasketRequestValidator>();


builder.Services.AddTransient<IBasketRepository, BasketRepository>();
builder.Services.AddTransient<IBasketApplication, BasketApplication>();
builder.Services.AddTransient<ICreateBasketCommand, CreateBasketCommand>();
builder.Services.AddTransient<IAddArticleCommand, AddArticleCommand>();
builder.Services.AddTransient<ICloseBasketCommand, CloseBasketCommand>();

builder.Services.AddDbContext<BasketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
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
