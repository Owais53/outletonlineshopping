using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceOutletShop
{
    public class Inventory : Connect
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
        public string MoveType { get; set; }
        public string StockMoveStatus { get; set; }

        public void CreateStockMove(Inventory obj)
        {
            OpenConection();
            InsertStockMove("Insert into tblStockMove(SOID,MoveType,Status) values(@SOID,@MoveType,@Status)", obj.SOID, obj.MoveType, obj.StockMoveStatus);
            CloseConnection();

        }
        public void ChangeQuantityMinus(Inventory obj)
        {
            OpenConection();
            UpdateQuantityMinus("Update tblProductSizeQuantity set Quantity=Quantity-@Qty where PID=@PId and SizeID=@Size", obj.PID, obj.SizeID,obj.Quantity);
            CloseConnection();
        }
    }
}