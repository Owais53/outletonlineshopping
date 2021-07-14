using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class OrderTrack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["SOID"]!=null && Request.QueryString["PID"] != null && Request.QueryString["SizeID"] != null)
                {
                    string SOId = Request.QueryString["SOID"];
                    string PId = Request.QueryString["PID"];
                    string SizeId = Request.QueryString["SizeID"];
                    int SOID = Convert.ToInt32(SOId);
                    int PID = Convert.ToInt32(PId);
                    int SizeID = Convert.ToInt32(SizeId);
                    BindProductTrack(SOID,PID,SizeID);
                }
                
            }
           
        }
        public void BindProductTrack(int SOID,int PID,int SizeID)
        {
            Sale obj = new Sale();
            DataTable dt = obj.GetOrderTrackbyUser(SOID,PID,SizeID);
            if (dt.Rows.Count > 0)
            {
                rptrTrack.DataSource = dt;
                rptrTrack.DataBind();
                foreach (RepeaterItem item in rptrTrack.Items)
                {

                    Label lblDate = item.FindControl("lblDate") as Label;
                    Label lblStatus = item.FindControl("lblStatus") as Label;
                    HtmlGenericControl divStockpick = item.FindControl("divStockpick") as HtmlGenericControl;
                    HtmlGenericControl divShipped = item.FindControl("divShipped") as HtmlGenericControl;
                    HtmlGenericControl divDev = item.FindControl("divDev") as HtmlGenericControl;
                    HtmlGenericControl divconf = item.FindControl("divconf") as HtmlGenericControl;


                    if (lblDate != null)
                    {
                        if (lblDate.Text != null)
                        {
                            DateTime DevDate = Convert.ToDateTime(lblDate.Text);
                            string formattedDate = DevDate.ToString("dddd, dd MMMM yyyy");
                            lblDate.Text = formattedDate;
                        }

                    }
                    if (lblStatus != null)
                    {
                        if(lblStatus.Text=="Stock Picking")
                        {
                            divStockpick.Attributes["class"] = "step active";
                        }
                        else if (lblStatus.Text == "Shipped")
                        {
                            divStockpick.Attributes["class"] = "step active";
                            divShipped.Attributes["class"] = "step active";
                        }
                        else if (lblStatus.Text == "Delivered")
                        {
                            divStockpick.Attributes["class"] = "step active";
                            divShipped.Attributes["class"] = "step active";
                            divDev.Attributes["class"] = "step active";
                        }
                        else
                        {
                            divconf.Attributes["class"] = "step active";
                        }
                    }
                               
                 }
            }
            else
            {
                DataTable dt1 = obj.GetOrderTrack(SOID,PID,SizeID);
                if (dt1.Rows.Count > 0)
                {
                    rptrTrack.DataSource = dt1;
                    rptrTrack.DataBind();
                    foreach (RepeaterItem item in rptrTrack.Items)
                    {

                        Label lblDate = item.FindControl("lblDate") as Label;

                        if (lblDate != null)
                        {
                            if (lblDate.Text != null)
                            {
                                DateTime DevDate = Convert.ToDateTime(lblDate.Text);
                                string formattedDate = DevDate.ToString("dddd, dd MMMM yyyy");
                                lblDate.Text = formattedDate;
                            }

                        }
                    }
                }
            }
        }
    }
}