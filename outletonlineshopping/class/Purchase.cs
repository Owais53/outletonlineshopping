using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace outletonlineshopping
{
    public class Purchase:Connection
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int POID { get; set; }
        public string PONo { get; set; }
        public int PID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public int SOref { get; set; }
        public DateTime Createdon { get; set; }
        public decimal Price { get; set; }
        public string PurchaseStatus { get; set; }
        public decimal TotalAmt { get; set; }

        public DataTable CheckDuplicateVendor(string Vendor)
        {
            OpenConection();
            DataTable dt = CheckDuplicatVendor("Select * from tblVendor where VendorName=@VName", Vendor);
            CloseConnection();
            return dt;

        }
        public void CreateVendor(Purchase obj)
        {
            OpenConection();
            InsertVendors("Insert into tblVendor(VendorName,Email,ContactNo,Address) values(@VName,@Email,@Contact,@Address)", obj.VendorName,obj.Contact,obj.Address,obj.Email);
            CloseConnection();
        }
        public void UpdateVendor(Purchase obj)
        {
            OpenConection();
            UpdateVendors("Update tblVendor set VendorName=@VName,Email=@Email,ContactNo=@Contact,Address=@Address where VendorID=@VId",obj.VendorID,obj.VendorName, obj.Contact, obj.Address, obj.Email);
            CloseConnection();
        }
        public void UpdatePoStatus(Purchase obj)
        {
            OpenConection();
            UpdateStatusPo("Update tblPO set Status=@Status where POID=@Id", obj.POID, obj.PurchaseStatus);
            CloseConnection();
        }
        public DataTable GetPOItem(int Id)
        {
            OpenConection();
            DataTable dt = GetPOLineItem("select pod.PODetID,p.ProductName,s.SizeName,pod.Quantity,pod.Price from tblPODetail pod inner join tblProduct p on pod.PID=p.ProductId inner join tblSizes s on pod.SizeID=s.SizeID where POID=@POID", Id);
            CloseConnection();
            return dt;

        }
        public DataTable GetGRItem(int Id)
        {
            OpenConection();
            DataTable dt = GetPOLineItem("select p.ProductName,s.SizeName,smd.Quantity from tblStockMoveDetail smd inner join tblStockMove sm on smd.StockMoveID=sm.StockMoveID inner join tblProduct p on smd.PID=p.ProductId inner join tblSizes s on smd.SizeID=s.SizeID where sm.POID=@POID", Id);
            CloseConnection();
            return dt;

        }
        public DataTable GetVendorBillDet(int Id)
        {
            OpenConection();
            DataTable dt = SelectInvoiceDet("select p.ProductName,s.SizeName,Price from tblPODetail sodet inner join tblProduct p on sodet.PID=p.ProductId inner join tblSizes s on sodet.SizeID=s.SizeID where sodet.POID in (select POID from tblVendorBill where Id=@Id)", Id);
            CloseConnection();
            return dt;

        }
        public int GetPOId(int Id)
        {
            OpenConection();
            int soId = selectId("select POID from tblVendorBill where Id=@Id", Id);
            CloseConnection();
            return soId;
        }
        public DataTable GetGIItemfromSO(int Id)
        {
            OpenConection();
            DataTable dt = GetPOLineItem("select smd.Id,p.ProductName,s.SizeName,smd.Quantity,smd.Status from tblStockMoveDetail smd inner join tblStockMove sm on smd.StockMoveID=sm.StockMoveID inner join tblProduct p on smd.PID=p.ProductId inner join tblSizes s on smd.SizeID=s.SizeID where sm.SOID=@POID", Id);
            CloseConnection();
            return dt;

        }
        public DataTable GetPOItemfromSO(int Id)
        {
            OpenConection();
            DataTable dt = GetPOLineItem("select p.ProductName,s.SizeName from tblPODetail podet inner join tblPo po on podet.POID=po.POID inner join tblProduct p on podet.PID=p.ProductId inner join tblSizes s on podet.SizeID=s.SizeID where po.SOref=@POID", Id);
            CloseConnection();
            return dt;

        }
        public DataTable GetPOItemNew(int Id)
        {
            OpenConection();
            DataTable dt = GetPOLineItem("select p.ProductName,s.SizeName,pod.Quantity,pod.Price from tblPODetail pod inner join tblProduct p on pod.PID=p.ProductId inner join tblSizes s on pod.SizeID=s.SizeID where POID=@POID", Id);
            CloseConnection();
            return dt;

        }
        public int GetPOCount(int SOID)
        {
            OpenConection();
            int ID = SelectPoCount("select COUNT(*) as POCount from tblPO where SOref=@SOID", SOID);
            CloseConnection();
            return ID;
        }
        public int GetMinGIID(int SOID)
        {
            OpenConection();
            int ID = selectId("select min(StockMoveID) as Id from tblStockMove where SOref=@Id", SOID);
            CloseConnection();
            return ID;
        }
        public int GetVendorProduct(string PName)
        {
            OpenConection();
            int ID = GetVendorPro("select VendorID from tblProduct where ProductName=@Pname", PName);
            CloseConnection();
            return ID;
        }
        public decimal GetPriceProduct(int PId,int Qty)
        {
            OpenConection();
            decimal price = SelectCostProd("select Cost*@Qty as Price from tblProduct where ProductId=@PId", PId,Qty);
            CloseConnection();
            return price;
        }
        public decimal GetTotalAmt(int POId)
        {
            OpenConection();
            decimal price = SelectTotalAmt("select SUM(Price) as TotalAmt from tblPODetail where POID=@POId", POId);
            CloseConnection();
            return price;
        }
        public int CreatePO(Purchase obj)
        {
            OpenConection();
            int Poid = InsertPO("Insert into tblPO(SOref,PONo,Createdon,VendorID,Status) values(@SOref,@PONO,@Createdon,@VendorID,@Status) SELECT SCOPE_IDENTITY()", obj.SOref, obj.PONo, obj.Createdon, obj.VendorID, obj.PurchaseStatus);
            CloseConnection();
            return Poid;
        }
        public void CreatePODet(Purchase obj)
        {
            OpenConection();
            InsertPODet("insert into tblPODetail(POID,PID,SizeID,Quantity,Price) values(@POID,@PID,@SizeID,@Qty,@Price)", obj.POID, obj.PID, obj.SizeID, obj.Quantity,obj.Price);
            CloseConnection();

        }
        public int CreateVendorBill(Purchase obj)
        {
            OpenConection();
            int Id=InsertVendorBill("insert into tblVendorBill(POID,TotalAmount) values(@POID,@Price) SELECT SCOPE_IDENTITY()", obj.POID,  obj.TotalAmt);
            CloseConnection();
            return Id;

        }

        public int GetLastPOId()
        {
            OpenConection();
            int Soid = GetLastId("select ISNULL(max(POID),0) as LastPOID from tblPO");
            CloseConnection();
            return Soid;

        }
        public int GetProductId(string Pname)
        {
            OpenConection();
            int Pid = GetProductID("select ProductId from tblProduct where ProductName=@Pname",Pname);
            CloseConnection();
            return Pid;

        }
        public int GetSizeId(string Sname)
        {
            OpenConection();
            int Sid = GetSizeID("select SizeID from tblSizes where SizeName=@Sname",Sname);
            CloseConnection();
            return Sid;

        }
        public DataTable GetLastPONo()
        {
            OpenConection();
            DataTable dt = GetLastNo("select PONo from tblPO where POID=(select max(POID) as LastPOID from tblPO)");
            CloseConnection();
            return dt;

        }

    }
}
