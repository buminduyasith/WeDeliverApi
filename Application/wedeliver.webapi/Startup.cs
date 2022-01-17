using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wedeliver.Application;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Infrastructure;
using wedeliver.webapi.Middlewares;
using wedeliver.webapi.Services;

namespace wedeliver.webapi
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices(Configuration);
            services.AddInfrastructureServices(Configuration);



            services.AddAuthentication("jwtauth")
                .AddJwtBearer("jwtauth",options => {
                    var keyBytes = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JwtKeyConfig:Secret"));

                    var key = new SymmetricSecurityKey(keyBytes);

                    string audience = Configuration.GetValue<string>("JwtKeyConfig:Audience");
                    string issuer = Configuration.GetValue<string>("JwtKeyConfig:Issuer");

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = issuer,
                       // ValidateIssuer = false,
                       // ValidateAudience = false,
                        ValidAudience = audience,
                        IssuerSigningKey = key
                    };
                });

            services.AddControllers();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo 
            //    { 
            //        Title = "wedeliver.webapi",
            //        Version = "v1" ,
            //       Description= "Application for deliver foods and medicine",
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Bumindu yasith",
            //            Email = string.Empty,
            //            Url = new Uri("https://twitter.com/spboyer"),
            //        },

            //    });


            //});

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "webapi_identity", Version = "v1" });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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



            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });


            services.AddScoped<ICurrentUserService, CurrentUserService>();
            //services.AddControllers().AddJsonOptions(x =>
            //                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add<ApiExceptionFilter>();
            //});

            //services.AddTransient<ErrorHandlerMiddleware>();

            // var assembly = AppDomain.CurrentDomain.Load("wedeliver.Application");
            //services.AddMediatR(assembly);

            //   services.RegisterApplicationServices(Configuration);
            //  services.RegisterInfrastructerServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "wedeliver.webapi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
