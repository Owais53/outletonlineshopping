using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class ProductsAll : System.Web.UI.Page
    {
        Ecomm obj = new Ecomm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductsRepeater();
            }
        }
        public void BindProductsRepeater()
        {
            DataTable dt = obj.GetAllProd();
            rptrProducts.DataSource = dt;
            rptrProducts.DataBind();
        }
    }
}