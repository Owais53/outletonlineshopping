using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace outletonlineshopping
{
    public class Connection
    {
        string ConnectionString = "Data source=.; initial catalog=outlet; integrated security=true;";
        SqlConnection con;

        public void OpenConection()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }
        public void ExecuteDeleteQueries(string Query_,int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
        }
        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }
        public int InsertProducts(string Query_,string ProductName,int uom,decimal price,decimal cost,int brandid,int catid,int subcatid,int genderid,string desc,string prddetail,string matcare,int fd)
        {
            
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Name", ProductName);
            cmd.Parameters.AddWithValue("@Uom", uom);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@cost", cost);
            cmd.Parameters.AddWithValue("@brandid", brandid);
            cmd.Parameters.AddWithValue("@catid", catid);
            cmd.Parameters.AddWithValue("@subcatid", subcatid);
            cmd.Parameters.AddWithValue("@genderid", genderid);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@productdetail", prddetail);
            cmd.Parameters.AddWithValue("@matcare", matcare);
            cmd.Parameters.AddWithValue("@fd", fd);
            int pid= Convert.ToInt32(cmd.ExecuteScalar());           
            return pid;
        }

        public void UpdateProducts(string Query_, string ProductName, int uom, decimal price, decimal cost,int Id, int brandid, int catid, int subcatid, int genderid, string desc, string prddetail, string matcare, int fd)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@ProductId", Id);
            cmd.Parameters.AddWithValue("@Name", ProductName);
            cmd.Parameters.AddWithValue("@Uom", uom);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@cost", cost);
            cmd.Parameters.AddWithValue("@brandid", brandid);
            cmd.Parameters.AddWithValue("@catid", catid);
            cmd.Parameters.AddWithValue("@subcatid", subcatid);
            cmd.Parameters.AddWithValue("@genderid", genderid);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@productdetail", prddetail);
            cmd.Parameters.AddWithValue("@matcare", matcare);
            cmd.Parameters.AddWithValue("@fd", fd);
            cmd.ExecuteNonQuery();
        }
        public void UpdateQtySize(string Query_, string ProductName, int uom, decimal price, decimal cost, int Id, int brandid, int catid, int subcatid, int genderid, string desc, string prddetail, string matcare, int fd)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PrdsizeqtyId", Id);
            cmd.Parameters.AddWithValue("@Name", ProductName);
            cmd.Parameters.AddWithValue("@Uom", uom);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@cost", cost);
            cmd.Parameters.AddWithValue("@brandid", brandid);
            cmd.Parameters.AddWithValue("@catid", catid);
            cmd.Parameters.AddWithValue("@subcatid", subcatid);
            cmd.Parameters.AddWithValue("@genderid", genderid);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@productdetail", prddetail);
            cmd.Parameters.AddWithValue("@matcare", matcare);
            cmd.Parameters.AddWithValue("@fd", fd);
            cmd.ExecuteNonQuery();
        }
        public void UpdateQuantity(string Query_,int Id,int Qty)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@ProductId", Id);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.ExecuteNonQuery();
        }
        public void InsertUnits(string Query_, string UnitName)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Name", UnitName);
            cmd.ExecuteNonQuery();
        }
        public void InsertImg(string Query_, int Id,string Name,string ext)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PID", Id);
            cmd.Parameters.AddWithValue("@Name",Name);
            cmd.Parameters.AddWithValue("@Extension", ext);
            cmd.ExecuteNonQuery();
        }

        public void InsertBrands(string Query_, string BName)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@BName", BName);
            cmd.ExecuteNonQuery();
        }
        public void InsertCat(string Query_, string CatName)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@CatName", CatName);
            cmd.ExecuteNonQuery();
        }
        public void InsertSubCat(string Query_, string SubCatName,int CatID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SubCatName", SubCatName);
            cmd.Parameters.AddWithValue("@CatID", CatID);
            cmd.ExecuteNonQuery();
        }
        public void InsertSize(string Query_, string Size,int Brandid ,int CatId,int SubCatId,int GenderId)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SizeName", Size);
            cmd.Parameters.AddWithValue("@BrandID", Brandid);
            cmd.Parameters.AddWithValue("@CatID", CatId);
            cmd.Parameters.AddWithValue("@SubCatID", SubCatId);
            cmd.Parameters.AddWithValue("@GenderID", GenderId);
            cmd.ExecuteNonQuery();
        }
        public void InsertSizeQty(string Query_, int Pid, int sizeid, int Qty)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Pid", Pid);
            cmd.Parameters.AddWithValue("@sizeid", sizeid);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.ExecuteNonQuery();
        }
        public void UpdateUnits(string Query_, string UnitName,int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@UomId", Id);
            cmd.Parameters.AddWithValue("@Name", UnitName);
            cmd.ExecuteNonQuery();
        }
        public void UpdateBrands(string Query_, string BName, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@BName", BName);
            cmd.ExecuteNonQuery();
        }
        public void UpdateCats(string Query_, string CatName, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@CatName", CatName);
            cmd.ExecuteNonQuery();
        }
        public void UpdateSubCats(string Query_, string CatName, int CatId,int SubCatID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@CatID", CatId);
            cmd.Parameters.AddWithValue("@SubCatName", CatName);
            cmd.Parameters.AddWithValue("@Id", SubCatID);

            cmd.ExecuteNonQuery();
        }
        public void UpdateSizes(string Query_, string SizeName,int BrandId ,int CatId, int SubCatID,int GenderId,int SizeID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SizeName", SizeName);
            cmd.Parameters.AddWithValue("@BrandID", BrandId);
            cmd.Parameters.AddWithValue("@CatID", CatId);
            cmd.Parameters.AddWithValue("@SubCatID", SubCatID);
            cmd.Parameters.AddWithValue("@GenderID", GenderId);
            cmd.Parameters.AddWithValue("@SizeID", SizeID);
            cmd.ExecuteNonQuery();
        }
        public void UpdatePassword(string Query_, string Password, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Pass", Password);
            cmd.ExecuteNonQuery();
        }
        public DataTable ResetPass(string Query_, string email)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable GetLoginId(string Query_, string email)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public void UpdateSecurityCode(string Query_, string Code)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Code", Code);
            cmd.ExecuteNonQuery();
        }
        public DataTable SelectSignin(string Query_, string UserName, string pass)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Email", UserName);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
       
        public DataTable CheckOldPass(string Query_, string UserName, string pass)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Username", UserName);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable CheckDupBrand(string Query_, string BName)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@BName", BName);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable CheckDupCat(string Query_, string CatName)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@CatName", CatName);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable CheckDupSubCat(string Query_, string SubCatName,int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SubCatName", SubCatName);
            cmd.Parameters.AddWithValue("@CatID", Id);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable CheckDupSize(string Query_, string Size, int BrandId,int CatId,int SubCatId,int GenderId)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SizeName", Size);
            cmd.Parameters.AddWithValue("@BrandID", BrandId);
            cmd.Parameters.AddWithValue("@CatID", CatId);
            cmd.Parameters.AddWithValue("@SubCatID", SubCatId);
            cmd.Parameters.AddWithValue("@GenderID", GenderId);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable GetBrandById(string Query_, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@BID", Id);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public SqlDataReader DataReaderwithparam(string Query_,int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataTable ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;
        }
    }
}