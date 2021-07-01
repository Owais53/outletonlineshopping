using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class Cart : System.Web.UI.Page
    {
        Ecomm obj = new Ecomm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        public void BindProductCart()
        {  
            if (Request.QueryString["CartPID"] != null)
            {
                DataTable dt = new DataTable();
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                if (CookieDataArray.Length > 0)
                {
                    h4Noitems.InnerText="My Cart("+CookieDataArray.Length+" items)";
                    for(int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string PID = CookieDataArray[i].ToString().Split('-')[0];
                        string SizeID = CookieDataArray[i].ToString().Split('-')[1];
                        dt=obj.GetProductInfoSize(Convert.ToInt32(PID), Convert.ToInt32(SizeID));
                    }
                }
                rptrCartProducts.DataSource = dt;
                rptrCartProducts.DataBind();
            }
            else
            {
            }
        }
        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnBuy_Click(object sender, EventArgs e)
        {

        }
    }
}