using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Application.Services.Notification;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Services.Pdf.FoodOrderInvoice
{
    public interface IFoodOrderInvoice
    {
       Task<Dictionary<string, string>> process(int foodOrder);
       Task<NotificationMessage> GetFoodOrderHtmlContentForEmail(Dictionary<string, string> data,int id);
       //Task<NotificationMessage> GetFoodOrderHtmlContentForEmail(Dictionary<string, string> data);
    }
}
