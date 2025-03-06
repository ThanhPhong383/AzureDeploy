using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SPSS.Data;
using SPSS.Entities;
using SPSS.Services.AuthService;
using SPSS.Services;
using System.Text;
using Microsoft.Extensions.Options;
using SPSS.Dto.Account;
using System.Collections.Concurrent;
using SPSS.Services.FirebaseStorageService;
using SPSS.Mapper;
using SPSS.Services.ProductService;
using SPSS.Repositories.GenericRepository;
using System;

namespace SPSS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var googleClientId = builder.Configuration["Google:ClientId"];
            var googleClientSecret = builder.Configuration["Google:ClientSecret"];

            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer(); //swagger

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SPSSDatabase")));

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
             .AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();
            if (string.IsNullOrEmpty(googleClientId) || string.IsNullOrEmpty(googleClientSecret))
            {
                throw new InvalidOperationException("Missing Google OAuth configuration in appsettings.json.");
            }


            var secretKey = builder.Configuration["AppSettings:Token"];
            if (string.IsNullOrEmpty(secretKey))
                throw new InvalidOperationException("JWT Secret Key is missing in appsettings.json.");

            var key = Encoding.UTF8.GetBytes(secretKey);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["AppSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true, // Thêm vào đây
                    ClockSkew = TimeSpan.FromMinutes(1)  // Loại bỏ thời gian trễ mặc định (5 phút)
                };
            })
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Google:ClientId"];
                options.ClientSecret = builder.Configuration["Google:ClientSecret"];
            });

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SPSS API",
                    Version = "v1"
                });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and your token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { "" }
        }
    });
            });


            builder.Services.AddAuthorization();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddScoped<IFirebaseStorageService, FirebaseStorageService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddScoped<IProductService, ProductService>();
          


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            // Cấu hình Email Service
            var emailConfigSection = builder.Configuration.GetSection("EmailConfiguration");
            if (!emailConfigSection.Exists())
            {
                throw new InvalidOperationException("Email Configuration section is missing in appsettings.json.");
            }

            var emailConfig = emailConfigSection.Get<EmailConfiguration>();
            if (emailConfig == null)
            {
                throw new InvalidOperationException("Email Configuration is null or improperly formatted.");
            }
            //Console.WriteLine($"Email Config: {emailConfig?.From}"); // Debug xem giá trị có đúng không
            if (emailConfig != null)
            {
                Console.WriteLine($"Email Config: {emailConfig.From}");
            }
            else
            {
                Console.WriteLine("Email Configuration is NULL!");
            }

            builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddSingleton(new ConcurrentDictionary<string, OtpEntry>());
            builder.Services.AddTransient<IEmailService, EmailService>();
            var connectionString = builder.Configuration.GetConnectionString("SPSSDatabase");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string is missing or empty in appsettings.json.");
            }
            Console.WriteLine($"Database Connection String: {connectionString}");
            Console.WriteLine($"[INFO] Database Connection String Loaded: {connectionString}");

            if (emailConfig == null)
            {
                throw new InvalidOperationException("Email configuration is null.");
            }
            builder.Services.AddSingleton(emailConfig);


            var app = builder.Build();

            if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
