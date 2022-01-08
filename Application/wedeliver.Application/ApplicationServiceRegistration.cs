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
using wedeliver.Application.Services.EmailSenderServices;
using wedeliver.Application.Services.PushNotification;
using wedeliver.Application.Services.Pdf;
using Wkhtmltopdf.NetCore;
using wedeliver.Application.Services.Pdf.FoodOrderInvoice;
using wedeliver.Application.Services.DocumentUplaod;
using wedeliver.Application.Services.FoodOrderServices;

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

            services.AddTransient<IPdfGenerateService, PdfGenerateService>();
            services.AddTransient<IHtmlToPdfConverter, HtmlToPdfConverter>();

            services.AddTransient<IFoodOrderInvoice, FoodOrderInvoice>();

            services.AddScoped<IDocumentStorageService, DocumentStorageService>();
            services.AddTransient<IFoodOrderService, FoodOrderService>();

            services.AddTransient<IGeneratePdf, GeneratePdf>();

            
            services.AddWkhtmltopdf();

            var emailConfig = configuration
           .GetSection("EmailConfiguration")
           .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            var firebaseStorageConfig = configuration
           .GetSection("FirebaseStorageConfig")
           .Get<FirebaseStorageConfiguration>();
            services.AddSingleton(firebaseStorageConfig);

            return services;
        }
    }
}
