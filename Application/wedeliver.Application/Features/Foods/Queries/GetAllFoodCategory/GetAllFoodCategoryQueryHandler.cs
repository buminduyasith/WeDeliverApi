using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Configurations;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Services.EmailSenderServices;
using wedeliver.Application.Services.Notification;
using wedeliver.Application.Templates.Renderer;
using wedeliver.Application.ViewModels;

namespace wedeliver.Application.Features.Foods.Queries.GetAllFoodCategory
{
    public class GetAllFoodCategoryQueryHandler : IRequestHandler<GetAllFoodCategoryQuery, IEnumerable<FoodCategoryVM>>
    {
      
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        private readonly EmailConfiguration _emailConfig;

        private readonly ILogger _logger;
        private readonly IEmailSenderService _emailSenderService;

        public GetAllFoodCategoryQueryHandler( IMapper mapper, EmailConfiguration emailConfig, ILogger<GetAllFoodCategoryQueryHandler> logger,
            IApplicationDbContext applicationDbContext, IEmailSenderService emailSenderService)
        {
            _mapper = mapper;
            _dbContext = applicationDbContext;
            _emailConfig = emailConfig;
            _logger = logger;
            _emailSenderService = emailSenderService;
        }

        public async Task<IEnumerable<FoodCategoryVM>> Handle(GetAllFoodCategoryQuery request, CancellationToken cancellationToken)
        {
          
            var foodCategoryList =  await _dbContext.FoodCategory.ToListAsync();
            
            var foodCategoryVMList = _mapper.Map<IEnumerable<FoodCategoryVM>>(foodCategoryList);

            //int p = _emailConfig.Port;

           // var templatePath = "../wedeliver.Application/Templates/WelcomeRestaurantUser.html";
           // var renderer = new RenderTemplate();
           // var content = await renderer.Render(templatePath, new string[] { "bumindu" });

           //var html = new NotificationMessage(new string[] { "buminduyasith@gmail.com"}, "OCP – Login Code", content);
             
           // await _emailSenderService.SendEmailAsync(html);

            return foodCategoryVMList;
          
        }
    }
}
