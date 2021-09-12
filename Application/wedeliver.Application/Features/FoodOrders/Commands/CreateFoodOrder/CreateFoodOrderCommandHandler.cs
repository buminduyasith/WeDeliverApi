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

        public CreateFoodOrderCommandHandler(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<CreateFoodOrderCommandHandler> logger,
            IFoodOrderDetailsRepository foodOrderDetailsRepository)
      

        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;

        }

        
        public async Task<FoodOrderVM> Handle(CreateFoodOrderCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            var FoodOrderRequestDtoList = request.ItemList;
            var totalPrice = 0.00;
            var foodOrderDetailList = new List<FoodOrderDetails>();
            var totalQty = 0;

            foreach (var item in FoodOrderRequestDtoList)
            {
                var foodItem = await _foodRepository.GetByIdAsync(item.FoodId);
                if (foodItem is null) throw new KeyNotFoundException("item not found");
                totalPrice += foodItem.Price * item.Qty;
                totalQty += item.Qty;
                var foodOrderDetail = new FoodOrderDetails { FoodId = foodItem.Id, Price = foodItem.Price, Qty = item.Qty };
                var createdFoodOrderDetail = await _foodOrderDetailsRepository.AddAsync(foodOrderDetail);
                foodOrderDetailList.Add(createdFoodOrderDetail);
            }


            //check client is exist


            var foodOrder = new FoodOrder
            {
                ClientID = request.ClientID,
                FoodOrderStatus = FoodOrderStatus.Pending,
                ItemList = foodOrderDetailList,
                Qty = totalQty,
                Note = request.Note,
                OrderType = request.OrderType,
                RestaurantId = request.RestaurantId,
                Total = totalPrice,
                OrderNo = Guid.NewGuid().ToString(),

            };

            var createdFoodOrder =  await _foodOrderRepository.AddAsync(foodOrder);



            var returnFoodOrder  = _mapper.Map<FoodOrderVM>(createdFoodOrder);


         
            return returnFoodOrder;
        }
    }
}
