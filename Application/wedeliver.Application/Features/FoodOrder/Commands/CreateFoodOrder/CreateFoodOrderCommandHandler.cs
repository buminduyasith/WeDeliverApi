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
using wedeliver.Application.Features.FoodOrder.ViewModels;

namespace wedeliver.Application.Features.FoodOrder.Commands.CreateFoodOrder
{
    public class CreateFoodOrderCommandHandler : IRequestHandler<CreateFoodOrderCommand, FoodOrderVM>
    {
       
       private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFoodOrderCommandHandler> _logger;
        public CreateFoodOrderCommandHandler(IFoodOrderRepository foodOrderRepository, IMapper mapper, ILogger<CreateFoodOrderCommandHandler> logger)

        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        
        public async Task<FoodOrderVM> Handle(CreateFoodOrderCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();



            var fooditem = _mapper.Map<wedeliver.Domain.Entities.FoodOrder>(request);
            var item = await _foodOrderRepository.AddAsync(fooditem);
            var response = _mapper.Map<FoodOrderVM>(item);
            return response;
        }
    }
}
