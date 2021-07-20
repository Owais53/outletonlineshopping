using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace outletonlineshopping
{
    public class Inventory :Connection
   {
       public int VendorID { get; set; }
        public string DocNo { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public int POID { get; set; }
        public string PONo { get; set; }
        public int PID { get; set; }
        public int SizeID { get; set; }
        public int Quantity { get; set; }
        public int SOID { get; set; }
        public string MoveType { get; set; }
        public DateTime Createdon { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        public int CreateGR(Inventory obj)
        {
            OpenConection();
            int Grid = InsertGR("Insert into tblStockMove(DocNo,SOID,POID,MoveType,Status) values(@DocNo,@SOID,@POID,@MoveType,@Status) SELECT SCOPE_IDENTITY()", obj.DocNo, obj.SOID, obj.POID, obj.MoveType, obj.Status);
            CloseConnection();
            return Grid;
        }
        public int GetLastSmovePoId()
        {
            OpenConection();
            int Soid = GetLastId("select ISNULL(max(StockMoveID),0) as LastSOID from tblStockMove where POID >0");
            CloseConnection();
            return Soid;

        }
        public DataTable GetLastGRNo()
        {
            OpenConection();
            DataTable dt = GetLastNo("select DocNo from tblStockMove where StockMoveID=(select max(StockMoveID) as LastSOID from tblStockMove where POID>0)");
            CloseConnection();
            return dt;
        }
        public DataTable CheckGRExists(int POID)
        {
            OpenConection();
            DataTable dt = GetPOLineItem("select * from tblStockMove where POID>0 and POID=@POID", POID);
            CloseConnection();
            return dt;
        }
        public void ChangeQuantityPlus(Inventory obj)
        {
            OpenConection();
            UpdateQuantityPlus("Update tblProductSizeQuantity set Quantity=Quantity+@Qty where PID=@PId and SizeID=@Size", obj.PID, obj.SizeID, obj.Quantity);
            CloseConnection();
        }
    }
}
