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
    public partial class GI : System.Web.UI.Page
    {
        Purchase obj = new Purchase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SOID"] != null && Request.QueryString["GI"] != null)
            {
                GetData(Convert.ToInt32(Request.QueryString["SOID"]), Convert.ToInt32(Request.QueryString["GI"]));
                dgvGIDet.Enabled = false;
            }
        }
        public void GetData(int SOId, int GIId)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("select DocNo,Status from tblStockMove where StockMoveID=@Id", GIId))
            {
                sdr.Read();
                txtGINo.Text = sdr["DocNo"].ToString();
                txtStatus.Text = sdr["Status"].ToString();


            }
            obj.CloseConnection();
            DataTable dt = obj.GetPOItemfromSO(SOId);
            if (dt.Rows.Count > 0)
            {
                dgvGIDet.DataSource = dt;
                dgvGIDet.DataBind();

            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvGIDet.DataSource = dt1;
                dgvGIDet.DataBind();

            }
        }
    }
}