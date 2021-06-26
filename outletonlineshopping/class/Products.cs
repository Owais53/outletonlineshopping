using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public class Products : Connection
   {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Uom { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Cost { get; set; }
        public int UomId { get; set; }
        public string Unitofmeasure { get; set; }
        public int Quantity { get; set; }


        public void DeleteProducts(int Id)
        {
            OpenConection();
            ExecuteDeleteQueries("Delete from tblProduct where ProductId=@Id",Id);


        }
        public void CreateProducts(Products obj)
        {
            OpenConection();
            InsertProducts("Insert into tblProduct(ProductName,SalesPrice,Uom,Cost,Quantity) values(@Name,@price,@Uom,@cost,@Qty)",obj.ProductName,obj.Uom,obj.SalesPrice,obj.Cost,0);
            CloseConnection();
        }
        public void UpdateProduct(Products obj)
        {
            OpenConection();
            UpdateProducts("Update tblProduct set ProductName=@Name,SalesPrice=@price,Uom=@Uom,Cost=@cost where ProductId=@ProductId", obj.ProductName, obj.Uom, obj.SalesPrice, obj.Cost,obj.ProductId);
            CloseConnection();
        }
        public void CreateUnit(Products obj)
        {
            OpenConection();
            InsertUnits("Insert into tblUom(Unitofmeasure) values(@Name)", obj.Unitofmeasure);
            CloseConnection();
        }
        public void UpdateUnit(Products obj)
        {
            OpenConection();
            UpdateUnits("Update tblUom set Unitofmeasure=@Name where UomId=@UomId", obj.Unitofmeasure, obj.UomId);
            CloseConnection();
        }
        public void DeleteUnits(int Id)
        {
            OpenConection();
            ExecuteDeleteQueries("Delete from tblUom where UomId=@Id", Id);


        }
        public void AddQuantity(Products obj)
        {
            OpenConection();
            UpdateQuantity("Update tblProduct set Quantity=Quantity+@Qty where ProductId=@ProductId",obj.ProductId,obj.Quantity);
            CloseConnection();
        }
    }
}