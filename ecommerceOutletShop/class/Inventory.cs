using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceOutletShop
{
    public class Inventory : Connect
    {
        public int SOID { get; set; }
        public int POID { get; set; }
        public string SONo { get; set; }
        public string DOCNo { get; set; }
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
        public int StockMoveID { get; set; }

        public int CreateStockMove(Inventory obj)
        {
            OpenConection();
          int id=InsertStockMove("Insert into tblStockMove(DocNo,SOID,POID,MoveType,Status) values(@DocNO,@SOID,@POID,@MoveType,@Status) SELECT SCOPE_IDENTITY()", obj.DOCNo,obj.SOID,obj.POID,obj.MoveType, obj.StockMoveStatus);
            CloseConnection();
            return id;
        }
        public void CreateStockMoveDet(Inventory obj)
        {
            OpenConection();
            InsertStockMoveDet("Insert into tblStockMoveDetail(StockMoveID,PID,SizeID,Quantity,Status) values(@StockMoveID,@PID,@SizeID,@Qty,@Status)", obj.StockMoveID, obj.PID, obj.SizeID, obj.Quantity, obj.StockMoveStatus);
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