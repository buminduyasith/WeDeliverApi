
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.ViewModels;

namespace wedeliver.Application.Features.Foods.Queries.GetFoodById
{
    public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, FoodVM>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;

        public GetFoodByIdQueryHandler(IFoodRepository foodRepository, IMapper mapper,
            IApplicationDbContext applicationDbContext)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<FoodVM> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        {
            //_dbContext.Restaurants.Where(res => res.Id == id).FirstOrDefaultAsync();
            var food = await _applicationDbContext.Foods.Where(res => res.Id == request.Id).FirstOrDefaultAsync();  //await _foodRepository.GetByIdAsync(request.Id);
            var fooditemDTO = _mapper.Map<FoodVM>(food);
            return fooditemDTO;
        }
    }
}
