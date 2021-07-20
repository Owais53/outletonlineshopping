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
	public partial class SO : System.Web.UI.Page
	{
        Sale obj = new Sale();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.QueryString["Id"] != null)
            {   int ID = Convert.ToInt32(Request.QueryString["Id"]);
                GetDataToEdit(ID);
                GetCountPO(ID);
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
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select * from tblSO where SOID=@Id", Id))
            {
                sdr.Read();
                txtSONo.Text = sdr["SONo"].ToString();
                txtorderdate.Text = sdr["Createdon"].ToString();
                txtStatus.Text = sdr["Status"].ToString();
                txtCustType.Text = sdr["CustomerType"].ToString();
              

            }
            obj.CloseConnection();
            DataTable dt = obj.GetSOItem(Id);
            if (dt.Rows.Count > 0)
            {
                dgvSODet.DataSource = dt;
                dgvSODet.DataBind();
               
            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvSODet.DataSource = dt1;
                dgvSODet.DataBind();
                
            }
        }
        public void GetCountPO(int Id)
        {
            Purchase objpo = new Purchase();
            int Count=objpo.GetPOCount(Id);
            spanCountpo.InnerText = Count.ToString();
        }
        protected void btnpotrack_ServerClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["Id"]);
            Response.Redirect("ListPO.aspx?Id="+ID+"");
        }
        public string GenerateNoGI(string GIno)
        {
            Inventory objinv = new Inventory();
            string a = "";
            int SoID = objinv.GetLastSmoveSoId();
            if (SoID > 0)
            {
                DataTable dt = objinv.GetLastGINo();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string lastNo = string.Empty;
                        foreach (DataRow row in dt.Rows)
                        {
                            lastNo = row["DocNo"].ToString();

                        }
                        string LastNo = lastNo.Split('-')[1].ToString();
                        int No = Convert.ToInt32(LastNo);
                        int Num = No + 1;
                        a = GIno + "-000" + Num;

                    }
                }
            }
            else
            {
                a = GIno + "-0001";
            }
            return a;

        }
        protected void btngi_ServerClick(object sender, EventArgs e)
        {
            Inventory objinv = new Inventory();
            Purchase obj = new Purchase();
            objinv.DocNo = GenerateNoGI("GI");
            objinv.POID = 0;
            objinv.SOID = Convert.ToInt32(Request.QueryString["Id"]);
            objinv.MoveType = "Stock Out";
            objinv.Status = "Stock Picking";

            if (Request.QueryString["Id"] != null)
            {
                int GIID = objinv.CreateGR(objinv);
                int SOID = Convert.ToInt32(Request.QueryString["Id"]);
                DataTable dt = objinv.GetPOItemForIssue(SOID);
                foreach (DataRow row in dt.Rows)
                {
                    objinv.PID = (int)row["PID"];
                    objinv.SizeID = (int)row["SizeID"];
                    objinv.Quantity = (int)row["Quantity"];
                    objinv.ChangeQuantityMinus(objinv);
                }
                Response.Redirect("GI.aspx?SOID=" + SOID + "&GR=" + GIID + "");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Good Receipt can not be created while Creating Purchase Order');", true);
            }
        }
    }
}