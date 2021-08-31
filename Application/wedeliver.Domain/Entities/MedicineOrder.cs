using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain.Common;
using wedeliver.Domain.Enums;

namespace wedeliver.Domain.Entities
{
    public class MedicineOrder: EntityBase
    {
        public string MedsDiscription { get; set; }
        public string PrescriptionUrl { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public string Note { get; set; }
        public double  Price { get; set; }
        public int PharmacyID { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        public MedicineOrderStatus MedicineOrderStatus { get; set; }
        public string BillURl { get; set; }
        public OrderType OrderType { get; set; }
    }
}
