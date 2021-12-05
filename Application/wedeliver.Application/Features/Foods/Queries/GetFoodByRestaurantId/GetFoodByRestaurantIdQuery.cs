using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.ViewModels;

namespace wedeliver.Application.Features.Foods.Queries.GetFoodByRestaurantId
{
    public class GetFoodByRestaurantIdQuery:IRequest<List<FoodVM>>
    {
        public int Id { get; set; }
    }

    public class GetFoodByRestaurantIdQueryHandler : IRequestHandler<GetFoodByRestaurantIdQuery, List<FoodVM>>

    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetFoodByRestaurantIdQueryHandler(IFoodRepository foodRepository, IMapper mapper, IApplicationDbContext context)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<FoodVM>> Handle(GetFoodByRestaurantIdQuery request, CancellationToken cancellationToken)
        {
           
            //var foods = await _foodRepository.GetAllAsync();

            var foods = _context.Foods.Where(e => e.RestaurantId == request.Id);

            var fooditemsDTO = _mapper.Map<List<FoodVM>>(foods);
            return fooditemsDTO;
        }
    }
}
