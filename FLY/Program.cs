using FLY.Business.Services.Implements;
using FLY.Business.Services;
using FLY.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using FLY.Business.Mapper;
using FLY.DataAccess.Repositories;
using FLY.DataAccess.Repositories.Implements;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program), typeof(MapperProfile));

builder.Services.AddDbContext<FlyContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Define policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireClaim(ClaimTypes.Role, "1"));
    options.AddPolicy("RequireSellerRole", policy => policy.RequireClaim(ClaimTypes.Role, "2"));
    options.AddPolicy("RequireCustomerRole", policy => policy.RequireClaim(ClaimTypes.Role, "3"));
    options.AddPolicy("RequireAdminOrSellerRole", policy => policy.RequireClaim(ClaimTypes.Role, "1", "2"));
    options.AddPolicy("RequireAdminOrCustomerRole", policy => policy.RequireClaim(ClaimTypes.Role, "1", "3"));
    options.AddPolicy("RequireSellerOrCustomerRole", policy => policy.RequireClaim(ClaimTypes.Role, "2", "3"));
    options.AddPolicy("RequireAllRoles", policy => policy.RequireClaim(ClaimTypes.Role, "1", "2", "3"));
});

// CORS
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//DI Service
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();
builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IProductService, ProductService>();

// Register in-memory caching
builder.Services.AddMemoryCache();

DotNetEnv.Env.Load();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
