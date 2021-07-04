using System;
using System.Collections.Generic;
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
    }
}