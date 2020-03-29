using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using currencyApi.BusinessLogic;
using currencyApi.BusinessLogic.Services;
using currencyApi.Data;
using currencyApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace currency_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            //   Get Settings from appsettings.json
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();


            
            //   DB Context Configuration
            bool useInMemoryDB = !String.IsNullOrWhiteSpace(appSettings.UseInMemoryDatabase)
                                && (appSettings.UseInMemoryDatabase.ToLower() == "yes" || appSettings.UseInMemoryDatabase.ToLower() == "true");
            
            if (useInMemoryDB)
            {
                //Use in memoryDb provider
                services.AddDbContext<CurrenciesContext>(opt =>
                   opt.UseInMemoryDatabase("CurrencyDB")
                   );
            }
            else
            {
                //Use Sql Server provider
                services.AddDbContext<CurrenciesContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );

            }

            //Add http context accessor to access the userdata that does the http request
            services.AddHttpContextAccessor();
            //   jwt authentication configuration
            services
                .AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                )
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            
            //  Dependecy injection configuration
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
            services.AddScoped<ICurrencyRatesRepository, CurrencyRatesRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ICurrencyRateService, CurrencyRateService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorisationService, AuthorisationService>();
            services.AddAutoMapper(typeof(Startup));
            
            //  Dependecy injection configuration
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //  Swagger(OPEN API) configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Currencies Demo API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Enter: \"Bearer _token_value_returned_from_auth/login_uri\""
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                                            new string[] {}

                                    }
                                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Currencies Demo API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Allow Cors, this should be stricter for a non-demo app
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
