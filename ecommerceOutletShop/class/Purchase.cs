using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ecommerceOutletShop
{
    public class Purchase : Connect
    {
        public int POID { get; set; }
        public string PONo { get; set; }
        public int PID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public int SOref { get; set; }
        public DateTime Createdon { get; set; }
        public int VendorId { get; set; }
        public string PurchaseStatus { get; set; }
        public decimal Price { get; set; }

        public int CreatePO(Purchase obj)
        {
            OpenConection();
            int Poid = InsertPO("Insert into tblPO(SOref,PONo,Createdon,VendorID,Status) values(@SOref,@PONO,@Createdon,@VendorID,@Status) SELECT SCOPE_IDENTITY()",obj.SOref, obj.PONo, obj.Createdon, obj.VendorId, obj.PurchaseStatus);
            CloseConnection();
            return Poid;
        }
       
        public DataTable GetLastPONo()
        {
            OpenConection();
            DataTable dt = GetLastNo("select PONo from tblPO where POID=(select max(POID) as LastPOID from tblPO)");
            CloseConnection();
            return dt;

        }
        public DataTable GetPOLineItemforEmail(int POID)
        {
            OpenConection();
            DataTable dt = SelectPOLineitemforEmail("select p.ProductName,s.SizeName as Size,podet.Quantity,podet.Price from tblPODetail podet inner join tblProduct p on podet.PID=p.ProductId inner join tblSizes s on podet.SizeID=s.SizeID where POID=@POID", POID);
            CloseConnection();
            return dt;

        }
        public int GetLastPOId()
        {
            OpenConection();
            int Soid = GetLastId("select ISNULL(max(POID),0) as LastPOID from tblPO");
            CloseConnection();
            return Soid;

        }
        public int GetVendorId(int PID)
        {
            OpenConection();
            int Vid = GetVendorIDbyProduct("select VendorID from tblProduct where ProductId=@PID",PID);
            CloseConnection();
            return Vid;

        }
        public string GetPONOfromEmail(int POID)
        {
            OpenConection();
            string poid = SelectPONOforEmail("select PONo from tblPO where POID=@POID", POID);
            CloseConnection();
            return poid;

        }
        public string GetVendorEmailfromPO(int POID)
        {
            OpenConection();
            string email = SelectVendorEmail("select v.Email from tblPO po inner join tblVendor v on po.VendorID=v.VendorID where POID=@POID", POID);
            CloseConnection();
            return email;

        }
        public int GetVendorIdbyPO(int POID)
        {
            OpenConection();
            int Vid = GetVendorIDbyProduct("select VendorID from tblPO where POID=@PID", POID);
            CloseConnection();
            return Vid;

        }
        public int GetPOIdbyVendor(int VID,string date)
        {
            OpenConection();
            int POid = GetPOIDbyVendor("select Max(POID) as POID from tblPO where VendorID=@VID and convert(date,Createdon)=@Createdon", VID,date);
            CloseConnection();
            return POid;

        }
        public decimal GetPriceProduct(Purchase obj)
        {
            OpenConection();
            decimal price = SelectCostProd("select Cost*@Qty as Price from tblProduct where ProductId=@PId", obj.PID, obj.Quantity);
            CloseConnection();
            return price;
        }
        public void CreatePODet(Purchase obj)
        {
            OpenConection();
            InsertPODet("insert into tblPODetail(POID,PID,SizeID,Quantity,Price) values(@POID,@PID,@SizeID,@Qty,@Price)",obj.POID,obj.PID,obj.SizeID,obj.Quantity,obj.Price);
            CloseConnection();

        }
        public int GetDeliveryLeadTime(Purchase obj)
        {
            OpenConection();
            int devleadtime = GetDevLeadTime("select DeliveryLeadTime from tblVendor where VendorID=@VID", obj.VendorId);
            CloseConnection();
            return devleadtime;

        }
    }
}