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
using wedeliver.Application.Services.Pdf.FoodOrderInvoice;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;
using wedeliver.Application.Features.FoodOrders.Commands.CreateFoodOrder;


namespace wedeliver.Application.Services.FoodOrderServices
{
    public class FoodOrderService : IFoodOrderService
    {
        private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IFoodOrderDetailsRepository _foodOrderDetailsRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFoodOrderCommandHandler> _logger;
        private readonly IApplicationDbContext _dbContext;
        

        public FoodOrderService(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<CreateFoodOrderCommandHandler> logger,
            IFoodOrderDetailsRepository foodOrderDetailsRepository,
            IApplicationDbContext dbContext)


        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;
            _dbContext = dbContext;
          

        }

        public async Task<FoodOrderVM> CreateFoodOrder(CreateFoodOrderCommand request)
        {
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

            var orderNo = "WD" + DateTime.Now.ToString("yyyyddMMhmm");
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
                OrderNo = orderNo,

            };

            var shippingDetailsModel = _mapper.Map<ShippingDetails>(request.ShippingDetails);


            var CreatedshippingDetailsModel = await _dbContext.ShippingDetails.AddAsync(shippingDetailsModel);


            foodOrder.ShippingDetails = CreatedshippingDetailsModel.Entity;

            var createdFoodOrder = await _foodOrderRepository.AddAsync(foodOrder);

            
            _logger.LogInformation("createdFoodOrder", createdFoodOrder.ToString());


            var returnFoodOrder = _mapper.Map<FoodOrderVM>(createdFoodOrder);

            var restaurant = await _foodOrderRepository.GetRestaurantDetails(request.RestaurantId);

            returnFoodOrder.RestaurantName = restaurant.Name;
            returnFoodOrder.TelphoneNumber = restaurant.TelphoneNumber;

            return returnFoodOrder;

        }

        public async Task<bool> SaveInvoiceDownloadableURL(string url,int id)
        {
            var foodOrder = await _dbContext.FoodOrder.FindAsync(id);

            foodOrder.InvoiceUrl = url;

            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}