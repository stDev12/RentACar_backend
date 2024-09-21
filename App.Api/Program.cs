using App.Api.Models;
using App.Api.Profiles;
using App.BL.Interfaces;
using App.BL.Profiles;
using App.BL.Services;
using App.DAL.DataContext;
using App.DAL.Interfaces;
using App.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

byte[] key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id= "Bearer"
            }
        },
        new string[]{}
    }
    });
});

builder.Services.AddScoped<IUsersManagement, UsersManagement>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IAuthManagement, AuthManagement>();
builder.Services.AddScoped<ICarsManagement, CarsManagement>();
builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<IExtrasManagement, ExtrasManagement>();
builder.Services.AddScoped<IExtrasRepository, ExtrasRepository>();
builder.Services.AddScoped<ICartManagement, CartManagement>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrdersManagement, OrdersManagement>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

builder.Services.AddDbContext<CarRentalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
});

builder.Services.AddAutoMapper(typeof(UserProfile).Assembly, typeof(UserRequestProfile).Assembly, typeof(UserUpdateRequest).Assembly);
builder.Services.AddAutoMapper(typeof(CarProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ExtraProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CartProfile).Assembly, typeof(CartRequestProfile).Assembly);
builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly, typeof(OrderRequestProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RentalProfile).Assembly, typeof(RentalRequestProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
