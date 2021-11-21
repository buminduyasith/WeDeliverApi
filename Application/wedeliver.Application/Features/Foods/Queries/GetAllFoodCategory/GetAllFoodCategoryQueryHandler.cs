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

namespace wedeliver.Application.Features.Foods.Queries.GetAllFoodCategory
{
    public class GetAllFoodCategoryQueryHandler : IRequestHandler<GetAllFoodCategoryQuery, IEnumerable<FoodCategoryVM>>
    {
      
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;

        public GetAllFoodCategoryQueryHandler( IMapper mapper,
            IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _dbContext = applicationDbContext;
        }

        public async Task<IEnumerable<FoodCategoryVM>> Handle(GetAllFoodCategoryQuery request, CancellationToken cancellationToken)
        {
          
            var foodCategoryList =  await _dbContext.FoodCategory.ToListAsync();
            var foodCategoryVMList = _mapper.Map<IEnumerable<FoodCategoryVM>>(foodCategoryList);
            return foodCategoryVMList;
          
        }
    }
}
