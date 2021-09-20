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

namespace wedeliver.Application.Features.FoodOrders.Queries.GetFoodOrderById
{
    public class GetFoodOrderByIdQueryHandler : IRequestHandler<GetFoodOrderByIdQuery, FoodOrderVM>
    {
        private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IFoodOrderDetailsRepository _foodOrderDetailsRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetFoodOrderByIdQueryHandler> _logger;

        public GetFoodOrderByIdQueryHandler(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<GetFoodOrderByIdQueryHandler> logger,
            IFoodOrderDetailsRepository foodOrderDetailsRepository)


        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;

        }

        public async Task<FoodOrderVM> Handle(GetFoodOrderByIdQuery request, CancellationToken cancellationToken)
        {

            var order = await _foodOrderRepository.GetByIdAsync(request.Id);
            var fooditemDTO = _mapper.Map<FoodOrderVM>(order);
            return fooditemDTO;
        }
    }
}
