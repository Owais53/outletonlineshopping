using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceOutletShop
{
    public class Purchase : Connect
    {
         public int POID { get; set; }
        public int PID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public DateTime Createdon { get; set; }
        public int VendorId { get; set; }
        public string PurchaseStatus { get; set; }
    }
}