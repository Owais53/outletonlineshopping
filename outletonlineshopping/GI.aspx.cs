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
        Inventory objinv = new Inventory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["SOID"] != null && Request.QueryString["GI"] != null)
            {
                GetData(Convert.ToInt32(Request.QueryString["SOID"]), Convert.ToInt32(Request.QueryString["GI"]));
               // dgvGIDet.Enabled = false;
              
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
            DataTable dt = obj.GetGIItemfromSO(SOId);
            if (dt.Rows.Count > 0)
            {
                dgvGidet.DataSource = dt;
                dgvGidet.DataBind();

            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvGidet.DataSource = dt1;
                dgvGidet.DataBind();

            }
        }

        protected void btnsaletrack_ServerClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["SOID"]);
            Response.Redirect("SO.aspx?Id=" + ID + "");
        }

        protected void btnsavestatus_Click(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please Select Status');", true);
            }
            else
            {
                Inventory obj = new Inventory();
                obj.StockMoveID = (int)ViewState["StockMoveID"];
                obj.StockMoveStatus = ddlStatus.SelectedValue;
                if (ddlStatus.SelectedValue == "Delivered")
                {
                    obj.ChangeStatusgidet(obj);
                    obj.ChangeStatussodet(obj);
                    obj.ChangeStatusSoHeader();

                }
                else
                {
                    obj.ChangeStatusgidet(obj);
                }
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Status Updated');", true);
            }
        }

        protected void dgvGidet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Add")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                ViewState["StockMoveID"] = Id;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalUpdateStatus", "$('#ModalUpdateStatus').modal();", true);


            }

        }
    }
}