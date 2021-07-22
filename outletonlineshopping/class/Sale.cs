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
            DataTable dt = GetSOLineItem("select sod.SOdetailID,p.ProductName,s.SizeName,sod.Quantity,convert(date,sod.ScheduledDeliveryDate) as Datee,sod.DeliveryStatus from tblSODetail sod inner join tblProduct p on sod.PID=p.ProductId inner join tblSizes s on sod.SizeID=s.SizeID where SOID=@SOID", Id);
            CloseConnection();
            return dt;

        }
        public DataTable CheckIfPoreceived(int Id)
        {
            OpenConection();
            DataTable dt = CheckIfPOReceived(" select * from tblStockMove sm inner join tblPO po on sm.POID=po.POID where sm.SOID=@SOID", Id);
            CloseConnection();
            return dt;

        }
        public void ChangeDevDate(int Id,string date)
        {
            OpenConection();
            UpdateScheduledDevDate("update tblSODetail set ScheduledDeliveryDate=@DevDate where SOdetailID=@Id", Id,date);
            CloseConnection();
            

        }
        public DataTable GetPoifreceived(int Id)
        {
            OpenConection();
            DataTable dt = GetPOIfSoExists("select * from tblPO where SOref in (select SOID from tblSODetail where SOdetailID=@SOID and DeliveryStatus='Not Delivered') and Status='Received'", Id);
            CloseConnection();
            return dt;

        }
        public DataTable CheckPoExists(int Id)
        {
            OpenConection();
            DataTable dt = GetPOIfSoExists("select * from tblPO where SOref in (select SOID from tblSODetail where SOdetailID=@SOID)", Id);
            CloseConnection();
            return dt;

        }
        public DataTable GetInvoiceDet(int Id)
        {
            OpenConection();
            DataTable dt = SelectInvoiceDet("select p.ProductName,s.SizeName,SalesPrice as Price from tblSODetail sodet inner join tblProduct p on sodet.PID=p.ProductId inner join tblSizes s on sodet.SizeID=s.SizeID where sodet.SOID in (select SOID from tblPay where PaymentId=@Id)", Id);
            CloseConnection();
            return dt;

        }
        public int GetSOId(int Id)
        {
            OpenConection();
            int soId = selectId("select SOID from tblPay where PaymentId=@Id",Id);
            CloseConnection();
            return soId;
        }
    }
}