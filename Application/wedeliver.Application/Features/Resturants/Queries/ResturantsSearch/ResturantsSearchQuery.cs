using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Application.Extensions;
using wedeliver.Application.ViewModels;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Features.Resturants.Queries.ResturantsSearch
{
    public class ResturantsSearchQuery:IRequest<ResturantListVM>
    {
        public string Name { get; set; }
        public Districts City { get; set; }
        public FoodStoreCategory FoodCategory { get; set; }
        public double Rating { get; set; }
        public PaginationOption Pagination { get; set; }
        public SearchOperator SearchOperator { get; set; }
    }

    public class ResturantsSearchQueryHandler : IRequestHandler<ResturantsSearchQuery, ResturantListVM>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        private readonly ILogger<ResturantsSearchQueryHandler> _logger;

        public ResturantsSearchQueryHandler(IMapper mapper, ILogger<ResturantsSearchQueryHandler> logger,
            IApplicationDbContext context, IOrderStatusService orderStatusService)

        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;

        }
        public async Task<ResturantListVM> Handle(ResturantsSearchQuery request, CancellationToken cancellationToken)
        {

            var activeResturantsQuery = GetResturants(request);

            var paginationData = await activeResturantsQuery.PaginateAsync(request?.Pagination?.Page, request?.Pagination?.PageSize);


            //var viewModels = paginationData.Results.Select(x =>
            //x.GetWorkItemVMAsync(_mapper, _identityService, _context, _identityUserService).Result).ToList();

            var viewModels = paginationData.Results.Select(x => x.GetResturantVMAsync(_mapper, _context).Result).ToList();

            return new ResturantListVM
            {
                Page = paginationData.Page,
                NumberOfPages = paginationData.NumberOfPages,
                TotalItems = paginationData.TotalItems,
                PageSize = paginationData.PageSize,
                DisplayCount = paginationData.DisplayCount,
                DisplayStart = paginationData.DisplayStart,
                DisplayEnd = paginationData.DisplayEnd,
                Lists = viewModels
            };

            
        }

        public IQueryable<Restaurant> GetResturants(ResturantsSearchQuery request)
        {
            //get only active res
            Expression<Func<Restaurant, bool>> activePredicate = o => o.Active == true;

            var query = _context.Restaurants
                .Include(x => x.Location)
                .Include(x => x.RestaurantRating);
               // .Where(activePredicate);

            //if(request.SearchOperator == SearchOperator.Search)
            //{
            //    request.Name = request.Name.ToLower();
            //    query = query.Where(e => e.Name.ToLower().StartsWith(request.Name));
                             
            //}

            //else if (request.SearchOperator == SearchOperator.Contains)
            //{
            //    request.Name = request.Name.ToLower();
            //    query = query.Where(e => e.Name.ToLower().StartsWith(request.Name));
            //}

            //else if(request.SearchOperator == SearchOperator.Filter)
            //{
            //    query = query.Where(e => e.Location.CityID == request.City);
            //}


            //testing query
            query.OrderByDescending(x => x.Id);
            return query;

               
        }
    }
}
