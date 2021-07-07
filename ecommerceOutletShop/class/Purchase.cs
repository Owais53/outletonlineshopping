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
        public DateTime Createdon { get; set; }
        public int VendorId { get; set; }
        public string PurchaseStatus { get; set; }

        public int CreatePO(Purchase obj)
        {
            OpenConection();
            int Poid = InsertPO("Insert into tblPO(PONo,Createdon,VendorID,Status) values(@PONO,@Createdon,@VendorID,@Status) SELECT SCOPE_IDENTITY()", obj.PONo, obj.Createdon, obj.VendorId, obj.PurchaseStatus);
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
        public int GetVendorIdbyPO(int POID)
        {
            OpenConection();
            int Vid = GetVendorIDbyProduct("select VendorID from tblPO where POID=@PID", PID);
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
        public void CreatePODet(Purchase obj)
        {
            OpenConection();
            InsertPODet("insert into tblPODetail(POID,PID,Quantity) values(@POID,@PID,@Qty)",obj.POID,obj.PID,obj.Quantity);
            CloseConnection();

        }
    }
}