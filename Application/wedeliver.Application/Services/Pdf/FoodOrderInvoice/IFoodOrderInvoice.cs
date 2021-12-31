using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Services.Pdf.FoodOrderInvoice
{
    public interface IFoodOrderInvoice
    {
       Task<bool> process(int foodOrder);
    }
}
