using RemoteMultiSiteMobileBasedExpenseManager.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RemoteMultiSiteMobileBasedExpenseManager.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConRemoteMultiSiteExpenseManager");

builder.Services.AddControllers();
builder.Services.AddDbContext<DbContextEntities>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddCors(x => {
    x.AddPolicy("ExpenseCors", p =>
    {
        p.WithOrigins("https://localhost:7103")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });   
});
builder.Services.AddCors(cors => {
    cors.AddDefaultPolicy(p => {
        p.WithOrigins("https://localhost:7103")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
    
});
builder.Services.AddScoped<IProjectsRepository, ProjectsDbRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddAuthorization(options => {
//    options.AddPolicy("Umar", o => o.RequireRole("Admin"));
//});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
