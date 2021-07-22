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
    public partial class CustomerInvoice : System.Web.UI.Page
    {
        Sale obj = new Sale();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                GetData(Convert.ToInt32(Request.QueryString["Id"]));
                
            }
        }
        public void GetData(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("select so.SONo,TotalAmount,PaymentType from tblPay p inner join tblSO so on p.SOID=so.SOID where PaymentId=@Id", Id))
            {
                sdr.Read();
                txtSono.Text = sdr["SONo"].ToString();
                txttotalAmt.Text = sdr["TotalAmount"].ToString();
                txtpaytype.Text = sdr["PaymentType"].ToString();


            }
            obj.CloseConnection();
            DataTable dt = obj.GetInvoiceDet(Id);
            if (dt.Rows.Count > 0)
            {
                dgvCIDet.DataSource = dt;
                dgvCIDet.DataBind();

            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvCIDet.DataSource = dt1;
                dgvCIDet.DataBind();

            }
        }

       

        protected void btnsocitrack_ServerClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["Id"]);
            int SOID = obj.GetSOId(ID);
            Response.Redirect("SO.aspx?Id=" + SOID + "");
        }
    }
}