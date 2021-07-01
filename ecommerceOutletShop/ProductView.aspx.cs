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
            if (Request.QueryString["PID"] != null)
            {
                if (!IsPostBack)
                {
                    BindProductViewImages();
                    BindProductViewInfo();
                }
            }
            else
            {
                Response.Redirect("~/ProductsAll.aspx");
            }
            
        }
        public void BindProductViewImages()
        {
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            DataTable dt = obj.GetProductViewImages(PID);
            rptrImage.DataSource = dt;
            rptrImage.DataBind();
        }
        public void BindProductViewInfo()
        {
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
            DataTable dt = obj.GetProductViewInfo(PID);
            rptrProdInfo.DataSource = dt;
            rptrProdInfo.DataBind();
        }
        protected string GetActiveImgClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

        protected void rptrProdInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
            {
                string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
                string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
                string SubCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;
                string GenderID = (e.Item.FindControl("hfGenderID") as HiddenField).Value;
                obj.BrandID = Convert.ToInt32(BrandID);
                obj.CatID= Convert.ToInt32(CatID);
                obj.SubCatID = Convert.ToInt32(SubCatID);
                obj.GenderID= Convert.ToInt32(GenderID);

                RadioButtonList rblSIze = e.Item.FindControl("rblSize") as RadioButtonList;
                DataTable dt = obj.GetSizeView(obj);
                rblSIze.DataSource = dt;
                rblSIze.DataTextField = "SizeName";
                rblSIze.DataValueField = "SizeID";
                rblSIze.DataBind();


            }
        }

        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            string SelectedSize = string.Empty;
            foreach(RepeaterItem item in rptrProdInfo.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rbList = item.FindControl("rblSize") as RadioButtonList;
                    SelectedSize = rbList.SelectedValue;
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "";
                }
            }
            if (SelectedSize != "")
            {
                int PID = Convert.ToInt32(Request.QueryString["PID"]);               
                if (Request.Cookies["CartPID"] != null)
                {

                    string CookieID = Request.Cookies["CartPID"].Value.Split('=')[1];
                    CookieID = CookieID + "," + PID + "-" + SelectedSize;
                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = PID.ToString();
                    CartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProducts);

                }
                else
                {
                    HttpCookie CartProducts = new HttpCookie("CartPID");
                    CartProducts.Values["CartPID"] = PID.ToString()+"-"+SelectedSize;
                    CartProducts.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProducts);
                }
                Response.Redirect("~/ProductView.aspx?PID="+PID);
            }
            else
            {
                foreach (RepeaterItem item in rptrProdInfo.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var rbList = item.FindControl("rblSize") as RadioButtonList;
                        SelectedSize = rbList.SelectedValue;
                        var lblError = item.FindControl("lblError") as Label;
                        lblError.Text = "Please Select a Size";
                    }
                }
            }
        }
    }
}