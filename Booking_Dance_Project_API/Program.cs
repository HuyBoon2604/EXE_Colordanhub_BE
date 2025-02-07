using Booking_Dance_Data.Context;
using Booking_Dance_Project_API;
using Booking_Dance_Project_API.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// PayOS Configuration (Optional based on your requirements)
var payosConfig = builder.Configuration.GetSection("PayOS");
var clientId = payosConfig.GetValue<string>("ClientId");
var apiKey = payosConfig.GetValue<string>("ApiKey");
var checksumKey = payosConfig.GetValue<string>("ChecksumKey");

// Log warning if PayOS credentials are missing
if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(checksumKey))
{
    builder.Logging.AddConsole(); // Log to console if needed
}

// Services configuration
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddEndpointsApiExplorer();

// Add SwaggerGen for API documentation
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Booking Dance API",
        Description = "API documentation for Booking Dance"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

// Configure DbContext with the connection string
builder.Services.AddDbContext<BookingDanceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add your services
builder.Services.AddServicesConfiguration();

// Add Firebase services
builder.Services.AddFirebaseServices();


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer();

// JWT configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>

    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
      
    });

// Authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("3"));
    options.AddPolicy("RequireStudioRole", policy => policy.RequireRole("2"));
    options.AddPolicy("RequireCustomerRole", policy => policy.RequireRole("1"));
});

// Add CORS policy
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("http://localhost:5173")
     .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials();
}));

// AutoMapper and Logging
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

// Build the app
var app = builder.Build();

// Configure Swagger UI
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking Dance API v1");
        /*options.RoutePrefix = string.Empty;*/ // Show Swagger UI at the root URL
    });

    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Middleware pipeline
app.UseHttpsRedirection();
app.UseCors("MyCors");
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

// Run the application
app.Run();
