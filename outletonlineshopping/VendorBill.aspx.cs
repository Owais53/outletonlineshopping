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
    public partial class VendorBill : System.Web.UI.Page
    {
        Purchase obj = new Purchase();
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
            using (SqlDataReader sdr = obj.DataReaderwithparam("select po.PONo,TotalAmount from tblVendorBill vb inner join tblPO po on vb.POID=po.POID where Id=@Id", Id))
            {
                sdr.Read();
                txtPono.Text = sdr["PONo"].ToString();
                txttotalAmt.Text = sdr["TotalAmount"].ToString();
              


            }
            obj.CloseConnection();
            DataTable dt = obj.GetVendorBillDet(Id);
            if (dt.Rows.Count > 0)
            {
                dgvVBDet.DataSource = dt;
                dgvVBDet.DataBind();

            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvVBDet.DataSource = dt1;
                dgvVBDet.DataBind();

            }
        }
        protected void btnpovbtrack_ServerClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["Id"]);
            int POID = obj.GetPOId(ID);
            Response.Redirect("PO.aspx?Id=" + POID + "");
        }
    }
}