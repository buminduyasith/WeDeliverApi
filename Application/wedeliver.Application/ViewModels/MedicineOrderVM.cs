using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Entities;
using wedeliver.Domain.Enums;

namespace wedeliver.Application.ViewModels
{
    public class MedicineOrderVM
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string MedsItemIntext { get; set; }
        public string PrescriptionUrl { get; set; }
        public ClientVM Client { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public Rider Rider { get; set; }
        public MedicineOrderStatus MedicineOrderStatus { get; set; }
        public string BillURl { get; set; }
        public OrderType OrderType { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public DateTime OrderDate { get; set; }
        public ShippingDetails ShippingDetails { get; set; }
        public string ShippingAddress { get; set; }
    }
}
