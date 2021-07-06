using System;
using System.Collections.Generic;
using System.Data;
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
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string CreditCardNumber { get; set; }
        public string DebitCardNumber { get; set; }
        public string PaymentType { get; set; }
        public string DeliveryAddress { get; set; }
        public string PayStatus { get; set; }
        public string MoveType  { get; set; }
        public string StockMoveStatus { get; set; }

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
            InsertSODet("Insert into tblSODetail(SOID,PID,Quantity) values(@SOID,@PID,@Qty)", obj.SOID, obj.PID, obj.Quantity);
            CloseConnection();
         
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
        public int GetLastSOId()
        {
            OpenConection();
            int Soid = GetLastId("select ISNULL(max(SOID),0) as LastSOID from tblSO");
            CloseConnection();
            return Soid;

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