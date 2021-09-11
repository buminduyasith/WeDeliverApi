
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Features.Foods.ViewModels;

namespace wedeliver.Application.Features.Foods.Queries.GetFoodById
{
    class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, FoodVM>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public GetFoodByIdQueryHandler(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<FoodVM> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        {
            
            var food = await _foodRepository.GetByIdAsync(request.Id);
            var fooditemDTO = _mapper.Map<FoodVM>(food);
            return fooditemDTO;
        }
    }
}
