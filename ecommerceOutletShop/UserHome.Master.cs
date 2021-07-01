using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class UserHome1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    lblname.Text = Session["Username"].ToString();
                }
                // else
                // {
                //     Response.Redirect("~/SignIn.aspx");
                // }
                

            }
            BindCartNumber();
        }
        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int productCount = ProductArray.Length;
                pCount.InnerText = productCount.ToString();
                
            }
            else
            {
                pCount.InnerText = 0.ToString();
            }
        }

    }
}