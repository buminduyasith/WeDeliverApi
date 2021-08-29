using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Domain;

namespace wedeliver.Application.Features.Foods.Queries.GetFoodList
{
    class GetFoodListQueryHandler : IRequestHandler<GetFoodListQuery, List<FoodVM>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetFoodListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<FoodVM>> Handle(GetFoodListQuery request, CancellationToken cancellationToken)
        {
            //var fooditem =  await _orderRepository.GetFoodById(request.Id);
            //var fooditemdto = _mapper.Map<List<FoodVM>>(fooditem);
            //var foods = new List<Food>() {
            //    new Food(){Name="test1",Discription="test dis",Price=260.45},
            //      new Food(){Name="test2",Discription="test dis 2",Price=270.45},

            //};
            var foods = await _orderRepository.GetAllAsync();
            var fooditemsDTO = _mapper.Map<List<FoodVM>>(foods);
            return fooditemsDTO;
        }
    }
}
