using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace outletonlineshopping 
{
    public class Sale:Connection
   {

        public DataTable GetSOItem(int Id)
        {
            OpenConection();
            DataTable dt = GetSOLineItem("select sod.SOdetailID,p.ProductName,s.SizeName,sod.Quantity,sod.ScheduledDeliveryDate,sod.DeliveryStatus from tblSODetail sod inner join tblProduct p on sod.PID=p.ProductId inner join tblSizes s on sod.SizeID=s.SizeID where SOID=@SOID", Id);
            CloseConnection();
            return dt;

        }
    }
}