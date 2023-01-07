using Application.Services.DataTransferObjects;
using Application.Services.DataTransferObjects.Creating;
using Application.Services.DataTransferObjects.Updating;
using Application.Services.Helpers;
using Application.Services.Services;
using AutoMapper;
using Domain.Core.Models;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Services.Helpers;
using Infrastructure.Services.Services;
using Infrastructure.Services.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using WebApi.Filters;

namespace WebApi
{
    public static class ServiceExtentions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("Infrastructure.Data")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceHelpers(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IDateTimeConverter, DateTimeConverter>();
            services.AddScoped<IPetStatsCalculatingService, PetStatsCalculatingService>();
            services.AddScoped<IFarmStatsCalculatingService, FarmStatsCalculatingService>();
            services.AddScoped<IFeedingFarmStatsService, FeedingFarmStatsService>();
            services.AddScoped<IThirstQuenchingFarmStatsService, ThirstQuenchingFarmStatsService>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IPicturesService, PicturesService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokensGeneratorService, JwtTokensGeneratorService>();
            services.AddScoped<IPetsService, PetsService>();
            services.AddScoped<IFarmsService, FarmsService>();
            services.AddScoped<IFarmFriendsService, FarmFriendsService>();
            services.AddScoped<IFeedingEventsService, FeedingEventsService>();
            services.AddScoped<IThirstQuenchingEventsService, ThirstQuenchingEventsService>();
            services.AddScoped<IBodyPartsService, BodyPartsService>();
            services.AddScoped<IUsersService, UsersService>();
        }

        public static void ConfigureFluentValidator(this IServiceCollection services)
        {
            services.AddScoped<IValidator<FarmCreatingDto>, FarmCreatingDtoValidator>();
            services.AddScoped<IValidator<FarmUpdatingDto>, FarmUpdatingDtoValidator>();
            services.AddScoped<IValidator<PetCreatingDto>, PetCreatingDtoValidator>();
            services.AddScoped<IValidator<PetUpdatingDto>, PetUpdatingDtoValidator>();
            services.AddScoped<IValidator<UserAuthenticationDto>, UserAuthenticationDtoValidator>();
            services.AddScoped<IValidator<UserCreatingDto>, UserCreatingDtoValidator>();
            services.AddScoped<IValidator<UserUpdatingDto>, UserUpdatingDtoValidator>();
            services.AddScoped<IValidator<PasswordChangingDto>, PasswordChangingDtoValidator>();

            services.AddScoped<IValidationHelper<FarmCreatingDto>, ValidationHelper<FarmCreatingDto>>();
            services.AddScoped<IValidationHelper<FarmUpdatingDto>, ValidationHelper<FarmUpdatingDto>>();
            services.AddScoped<IValidationHelper<PetCreatingDto>, ValidationHelper<PetCreatingDto>>();
            services.AddScoped<IValidationHelper<PetUpdatingDto>, ValidationHelper<PetUpdatingDto>>();
            services.AddScoped<IValidationHelper<UserAuthenticationDto>, ValidationHelper<UserAuthenticationDto>>();
            services.AddScoped<IValidationHelper<UserCreatingDto>, ValidationHelper<UserCreatingDto>>();
            services.AddScoped<IValidationHelper<UserUpdatingDto>, ValidationHelper<UserUpdatingDto>>();
            services.AddScoped<IValidationHelper<PasswordChangingDto>, ValidationHelper<PasswordChangingDto>>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile(provider.GetService<IPetStatsCalculatingService>(), provider.GetService<IFarmStatsCalculatingService>(), provider.GetService<IDateTimeConverter>(), provider.GetService<IDateTimeProvider>()));
            }).CreateMapper());
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = false;
            })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<RepositoryContext>();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<ExtractUserIdFilter>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }

    }
}
