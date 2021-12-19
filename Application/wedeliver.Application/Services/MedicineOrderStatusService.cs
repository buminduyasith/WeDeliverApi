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
using wedeliver.Application.Features.MedicineOrders.Commands.UpdateMedicineOrderStatus;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.Services
{
    public class MedicineOrderStatusService : IMedicineOrderStatusService
    {
      
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<MedicineOrderStatusService> _logger;


        public MedicineOrderStatusService( IMapper mapper, ILogger<MedicineOrderStatusService> logger,IApplicationDbContext applicationDbContext)
        {
            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = applicationDbContext;

        }
        public async Task<Unit> updateOrderStatusFromClient(UpdateMedicineOrderStatusCommand request)
        {
            var order = await _context.MedicineOrders.Where(x => x.Id == request.OrderId).FirstOrDefaultAsync();

            if (order is null)
            {
                throw new NotFoundException("order not found", order);
            }

            else
            {

                order.MedicineOrderStatus = request.Status;

                _context.MedicineOrders.Update(order);

                await _context.SaveChangesAsync();
            }

            return await Task.FromResult(Unit.Value);
        }

        public async Task<Unit> updateOrderStatusFromPharmacy(UpdateMedicineOrderStatusCommand request)
        {

           var order = await  _context.MedicineOrders.Where(x => x.Id == request.OrderId).FirstOrDefaultAsync();

            if (order is null)
            {
                throw new NotFoundException("order not found",order);
            }

            else
            {

                order.MedicineOrderStatus = request.Status;
           
                _context.MedicineOrders.Update(order);

                await _context.SaveChangesAsync();
            }

            return await Task.FromResult(Unit.Value);
        }

        public async Task<Unit> updateOrderStatusFromRider(UpdateMedicineOrderStatusCommand request)
        {
            var order = await _context.MedicineOrders.Where(x => x.Id == request.OrderId).FirstOrDefaultAsync();

            if (order is null)
            {
                throw new NotFoundException("order not found", order);
            }

            else
            {

                order.MedicineOrderStatus = request.Status;

                _context.MedicineOrders.Update(order);

                await _context.SaveChangesAsync();
            }

            return await Task.FromResult(Unit.Value);
        }
    }
}
