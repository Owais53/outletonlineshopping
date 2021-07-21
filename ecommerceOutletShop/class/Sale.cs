using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ecommerceOutletShop
{
    public class Sale:Connect
     {
        public int SOID { get; set; }
        public string SONo { get; set; }
        public int UserID { get; set; }
        public DateTime Createdon { get; set; }
        public int POref { get; set; }
        public string Status { get; set; }
        public string CustomerType { get; set; }
        public int PID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public decimal salePrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string CreditCardNumber { get; set; }
        public string DebitCardNumber { get; set; }
        public string PaymentType { get; set; }
        public string DeliveryAddress { get; set; }
        public string PayStatus { get; set; }
        public string DevStatus { get; set; }
        public string MoveType  { get; set; }
        public string StockMoveStatus { get; set; }
        public DateTime ScheduledDeliveryDate { get; set; }

        public int CreateSO(Sale obj)
        {
            OpenConection();
            int Pid = InsertSO("Insert into tblSO(SONo,UserID,Createdon,POref,Status,CustomerType) values(@SONO,@UserID,@Createdon,@POref,@Status,@CustomerType) SELECT SCOPE_IDENTITY()", obj.SONo, obj.UserID, obj.Createdon, obj.POref, obj.Status, obj.CustomerType);
            CloseConnection();
            return Pid;
        }
        public void CreateSODet(Sale obj)
        {
            OpenConection();
            InsertSODet("Insert into tblSODetail(SOID,PID,SizeID,Quantity,DeliveryStatus,Price) values(@SOID,@PID,@SizeID,@Qty,@DevStatus,@Price)", obj.SOID, obj.PID,obj.SizeID ,obj.Quantity,obj.DevStatus,obj.salePrice);
            CloseConnection();
         
        }
        public decimal GetPriceProduct(Sale obj)
        {
            OpenConection();
            decimal price = SelectCostProd("select SalesPrice*@Qty as Price from tblProduct where ProductId=@PId", obj.PID, obj.Quantity);
            CloseConnection();
            return price;
        }
        public void CreatePay(Sale obj)
        {
            OpenConection();
            InsertPay("Insert into tblPay(SOID,TotalAmount,CreditCardNumber,DebitCardNumber,PaymentType,DeliveryAddress,Status) values(@SOID,@TotalAmt,@CrCdNo,@DtCdNo,@PayType,@DelAdd,@Status)", obj.SOID, obj.TotalAmount,obj.CreditCardNumber,obj.DebitCardNumber,obj.PaymentType,obj.DeliveryAddress,obj.PayStatus);
            CloseConnection();

        }
       
        public DataTable GetUserId(string Username)
        {
            OpenConection();
            DataTable dt = GetUserIdbyName("Select LoginId from tblecommLogin where UserName=@Username and isAdmin='False'", Username);
            CloseConnection();
            return dt;

        }
        public DataTable GetLastSONo()
        {
            OpenConection();
            DataTable dt = GetLastNo("select SONo from tblSO where SOID=(select max(SOID) as LastSOID from tblSO)");
            CloseConnection();
            return dt;
        }
        public DataTable GetLastGINo()
        {
            OpenConection();
            DataTable dt = GetLastNo("select DocNo from tblStockMove where StockMoveID=(select max(StockMoveID) as LastSOID from tblStockMove where SOID>0)");
            CloseConnection();
            return dt;
        }
        public DataTable GetOrderTrackbyUser(int SOID,int PID,int SizeID)
        {
            OpenConection();
            DataTable dt = GetProductOrderTrackingStatus("select so.SONo,convert(date,sodet.ScheduledDeliveryDate) as Datee,smd.Quantity*p.SalesPrice as Price,sm.SOID,smd.PID,smd.SizeID,sm.DocNo,smd.Status,B.Name,B.Extension,p.ProductName from tblStockMoveDetail smd inner join tblStockMove sm on smd.StockMoveID=sm.StockMoveID inner join tblSO so on sm.SOID=so.SOID inner join tblSODetail sodet on so.SOID=sodet.SOID and smd.PID=sodet.PID and smd.SizeID=sodet.SizeID inner join tblProduct p on smd.PID=p.ProductId cross apply(select top 1 * from tblProductImages B where B.PID = p.ProductId) B where sm.SOID=@SOID and smd.PID=@PID and smd.SizeID=@SID", SOID,PID,SizeID);
            CloseConnection();
            return dt;
        }
        public DataTable GetOrderTrack(int SOID, int PID, int SizeID)
        {
            OpenConection();
            DataTable dt = GetProductOrderTrackingStatus("select so.SONo,convert(date,sodet.ScheduledDeliveryDate) as Datee,sodet.Quantity*p.SalesPrice as Price,sodet.SOID,sodet.PID,sodet.SizeID,'' as DocNo,'Order Confirmed' as Status,B.Name,B.Extension,p.ProductName from tblSODetail sodet inner join tblSO so on sodet.SOID=so.SOID inner join tblProduct p on sodet.PID=p.ProductId cross apply(select top 1 * from tblProductImages B where B.PID = p.ProductId)B where sodet.SOID=@SOID and sodet.PID=@PID and sodet.SizeID=@SID", SOID, PID, SizeID);
            CloseConnection();
            return dt;
        }
        public DataTable GetOrderHistorybyUser(int UserID)
        {
            OpenConection();
            DataTable dt = GetProductOrderHistory("select so.SONo,sodet.DeliveryStatus,so.Createdon,sodet.SOID,sodet.PID,sodet.SizeID,p.ProductName,sodet.Quantity,sodet.Quantity*p.SalesPrice as Price,B.Name,B.Extension from tblSODetail sodet inner join tblSO so on sodet.SOID=so.SOID inner join tblProduct p on sodet.PID=p.ProductId cross apply(select top 1 * from tblProductImages B where B.PID = p.ProductId order by B.PID desc)B where so.UserID=@UserID", UserID);
            CloseConnection();
            return dt;
        }
        public DataTable GetOrderHistorybyUserStatus(int UserID,string Status)
        {
            OpenConection();
            DataTable dt = GetProductOrderHistoryStatus("select so.SONo,sodet.DeliveryStatus,so.Createdon,sodet.SOID,sodet.PID,sodet.SizeID,p.ProductName,sodet.Quantity,sodet.Quantity*p.SalesPrice as Price,B.Name,B.Extension from tblSODetail sodet inner join tblSO so on sodet.SOID=so.SOID inner join tblProduct p on sodet.PID=p.ProductId cross apply(select top 1 * from tblProductImages B where B.PID = p.ProductId order by B.PID desc)B where so.UserID=@UserID and sodet.DeliveryStatus=@DevStatus", UserID,Status);
            CloseConnection();
            return dt;
        }
        public DataTable GetLastGRNo()
        {
            OpenConection();
            DataTable dt = GetLastNo("select DocNo from tblStockMove where StockMoveID=(select max(StockMoveID) as LastSOID from tblStockMove where POID>0)");
            CloseConnection();
            return dt;
        }
        public SqlDataReader GetSOCount()
        {
            OpenConection();
            SqlDataReader dr = DataReader("select SOID,Count(SOID) as IDCount from tblSODetail  group by SOID");
            return dr;

        }
        public SqlDataReader GetDeliveredProCount()
        {
            OpenConection();
            SqlDataReader dr = DataReader("SELECT tblSODetail.SOID, COUNT(tblSO.SOID) AS IDCount FROM tblSODetail LEFT JOIN tblSO ON (tblSODetail.SOID = tblSO.SOID AND tblSODetail.DeliveryStatus='Delivered') GROUP BY tblSODetail.SOID");
            return dr;

        }

        public int CountSOofUser(int UserID)
        {
            OpenConection();
            int Poid = SelectSalesCount("select COUNT(*) as SalesCount from tblSO group by UserID Having UserID=@UserID", UserID);
            CloseConnection();
            return Poid;
        }
        public string GetCustomerTypebyuser(int UserID)
        {
            OpenConection();
            string custtype = GetCustomerType("select CustomerType from tblSO where UserID=@UserID", UserID);
            CloseConnection();
            return custtype;
        }
        public int GetLastSOId()
        {
            OpenConection();
            int Soid = GetLastId("select ISNULL(max(SOID),0) as LastSOID from tblSO");
            CloseConnection();
            return Soid;

        }
        public int GetLastSmoveSoId()
        {
            OpenConection();
            int Soid = GetLastId("select ISNULL(max(StockMoveID),0) as LastSOID from tblStockMove where SOID >0");
            CloseConnection();
            return Soid;

        }
        public int GetLastSmovePoId()
        {
            OpenConection();
            int Soid = GetLastId("select ISNULL(max(StockMoveID),0) as LastSOID from tblStockMove where POID >0");
            CloseConnection();
            return Soid;

        }
        public int GetCustomerLeadTime(Sale obj)
        {
            OpenConection();
            int custleadtime = GetCustLeadTime("select CustomerLeadTime from tblProductSizeQuantity where PID=@PID and SizeID=@SizeID",obj.PID,obj.SizeID);
            CloseConnection();
            return custleadtime;

        }
        public void AddScheduledDate(Sale obj)
        {
            OpenConection();
            UpdateScheduledDate("Update tblSODetail set ScheduledDeliveryDate=@SDD where SOID=@SOID and PID=@PID and SizeID=@SizeID", obj.PID, obj.SizeID,obj.ScheduledDeliveryDate,obj.SOID);
            CloseConnection();
        }
        public void UpdateStatusSOIfdev()
        {
            OpenConection();
            ExecuteQueries("update tblSO set Status='Delivered' where SOID in(select SOID from tblStockMove where Status='Delivered')");
            CloseConnection();
        }
        public void UpdateStatusSOIfpardev()
        {
            OpenConection();
            ExecuteQueries("update tblSO set Status='Partially Delivered' where SOID in(select SOID from tblStockMove where Status='Partially Delivered')");
            CloseConnection();
        }
        public void UpdateStatusStocktoship(string date)
        {
            OpenConection();
            UpdateStockStatus("update tblStockMove set Status='Shipped' where SOID in(select SOID from tblSO where CONVERT(date,Createdon)< @date)",date);
            CloseConnection();
        }
        public void ChangeStockMoveStatus(Sale obj)
        {
            OpenConection();
             UpdateStockSatusDev("Update tblStockMove set Status=@Status where SOID=@SOID", obj.SOID, obj.Status);
            CloseConnection();
        }
        public void UpdateStatusProductSale(string date)
        {
            OpenConection();
            UpdateScheduledDeliveryStatus("update tblSODetail set DeliveryStatus='Delivered' where SOID IN(select SOID from tblSO) and Convert(date,ScheduledDeliveryDate)=@schdevdate", date);
            CloseConnection();
        }
        public int CheckQuantity(int PID,int SizeID,int Qty)
        {
            OpenConection();
            int SoQtyid = CheckQty("select PrdSizeQuantID from tblProductSizeQuantity where Quantity-@Qty<=ReorderPoint and PID=@PID and SizeID=@SizeID",PID,SizeID,Qty);
            CloseConnection();
            return SoQtyid;

        }
    }
}