using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class ProductView : System.Web.UI.Page
    {
        Ecomm obj = new Ecomm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductViewImages();
            }
        }
        public void BindProductViewImages()
        {
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            DataTable dt = obj.GetProductViewImages(PID);
            rptrImage.DataSource = dt;
            rptrImage.DataBind();
        }
    }
}