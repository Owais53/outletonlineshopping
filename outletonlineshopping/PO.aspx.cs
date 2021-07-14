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
	public partial class PO : System.Web.UI.Page
	{
        Purchase obj = new Purchase();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.QueryString["Id"] != null)
            {
                GetDataToEdit(Convert.ToInt32(Request.QueryString["Id"]));
                DisableControls(Page, false);
            }
        }
        protected void DisableControls(Control parent, bool State)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)(c)).Enabled = State;
                }

                DisableControls(c, State);
            }
        }
        public void GetDataToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("select po.SOref,po.POID,po.PONo,so.SONo,po.Createdon,v.VendorName,po.Status from tblPO po inner join tblSO so on po.SOref=so.SOID inner join tblVendor v on po.VendorID=v.VendorID where po.POID=@Id", Id))
            {
                sdr.Read();
                txtSoref.Text = sdr["SONo"].ToString();
                txtPONo.Text = sdr["PONo"].ToString();
                txtorderdate.Text = sdr["Createdon"].ToString();
                txtStatus.Text = sdr["Status"].ToString();
                txtVendor.Text = sdr["VendorName"].ToString();
                hdsoid.Value = sdr["SOref"].ToString();

            }
            obj.CloseConnection();
            DataTable dt = obj.GetPOItem(Id);
            if (dt.Rows.Count > 0)
            {
                dgvPODet.DataSource = dt;
                dgvPODet.DataBind();

            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvPODet.DataSource = dt1;
                dgvPODet.DataBind();

            }
        }

        protected void btnsaletrack_ServerClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(hdsoid.Value);
            Response.Redirect("SO.aspx?Id=" + ID + "");
        }
    }
}