using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
	public partial class GR : System.Web.UI.Page
	{
        Purchase obj = new Purchase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["POID"] != null && Request.QueryString["GR"] != null)
            {
                GetData(Convert.ToInt32(Request.QueryString["POID"]), Convert.ToInt32(Request.QueryString["GR"]));
                dgvGRDet.Enabled = false;
            }
        }
            public void GetData(int POId, int GRId)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("select DocNo,Status from tblStockMove where StockMoveID=@Id", GRId))
            {
                sdr.Read();
                txtGRNo.Text = sdr["DocNo"].ToString();
                txtStatus.Text = sdr["Status"].ToString();


            }
            obj.CloseConnection();
            DataTable dt = obj.GetGRItem(POId);
            if (dt.Rows.Count > 0)
            {
                dgvGRDet.DataSource = dt;
                dgvGRDet.DataBind();

            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvGRDet.DataSource = dt1;
                dgvGRDet.DataBind();

            }
        
       }

        protected void btnpurtrack_ServerClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["POID"]);
            Response.Redirect("PO.aspx?Id=" + ID + "");
        }
    }
}