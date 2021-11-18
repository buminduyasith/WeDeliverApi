using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using wedeliver.Application.Behaviours;
using FluentValidation;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Services;

namespace wedeliver.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddScoped<IOrderStatusService, OrderStatusService>();

            return services;
        }
    }
}
