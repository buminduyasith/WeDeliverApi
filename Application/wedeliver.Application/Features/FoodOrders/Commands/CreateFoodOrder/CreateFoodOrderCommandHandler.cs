using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using wedeliver.Application.Services.FoodOrderServices;
using wedeliver.Application.Services.Pdf.FoodOrderInvoice;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder
{
    public class CreateFoodOrderCommandHandler : IRequestHandler<CreateFoodOrderCommand, FoodOrderVM>
    {
        
        private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IFoodOrderDetailsRepository _foodOrderDetailsRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFoodOrderCommandHandler> _logger;
        private readonly IApplicationDbContext _dbContext;
        private readonly IFoodOrderInvoice _foodOrderInvoice;
       private readonly IFoodOrderService _foodOrderService;

        public CreateFoodOrderCommandHandler(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<CreateFoodOrderCommandHandler> logger,
            IFoodOrderDetailsRepository foodOrderDetailsRepository,
            IFoodOrderService foodOrderService,
            IApplicationDbContext dbContext,
            IFoodOrderInvoice foodOrderInvoice
            )
      

        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;
            _dbContext = dbContext;
            _foodOrderInvoice = foodOrderInvoice;
            _foodOrderService = foodOrderService;

        }
        
        
        public async Task<FoodOrderVM> Handle(CreateFoodOrderCommand request, CancellationToken cancellationToken)
        {
           

             var returnFoodOrder =await _foodOrderService.CreateFoodOrder(request);

          
            await _foodOrderInvoice.process(returnFoodOrder.Id);

      
            return await Task.FromResult<FoodOrderVM>(new FoodOrderVM());
        }
    }
}
