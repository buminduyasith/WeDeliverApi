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
using wedeliver.Application.Features.Foods.ViewModels;
using wedeliver.Domain;

namespace wedeliver.Application.Features.Foods.Commands.AddFoodItem
{
    public class AddFoodItemCommandHandler : IRequestHandler<AddFoodItemCommand, FoodVM>

    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddFoodItemCommandHandler> _logger;
        public AddFoodItemCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<AddFoodItemCommandHandler> logger)
        
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<FoodVM> Handle(AddFoodItemCommand request, CancellationToken cancellationToken)
        {
            var fooditem = _mapper.Map<Food>(request);
            var item =  await _orderRepository.AddAsync(fooditem);
            var response = _mapper.Map<FoodVM>(item);
            return response;
           

        }
    }
}
