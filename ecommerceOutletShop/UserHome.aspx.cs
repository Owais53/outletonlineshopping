using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!IsPostBack)
            {
                BindProductsRepeater();
                
                Sale objsale = new Sale();
                string date = DateTime.Now.Date.ToString("yyyy-MM-dd");
                objsale.UpdateStatusProductSale(date);
                objsale.UpdateStatusStocktoship(date);
                SqlDataReader dr = objsale.GetSOCount();
                SqlDataReader dr1=objsale.GetDeliveredProCount();
                while(dr.Read() && dr1.Read())
                {
                    int SOID = (int)dr.GetValue(0); 
                    int Count = (int)dr.GetValue(1);
                    int SOIDforDelivered = (int)dr1.GetValue(0);
                    int CountDelivered = (int)dr1.GetValue(1);
                    if(SOID==SOIDforDelivered && Count == CountDelivered)
                    {
                        //All Products Delivered
                        objsale.SOID = (int)SOID;
                        objsale.Status = "Delivered";
                        objsale.ChangeStockMoveStatus(objsale);
                    }
                    else if (SOID == SOIDforDelivered && CountDelivered==0)
                    {
                        //Products Not Delivered
                       
                    }
                    else if(SOID == SOIDforDelivered && Count != CountDelivered)
                    {
                        //Products Partilaay Delivered
                        objsale.SOID = (int)SOID;
                        objsale.Status = "Partially Delivered";
                        objsale.ChangeStockMoveStatus(objsale);
                    }

                }
                objsale.CloseConnection();
                objsale.UpdateStatusSOIfdev();
                objsale.UpdateStatusSOIfpardev();

                if (Session["Username"] != null)
                {
                    //lblname.Text = Session["Username"].ToString();
                }
                // else
                // {
                //     Response.Redirect("~/SignIn.aspx");
                // }
               // BindCartNumber();
               
            }

        }
        public void BindProductsRepeater()
        {
            int ID = Convert.ToInt32(Session["UserId"]);
            Sale obj = new Sale();
            DataTable dt = obj.GetOrderHistorybyUser(ID);
            if (dt.Rows.Count > 0)
            {
                rptrOrderHistory.DataSource = dt;
                rptrOrderHistory.DataBind();
                foreach (RepeaterItem item in rptrOrderHistory.Items)
                {
                    
                    Label lblStatus = item.FindControl("lblstatus") as Label;
                    
                    if (lblStatus != null)
                    {
                        if(lblStatus.Text=="Not Delivered")
                        {
                            lblStatus.CssClass = "label label-danger";
                        }
                        else if(lblStatus.Text=="Delivered")
                        {
                            lblStatus.CssClass = "label label-success";
                        }
                        else
                        {
                            lblStatus.CssClass = "label label-info";
                        }
                    }
                }
            }
            else
            {
                h4Noitems.InnerText = "Your Order History is Empty";
            }
           
        }

        protected void btndelivered_ServerClick(object sender, EventArgs e)
        {
            h4Noitems.InnerText = "";
            DataTable dataempty = new DataTable();
            rptrOrderHistory.DataSource = dataempty;
            rptrOrderHistory.DataBind();
            int ID = Convert.ToInt32(Session["UserId"]);
            Sale obj = new Sale();
            DataTable dt = obj.GetOrderHistorybyUserStatus(ID,"Delivered");
            if (dt.Rows.Count > 0)
            {
                rptrOrderHistory.DataSource = dt;
                rptrOrderHistory.DataBind();
                foreach (RepeaterItem item in rptrOrderHistory.Items)
                {

                    Label lblStatus = item.FindControl("lblstatus") as Label;

                    if (lblStatus != null)
                    {
                        if (lblStatus.Text == "Not Delivered")
                        {
                            lblStatus.CssClass = "label label-danger";
                        }
                        else if (lblStatus.Text == "Delivered")
                        {
                            lblStatus.CssClass = "label label-success";
                        }
                        else
                        {
                            lblStatus.CssClass = "label label-info";
                        }
                    }
                }
            }
            else
            {
                h4Noitems.InnerText = "Your Order History is Empty";
            }
            
        }

        protected void btnnotdelivered_ServerClick(object sender, EventArgs e)
        {
            h4Noitems.InnerText = "";
            DataTable dataempty = new DataTable();
            rptrOrderHistory.DataSource = dataempty;
            rptrOrderHistory.DataBind();
            int ID = Convert.ToInt32(Session["UserId"]);
            Sale obj = new Sale();
            DataTable dt = obj.GetOrderHistorybyUserStatus(ID, "Not Delivered");
            if (dt.Rows.Count > 0)
            {
                rptrOrderHistory.DataSource = dt;
                rptrOrderHistory.DataBind();
                foreach (RepeaterItem item in rptrOrderHistory.Items)
                {

                    Label lblStatus = item.FindControl("lblstatus") as Label;

                    if (lblStatus != null)
                    {
                        if (lblStatus.Text == "Not Delivered")
                        {
                            lblStatus.CssClass = "label label-danger";
                        }
                        else if (lblStatus.Text == "Delivered")
                        {
                            lblStatus.CssClass = "label label-success";
                        }
                        else
                        {
                            lblStatus.CssClass = "label label-info";
                        }
                    }
                }
            }
            else
            {
                h4Noitems.InnerText = "Your Order History is Empty";
            }
        }

        protected void btnAll_ServerClick(object sender, EventArgs e)
        {
            h4Noitems.InnerText = "";
            BindProductsRepeater();
        }
    }
}