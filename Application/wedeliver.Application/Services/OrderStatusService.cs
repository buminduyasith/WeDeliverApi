using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Exceptions;
using wedeliver.Application.Features.FoodOrders.Commands.RiderAcceptOrder;
using wedeliver.Application.Features.FoodOrders.Commands.UpdateFoodOrderStatus;
using wedeliver.Application.Features.FoodOrders.ViewModels;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IFoodOrderRepository _foodOrderRepository;
        private readonly IApplicationDbContext _context;
        private readonly IFoodOrderDetailsRepository _foodOrderDetailsRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderStatusService> _logger;
      

        public OrderStatusService(IFoodOrderRepository foodOrderRepository,
            IFoodRepository foodRepository,
            IMapper mapper, ILogger<OrderStatusService> logger,
             IApplicationDbContext applicationDbContext,
        IFoodOrderDetailsRepository foodOrderDetailsRepository)

        {
            _foodOrderRepository = foodOrderRepository ?? throw new ArgumentNullException(nameof(foodOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _foodRepository = foodRepository;
            _foodOrderDetailsRepository = foodOrderDetailsRepository;
            _context = applicationDbContext;
           

        }
        public async Task<Unit> updateOrderStatusFromRestaurant(UpdateFoodOrderStatusCommand request)
        {
            Expression<Func<FoodOrder, bool>> predicate = o => o.Id == request.OrderId && o.RestaurantId == request.RestaurantId;

            var FoodOrderResult = await GetOrder(predicate);

            if (FoodOrderResult is null)
            {
                throw new NotFoundException("order not found", FoodOrderResult);
            }

            _logger.LogInformation("UpdateFoodOrderStatusCommand", FoodOrderResult.ToString());

            FoodOrderResult.FoodOrderStatus = request.Status;

            _context.FoodOrder.Update(FoodOrderResult);

            await _context.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }

        public async Task<Unit> updateOrderStatusFromRider(UpdateFoodOrderStatusCommand request)
        {
            Expression<Func<FoodOrder, bool>> predicate = o => o.Id == request.OrderId && o.RiderId == request.RiderId;

            var FoodOrderResult = await GetOrder(predicate);

            if (FoodOrderResult is null)
            {
                throw new NotFoundException("order not found", FoodOrderResult);
            }

            _logger.LogInformation("UpdateFoodOrderStatusCommand", FoodOrderResult.ToString());

            FoodOrderResult.FoodOrderStatus = request.Status;

            _context.FoodOrder.Update(FoodOrderResult);

            await _context.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }


        public async Task<FoodOrder> GetOrder(Expression<Func<FoodOrder, bool>> predicate)
        {
            var query = _context.FoodOrder.Where(predicate);

            await query.Include(x => x.Restaurant)
                        .LoadAsync();
            await query.Include(x => x.Client)
                        .LoadAsync();

            await query.Include(x => x.ItemList)
                       .LoadAsync();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FoodOrderVM>> GetAllAvailableOrdersForRider()
        {
            Expression<Func<FoodOrder, bool>> predicate = o => o.FoodOrderStatus == Domain.Enums.FoodOrderStatus.ReadyToPickedUpForRider;
          

            var query = _context.FoodOrder.Where(predicate);

            await query.Include(x => x.Client)
              .ThenInclude(x => x.Location)
              .LoadAsync();
            await query.Include(x => x.Restaurant).LoadAsync();
            await query.Include(x => x.ItemList)
                .ThenInclude(x => x.Food)
                .LoadAsync();

            var result =  await query.ToListAsync();

            var foodOrderDTO = _mapper.Map<IEnumerable<FoodOrderVM>>(result);
            return foodOrderDTO;

            //return await query.ToListAsync();
        }

        public async Task<Boolean> RiderOrderAcceptToDeliver(RiderAcceptOrderCommand riderAcceptOrderCommand)
        {
            Expression<Func<FoodOrder, bool>> predicate = o => o.Id == riderAcceptOrderCommand.OrderId;

            var query = _context.FoodOrder.Where(predicate);

            await query.Include(x => x.Client)
              .ThenInclude(x => x.Location)
              .LoadAsync();
            await query.Include(x => x.Restaurant).LoadAsync();
            await query.Include(x => x.ItemList)
                .ThenInclude(x => x.Food)
                .LoadAsync();

            var foodOrder = await query.FirstOrDefaultAsync();

            if(foodOrder.RiderId == null)
            {
                foodOrder.RiderId = riderAcceptOrderCommand.RiderId;
                _context.FoodOrder.Update(foodOrder);
                await _context.SaveChangesAsync();
                return true;
              
            }
            else
            {
                throw new Exception("This Order Already accepted by another Rider");
            }

          

        }
    }
}
