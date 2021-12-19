using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using wedeliver.Application.Behaviours;
using FluentValidation;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Services;
using wedeliver.Application.Configurations;
using Microsoft.Extensions.Configuration;
using wedeliver.Application.Services.EmailSenderService;
using wedeliver.Application.Services.PushNotification;

namespace wedeliver.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddScoped<IOrderStatusService, OrderStatusService>();

            services.AddTransient<IEmailSenderService, EmailSenderService>();

            services.AddScoped<IPushNotification, PushNotification>();

            services.AddScoped<IMedicineOrderStatusService, MedicineOrderStatusService>();

            

            var emailConfig = configuration
           .GetSection("EmailConfiguration")
           .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            return services;
        }
    }
}
