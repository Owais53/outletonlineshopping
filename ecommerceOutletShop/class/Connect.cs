using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ecommerceOutletShop
{
    public class Connect
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
        public void ExecuteDeleteQueries(string Query_, int Id)
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
        public int selectIdwithparam(string Query_, int ID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", ID);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
        public int selectId(string Query_)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
        public void InsertLead(string Query_, int CampId, int UserId, string name, string address, string email, string leadsource, string contact, string status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Campid", CampId);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Leadsource", leadsource);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
        }
        public int InsertSignUP(string Query_, string UserName, string pass, string email, string fullname,bool isAdmin)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Name", UserName);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
           int Id= Convert.ToInt32(cmd.ExecuteScalar());
            return Id;
        }

        public DataTable SelectSignin(string Query_, string UserName, string pass)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Name", UserName);
            cmd.Parameters.AddWithValue("@pass", pass);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable SelectUser(string Query_, string UserName)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Name", UserName);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable CheckCode(string Query_, string Code)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Code",Code);
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
        public DataTable GetallProducts(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable GetUserIdbyName(string Query_,string Name)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Username", Name);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable GetLastNo(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public int GetLastId(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            var result = cmd.ExecuteScalar();
            int SoId= result == DBNull.Value ? 0 : Convert.ToInt32(result);
            return SoId;

        }
        public int CheckQty(string Query_,int PID,int SizeID,int Qty)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SizeID", SizeID);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            var result = cmd.ExecuteScalar();
            int SoQtyId = result == DBNull.Value ? 0 : Convert.ToInt32(result);
            return SoQtyId;

        }
        public DataTable GetSize(string Query_,  int BrandId, int CatId, int SubCatId, int GenderId)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
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
        public DataTable GetProductImagesorInfo(string Query_,int PID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PID",PID);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable GetProductImagesorInfo1(string Query_, int PID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            return dt;

        }
        public DataTable GetProductOrderHistory(string Query_, int UserID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            return dt;

        }
        
        public DataTable GetProductOrderHistoryStatus(string Query_, int UserID,string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@DevStatus", Status);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            return dt;

        }
        public DataTable GetProductOrderTrackingStatus(string Query_, int SOID,int PID,int SizeID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SID", SizeID);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            return dt;

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
        public DataTable ResetPassbymail(string Query_, string email)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable SelectPOLineitemforEmail(string Query_, int POID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POID", POID);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }

        public DataTable ResetPass(string Query_, string UserName, string pass)
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
        public void UpdatePassword(string Query_, string Password, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Pass", Password);
            cmd.ExecuteNonQuery();
        }
        public void UpdateLeadUserId(string Query_, string Email, int userId)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
        }
        public void UpdateProducts(string Query_, string ProductName, int uom, decimal price, decimal cost, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@ProductId", Id);
            cmd.Parameters.AddWithValue("@Name", ProductName);
            cmd.Parameters.AddWithValue("@Uom", uom);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@cost", cost);
            cmd.ExecuteNonQuery();
        }
        public void UpdateQuantity(string Query_, int Id, int Qty)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@ProductId", Id);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.ExecuteNonQuery();
        }
        public void Update(string Query_, int Id, string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
        }
        public void UpdateScheduledDeliveryStatus(string Query_, string Scheduleddevdate)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@schdevdate", Scheduleddevdate);
            cmd.ExecuteNonQuery();
        }
        public void UpdateQuantityMinus(string Query_, int PID,int SizeID, int Qty)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PId", PID);
            cmd.Parameters.AddWithValue("@Size", SizeID);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.ExecuteNonQuery();
        }
        public void InsertUnits(string Query_, string UnitName)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Name", UnitName);
            cmd.ExecuteNonQuery();
        }
        public void UpdateUnits(string Query_, string UnitName, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@UomId", Id);
            cmd.Parameters.AddWithValue("@Name", UnitName);
            cmd.ExecuteNonQuery();
        }
        public void UpdateScheduledDate(string Query_, int PID, int SizeID,DateTime SDD,int SOID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SizeID", SizeID);
            cmd.Parameters.AddWithValue("@SDD", SDD);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            cmd.ExecuteNonQuery();
        }
        public void UpdateStockSatusDev(string Query_, int SOID,string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            cmd.ExecuteNonQuery();
        }
        public void UpdateStockStatus(string Query_, string date)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader DataReaderwithparam(string Query_, int Id)
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
        public int InsertSO(string Query_, string SONO, int UserID, DateTime Createdon, int POref, string Status, string CustType)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SONO", SONO);
            cmd.Parameters.AddWithValue("@UserID",UserID);
            cmd.Parameters.AddWithValue("@Createdon", Createdon);
            cmd.Parameters.AddWithValue("@POref", POref);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@CustomerType", CustType);
            int pid = Convert.ToInt32(cmd.ExecuteScalar());
            return pid;
        }
        public int InsertPO(string Query_,int SOref, string PONO, DateTime Createdon, int VendorID, string Status)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOref", SOref);
            cmd.Parameters.AddWithValue("@PONO", PONO);
            cmd.Parameters.AddWithValue("@Createdon", Createdon);
            cmd.Parameters.AddWithValue("@VendorID", VendorID);
            cmd.Parameters.AddWithValue("@Status", Status);
            int poid = Convert.ToInt32(cmd.ExecuteScalar());
            return poid;
        }
        public int SelectSalesCount(string Query_, int UserID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
        public string SelectPONOforEmail(string Query_, int POID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POID", POID);
            string Poid = cmd.ExecuteScalar().ToString();
            return Poid;
        }
        public string SelectEmailifExits(string Query_, string Email)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Email", Email);
            var result = cmd.ExecuteScalar();
            string email = result == null ? null: result.ToString();
            return email;
        }
        public string SelectVendorEmail(string Query_, int POID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POID", POID);
            string email = cmd.ExecuteScalar().ToString();
            return email;
        }
        public string GetCustomerType(string Query_, int UserID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@UserID", UserID);          
            var result = cmd.ExecuteScalar();
            string custtype= result == null ? "New" :result.ToString();
            return custtype;
        }
        public int GetVendorIDbyProduct(string Query_, int PID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            int vid = Convert.ToInt32(cmd.ExecuteScalar());
            return vid;
        }
        public int GetPOIDbyVendor(string Query_, int VID,string createddate)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@VID", VID);
            cmd.Parameters.AddWithValue("@Createdon", createddate);
            int POid = Convert.ToInt32(cmd.ExecuteScalar());
            return POid;
        }
        public int GetCustLeadTime(string Query_, int PID, int SizeId)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SizeID", SizeId);
            int POid = Convert.ToInt32(cmd.ExecuteScalar());
            return POid;
        }
        public int GetDevLeadTime(string Query_, int VID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@VID", VID);
            int POid = Convert.ToInt32(cmd.ExecuteScalar());
            return POid;
        }
        public void InsertSODet(string Query_, int SOID,int PID,int SizeID,int Qty,string DevStatus,decimal price)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SizeID", SizeID);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@DevStatus", DevStatus);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.ExecuteNonQuery();
        }
        public void InsertPODet(string Query_, int POID, int PID,int SizeID,int Qty,decimal Price)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POID", POID);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SizeID", SizeID);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.ExecuteNonQuery();
        }
        public decimal SelectCostProd(string Query_, int PId, int qty)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PId", PId);
            cmd.Parameters.AddWithValue("@Qty", qty);
            decimal price = Convert.ToDecimal(cmd.ExecuteScalar());
            return price;
        }
        public void InsertPay(string Query_, int SOID,decimal TotalAmount,string CrCdNo,string DtCdNo,string PayType,string DelAdd,string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            cmd.Parameters.AddWithValue("@TotalAmt", TotalAmount);
            cmd.Parameters.AddWithValue("@CrCdNo", CrCdNo);
            cmd.Parameters.AddWithValue("@DtCdNo", DtCdNo);
            cmd.Parameters.AddWithValue("@PayType", PayType);
            cmd.Parameters.AddWithValue("@DelAdd", DelAdd);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
        }
        public int InsertStockMove(string Query_, string Docno,int SOID,int POID, string MoveType, string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@DocNO", Docno);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            cmd.Parameters.AddWithValue("@POID", POID);
            cmd.Parameters.AddWithValue("@MoveType", MoveType);
            cmd.Parameters.AddWithValue("@Status", Status);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }
        public void InsertStockMoveDet(string Query_, int SID, int PID, int SizeID, int Qty, string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@StockMoveID", SID);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SizeID", SizeID);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
        }

    }
}