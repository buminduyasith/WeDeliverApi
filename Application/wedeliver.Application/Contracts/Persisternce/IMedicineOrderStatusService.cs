using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Features.MedicineOrders.Commands.UpdateMedicineOrderStatus;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface IMedicineOrderStatusService
    {
        Task<Unit> updateOrderStatusFromPharmacy(UpdateMedicineOrderStatusCommand updateMedicineOrderStatusCommand);
        Task<Unit> updateOrderStatusFromRider(UpdateMedicineOrderStatusCommand updateMedicineOrderStatusCommand);
        Task<Unit> updateOrderStatusFromClient(UpdateMedicineOrderStatusCommand updateMedicineOrderStatusCommand);

    }
}
