using System;
using System.Collections.Generic;
using System.Data;
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
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public string CatName { get; set; }
        public int CatID { get; set; }
        public string SubCatName { get; set; }
        public int SubCatID { get; set; }
        public string Sizename { get; set; }
        public int GenderID { get; set; }
        public int SizeID { get; set; }
        public string desc { get; set; }
        public string productdetail { get; set; }
        public string matcare { get; set; }
        public int Freedelivery { get; set; }
        public string ImgName { get; set; }
        public string Extension { get; set; }
        public int ReorderPoint { get; set; }
        public int CustomerLeadTime { get; set; }

        public void DeleteProducts(int Id)
        {
            OpenConection();
            ExecuteDeleteQueries("Delete from tblProduct where ProductId=@Id",Id);


        }
        public DataTable CheckDuplicateBrand(string Brand)
        {
            OpenConection();
            DataTable dt = CheckDupBrand("Select * from tblBrands where Name=@BName", Brand);
            CloseConnection();
            return dt;

        }
        public DataTable CheckDuplicateCat(string Cat)
        {
            OpenConection();
            DataTable dt = CheckDupCat("Select * from tblCategory where CatName=@CatName", Cat);
            CloseConnection();
            return dt;

        }
        public DataTable CheckDuplicateSubCat(string SubCat ,int CatID)
        {
            OpenConection();
            DataTable dt = CheckDupSubCat("Select * from tblSubCategory where SubCatName=@SubCatName and MainCatID=@CatID", SubCat,CatID);
            CloseConnection();
            return dt;

        }
        public DataTable CheckDuplicateSize(string size,int BrandId,int CatID,int SubCatID,int GenderID)
        {
            OpenConection();
            DataTable dt = CheckDupSize("Select * from tblSizes where SizeName=@SizeName and BrandID=@BrandID and CategoryID=@CatID and SubCategoryID=@SubCatID and GenderID=@GenderID", size,BrandId,CatID,SubCatID,GenderID);
            CloseConnection();
            return dt;

        }
        public DataTable GetBrand(int Id)
        {
            OpenConection();
            DataTable dt = GetBrandById("Select * from tblBrands where BrandID=@BID", Id);
            CloseConnection();
            return dt;

        }
        
        public int CreateProducts(Products obj)
        {
            OpenConection();
           int Pid= InsertProducts("Insert into tblProduct(ProductName,SalesPrice,Uom,Cost,BrandID,CategoryID,SubCatID,GenderID,Description,ProductDetails,MaterialCare,FreeDelivery) values(@Name,@price,@Uom,@cost,@brandid,@catid,@subcatid,@genderid,@desc,@productdetail,@matcare,@fd) SELECT SCOPE_IDENTITY()", obj.ProductName,obj.Uom,obj.SalesPrice,obj.Cost,obj.BrandId,obj.CatID,obj.SubCatID,obj.GenderID,obj.desc,obj.productdetail,obj.matcare,obj.Freedelivery);
            CloseConnection();
            return Pid;
        }
        public void UpdateProduct(Products obj)
        {
            OpenConection();
            UpdateProducts("Update tblProduct set ProductName=@Name,SalesPrice=@price,Uom=@Uom,Cost=@cost,BrandID=@brandid,CategoryID=@catid,SubCatID=@subcatid,GenderID=@genderid,Description=@desc,ProductDetails=@productdetail,MaterialCare=@matcare,FreeDelivery=@fd where ProductId=@ProductId", obj.ProductName, obj.Uom, obj.SalesPrice, obj.Cost,obj.ProductId, obj.BrandId, obj.CatID, obj.SubCatID, obj.GenderID, obj.desc, obj.productdetail, obj.matcare, obj.Freedelivery);
            CloseConnection();
        }
        public void UpdateProductSizeQty(Products obj)
        {
            OpenConection();
            UpdateQtySize("Update tblProductSizeQuantity set Quantity=@Qty,ReorderPoint=@Reorder,CustomerLeadTime=@Cst where PID=@ProductId", obj.ProductId,obj.Quantity, obj.ReorderPoint,obj.CustomerLeadTime);
            CloseConnection();
        }

        public void CreateUnit(Products obj)
        {
            OpenConection();
            InsertUnits("Insert into tblUom(Unitofmeasure) values(@Name)", obj.Unitofmeasure);
            CloseConnection();
        }
        public void CreateBrand(Products obj)
        {
            OpenConection();
            InsertBrands("Insert into tblBrands(Name) values(@BName)", obj.BrandName);
            CloseConnection();
        }
        public void CreateCat(Products obj)
        {
            OpenConection();
            InsertCat("Insert into tblCategory(CatName) values(@CatName)", obj.CatName);
            CloseConnection();
        }
        public void CreateSubCat(Products obj)
        {
            OpenConection();
            InsertSubCat("Insert into tblSubCategory(SubCatName,MainCatID) values(@SubCatName,@CatID)", obj.SubCatName,obj.CatID);
            CloseConnection();
        }
        public void CreateSize(Products obj)
        {
            OpenConection();
            InsertSize("Insert into tblSizes(SizeName,BrandID,CategoryID,SubCategoryID,GenderID) values(@SizeName,@BrandID,@CatID,@SubCatID,@GenderID)", obj.Sizename,obj.BrandId,obj.CatID,obj.SubCatID,obj.GenderID);
            CloseConnection();
        }
        public void CreateImg(Products obj)
        {
            OpenConection();
            InsertImg("Insert into tblProductImages(PID,Name,Extension) values(@PID,@Name,@Extension)", obj.ProductId,obj.ImgName,obj.Extension);
            CloseConnection();
        }
        public void CreateSizeQty(Products obj)
        {
            OpenConection();
            InsertSizeQty("Insert into tblProductSizeQuantity(PID,SizeID,Quantity,ReorderPoint,CustomerLeadTime) values(@Pid,@sizeid,@Qty,@Reorder,@Cst)", obj.ProductId,obj.SizeID,obj.Quantity,obj.ReorderPoint,obj.CustomerLeadTime);
            CloseConnection();
        }
        public void UpdateUnit(Products obj)
        {
            OpenConection();
            UpdateUnits("Update tblUom set Unitofmeasure=@Name where UomId=@UomId", obj.Unitofmeasure, obj.UomId);
            CloseConnection();
        }
        public void UpdateBrand(Products obj)
        {
            OpenConection();
            UpdateBrands("Update tblBrands set Name=@BName where BrandID=@Id", obj.BrandName, obj.BrandId);
            CloseConnection();
        }
        public void UpdateCat(Products obj)
        {
            OpenConection();
            UpdateCats("Update tblCategory set CatName=@CatName where CatID=@Id", obj.CatName, obj.CatID);
            CloseConnection();
        }
        public void UpdateSubCat(Products obj)
        {
            OpenConection();
            UpdateSubCats("Update tblSubCategory set SubCatName=@SubCatName,MainCatID=@CatID where SubCatID=@Id", obj.SubCatName, obj.CatID,obj.SubCatID);
            CloseConnection();
        }
        public void UpdateSize(Products obj)
        {
            OpenConection();
            UpdateSizes("Update tblSizes set SizeName=@SizeName,BrandID=@BrandID,CategoryID=@CatID,SubCategoryID=@SubCatID,GenderID=@GenderID where SizeID=@SizeID", obj.Sizename, obj.BrandId, obj.CatID,obj.SubCatID,obj.GenderID,obj.SizeID);
            CloseConnection();
        }
        public void DeleteUnits(int Id)
        {
            OpenConection();
            ExecuteDeleteQueries("Delete from tblUom where UomId=@Id", Id);


        }
        public void DeleteBrands(int Id)
        {
            OpenConection();
            ExecuteDeleteQueries("Delete from tblBrands where BrandID=@Id", Id);


        }
        public void AddQuantity(Products obj)
        {
            OpenConection();
            UpdateQuantity("Update tblProduct set Quantity=Quantity+@Qty where ProductId=@ProductId",obj.ProductId,obj.Quantity);
            CloseConnection();
        }
    }
}