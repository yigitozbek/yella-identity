using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using Yella.Identity.Service;
using Yella.Identity.Service.Extensions;
using Yella.WebAPI.Context;
using Yella.WebAPI.Entities;
using Yella.WebAPI.Routing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new CamelCaseParameterTransformer()));
}).AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddIdentityService<User, Role>(builder.Configuration);

builder.Services.AddIdentityApplicationService<User, Role>();

builder.Services.AddIdentityService<User, Role>(builder);

builder.Host.AddIdentityApplicationHost<YellaDbContext, User, Role>();

var connectionString = builder.Configuration["ConnectionStrings:SqlServer"];

builder.Services.AddDbContext<YellaDbContext>(b => b.UseSqlServer(connectionString));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseIdentityApplication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
