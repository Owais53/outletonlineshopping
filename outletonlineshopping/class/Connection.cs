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
        public void ExecuteUpdateQueries(string Query_, int Id)
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
        public int InsertProducts(string Query_,string ProductName,int uom,decimal price,decimal cost,int brandid,int catid,int subcatid,int genderid,string desc,string prddetail,string matcare,int fd,int VendorID)
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
            cmd.Parameters.AddWithValue("@VID", VendorID);
            int pid= Convert.ToInt32(cmd.ExecuteScalar());           
            return pid;
        }
        

        public void UpdateProducts(string Query_, string ProductName, int uom, decimal price, decimal cost,int Id, int brandid, int catid, int subcatid, int genderid, string desc, string prddetail, string matcare, int fd,int VendorID)
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
            cmd.Parameters.AddWithValue("@VID", VendorID);
            cmd.ExecuteNonQuery();
        }
        public void UpdateQtySize(string Query_, int Id,int Qty,int reorder,int Cst)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@ProductId", Id);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Reorder", reorder);
            cmd.Parameters.AddWithValue("@Cst", Cst);
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
        public void InsertVendors(string Query_,string VName,string Contact,string Address,string Email)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@VName", VName);
            cmd.Parameters.AddWithValue("@Contact", Contact);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.ExecuteNonQuery();
        }
        public void UpdateVendors(string Query_, int VID,string VName, string Contact, string Address, string Email)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@VId", VID);
            cmd.Parameters.AddWithValue("@VName", VName);
            cmd.Parameters.AddWithValue("@Contact", Contact);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Email", Email);
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
        public void InsertSizeQty(string Query_, int Pid, int sizeid, int Qty,int ReorderPoint,int CstLeadtime)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Pid", Pid);
            cmd.Parameters.AddWithValue("@sizeid", sizeid);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Reorder", ReorderPoint);
            cmd.Parameters.AddWithValue("@Cst", CstLeadtime);
            cmd.ExecuteNonQuery();
        }
        public void InsertCampaign(string Query_, string Campname, string strtdaate, string enddate, decimal ExpRevenue, string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Campaignname", Campname);
            cmd.Parameters.AddWithValue("@strtdate", strtdaate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            cmd.Parameters.AddWithValue("@ExpRev", ExpRevenue);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
        }
        public void InsertLead(string Query_, int CampId, int UserId, string name, string address, string email,string leadsource,string contact,string status)
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
        public void InsertContacts(string Query_, int LeadId )
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
            cmd.ExecuteNonQuery();
        }
        public void UpateLeadStatus(string Query_, int LeadId,string leadStatus )
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
            cmd.Parameters.AddWithValue("@LeadStatus", leadStatus);
            cmd.ExecuteNonQuery();
        }
        public void EditCampaign(string Query_, int Id,string Campname, string enddate, decimal ExpRevenue)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Campaignname", Campname);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            cmd.Parameters.AddWithValue("@ExpRev", ExpRevenue);
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
        public void UpdateScheduledDevDate(string Query_, int Id, string SchDevDate)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@DevDate", SchDevDate);
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
        public void UpdateStatusGidet(string Query_,int Id, string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
        }
        public void UpdateStatussodet(string Query_, int Id, string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
        }
        public void UpdateStatusPo(string Query_, int Id,string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Status", Status);
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
        public DataTable CheckDuplicatVendor(string Query_, string Name)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@VName",Name);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable SelectInvoiceDet(string Query_, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
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
        public DataTable GetPOIfSoExists(string Query_, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", Id);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public int SelectDupProdSize(string Query_, int PID, int SizeID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SizeID", SizeID);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
        public int selectId(string Query_, int ID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", ID);         
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }

        public decimal SelectCostProd(string Query_, int PId,int qty)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PId", PId);
            cmd.Parameters.AddWithValue("@Qty", qty);
            decimal price = Convert.ToDecimal(cmd.ExecuteScalar());
            return price;
        }
        public decimal SelectTotalAmt(string Query_, int POId)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POId", POId);
            decimal price = Convert.ToDecimal(cmd.ExecuteScalar());
            return price;
        }
        public int InsertPO(string Query_, int SOref, string PONO, DateTime Createdon, int VendorID, string Status)
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
         public int InsertGR(string Query_, string DocNo, int SOID,int POID, string MoveType,  string Status)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@DocNo", DocNo);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            cmd.Parameters.AddWithValue("@POID", POID);
            cmd.Parameters.AddWithValue("@MoveType", MoveType);
            cmd.Parameters.AddWithValue("@Status", Status);
            int poid = Convert.ToInt32(cmd.ExecuteScalar());
            return poid;
        }
        public int InsertGI(string Query_, string DocNo, int SOID, int POID, string MoveType, string Status,int Gicount)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@DocNo", DocNo);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            cmd.Parameters.AddWithValue("@POID", POID);
            cmd.Parameters.AddWithValue("@MoveType", MoveType);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@GiCount", Gicount);
            int poid = Convert.ToInt32(cmd.ExecuteScalar());
            return poid;
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
        public DataTable CheckIfPOReceived(string Query_, int SOID)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            return dt;

        }
        public void UpdateQuantityPlus(string Query_, int PID, int SizeID, int Qty)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PId", PID);
            cmd.Parameters.AddWithValue("@Size", SizeID);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.ExecuteNonQuery();
        }
        public int GetLastId(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            var result = cmd.ExecuteScalar();
            int SoId = result == DBNull.Value ? 0 : Convert.ToInt32(result);
            return SoId;

        }
        public int GetGiCount(string Query_,int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            var result = cmd.ExecuteScalar();
            int GiCount = result == DBNull.Value ? 0 : Convert.ToInt32(result);
            return GiCount;

        }
        public string GetDate(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            var result = cmd.ExecuteScalar();
            string Date = result == null ? null : result.ToString();
            return Date;

        }
        public string GetDatewithparam(string Query_,int campid)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@CampId", campid);
            var result = cmd.ExecuteScalar();
            string Date = result == null ? null : result.ToString();
            return Date;

        }
        public decimal GetExpRevenuewithparam(string Query_, int campid)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@CampId", campid);
            var result = cmd.ExecuteScalar();
            decimal rev = result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            return rev;

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
        public void InsertPODet(string Query_, int POID, int PID, int SizeID, int Qty,decimal price)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POID", POID);
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@SizeID", SizeID);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.ExecuteNonQuery();
        }
        public int InsertVendorBill(string Query_, int POID, decimal totalprice)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POID", POID);
            cmd.Parameters.AddWithValue("@Price", totalprice);
            int Id =Convert.ToInt32(cmd.ExecuteScalar());
            return Id;
        }
        public int GetVendorPro(string Query_, string Pname)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Pname", Pname);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            return id;
        }
        public string GetEmailfromLead(string Query_, int Id)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            string email = cmd.ExecuteScalar().ToString();
            return email;
        }
        public int GetProductID(string Query_, string Pname)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Pname", Pname);
            string pid = cmd.ExecuteScalar().ToString();
            int id = Convert.ToInt32(pid);
            return id;
        }
        public int GetSizeID(string Query_, string Sname)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Sname", Sname);
            string sid = cmd.ExecuteScalar().ToString();
            int id = Convert.ToInt32(sid);
            return id;
        }
        public int SelectPoCount(string Query_, int SOID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", SOID);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
        public int SelectGRId(string Query_, int POID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POID", POID);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
        public int SelectGIId(string Query_, int POID)
        {

            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", POID);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }
        public DataTable GetSOLineItem(string Query_, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", Id);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public void UpdateQuantityMinus(string Query_, int PID, int SizeID, int Qty)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@PId", PID);
            cmd.Parameters.AddWithValue("@Size", SizeID);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.ExecuteNonQuery();
        }
        public void UpdateCampStatus(string Query_, int CampId,string Status)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@CampId", CampId);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.ExecuteNonQuery();
        }
        public DataTable GetPOLineItem(string Query_, int Id)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@POID", Id);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            DataTable dataum = ds.Tables[0];
            return dataum;

        }
        public DataTable GetGiLineItem(string Query_, int Id,int GiCount)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@SOID", Id);
            cmd.Parameters.AddWithValue("@GiCount", GiCount);
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
