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
        public void InsertSignUP(string Query_, string UserName, string pass, string email, string fullname,bool isAdmin)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.Parameters.AddWithValue("@Name", UserName);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@isAdmin", isAdmin);
            cmd.ExecuteNonQuery();
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
    }
}