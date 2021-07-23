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
            DataTable dt1 = obj.GetPOItemfromSO(SOId);
          //  int MinGiId = obj.GetMinGIID(SOId);
            if (dt1.Rows.Count>0)
            {    
               
                dgvGidet.DataSource = getFilteredDataForGIGrid(dt,dt1);
                dgvGidet.DataBind();

            }
            else if(dt.Rows.Count>0)
            {
                DataTable dt2 = new DataTable();
                dgvGidet.DataSource = dt;
                dgvGidet.DataBind();

            }
            else
            {
                DataTable dt2 = new DataTable();
                dgvGidet.DataSource = dt2;
                dgvGidet.DataBind();
            }
        }
        public DataTable getFilteredDataForGIGrid(DataTable dt1, DataTable dt2)
        {
            DataTable dtMerged =  (from a in dt1.AsEnumerable()
                                join b in dt2.AsEnumerable()                    
                                on new { A = a.Field<string>("ProductName"), B = a.Field<string>("SizeName") } equals new { A = b.Field<string>("ProductName"), B = b.Field<string>("SizeName") }
                                  into g
                                   where g.Count() > 0
                                   select a).CopyToDataTable();
            return dtMerged;
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
                int Id = (int)ViewState["ID"];
                obj.StockMoveID = Id;
                obj.StockMoveStatus = ddlStatus.SelectedValue;
                if (ddlStatus.SelectedValue == "Delivered")
                {
                    obj.ChangeStatusgidet(obj);
                    obj.ChangeStatussodet(obj);
                    int StockMoveID = obj.GetStockMoveId(Id);
                    int SOID = obj.GetSOId(StockMoveID);
                    int Countsodet = obj.GetSOdetCount(SOID);
                    int CountDeliveredSodetitem = obj.GetSOdetDevCount(SOID);
                    if (Countsodet == CountDeliveredSodetitem)
                    {
                        obj.ChangeStatusSoHeader(SOID);
                    }
                    

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
                ViewState["ID"] = Id;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalUpdateStatus", "$('#ModalUpdateStatus').modal();", true);


            }

        }
    }
}