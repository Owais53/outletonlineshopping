using System;
using System.Collections.Generic;
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
        
    }
}