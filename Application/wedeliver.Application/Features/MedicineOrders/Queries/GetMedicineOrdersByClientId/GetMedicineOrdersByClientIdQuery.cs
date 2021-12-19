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
using wedeliver.Application.ViewModels;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Features.MedicineOrders.Queries.GetMedicineOrdersByClientId
{
    public class GetMedicineOrdersByClientIdQuery:IRequest<IEnumerable<MedicineOrderVM>>
    {
        public int Id { get; set; }
    }

    public class GetMedicineOrdersByClientIdQueryHandler : IRequestHandler<GetMedicineOrdersByClientIdQuery, IEnumerable<MedicineOrderVM>>
    {
        private IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMedicineOrdersByClientIdQueryHandler> _logger;

        public GetMedicineOrdersByClientIdQueryHandler(
           IMapper mapper, ILogger<GetMedicineOrdersByClientIdQueryHandler> logger,
           IApplicationDbContext context)

        {

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbContext = context;
        }
        public async Task<IEnumerable<MedicineOrderVM>> Handle(GetMedicineOrdersByClientIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<MedicineOrder, bool>> predicate = o => o.ClientID == request.Id;
            var orders = await GetMedicineOrder(predicate);
            var orderDTO = _mapper.Map<IEnumerable<MedicineOrderVM>>(orders);
            return orderDTO;

        }

        public async Task<IEnumerable<MedicineOrder>> GetMedicineOrder(Expression<Func<MedicineOrder, bool>> predicate)
        {
            var query = _dbContext.MedicineOrders.Where(predicate);

            await query.Include(x => x.Pharmacy).LoadAsync();
            await query.Include(x=>x.Rider).LoadAsync();
            await query.Include(x => x.ShippingDetails).LoadAsync();
           
            return await query.ToListAsync();
        }
    }
}
