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
            Sale objsale = new Sale();
            string SelectedSize = string.Empty;
            string SelectedQty = string.Empty;
            int UserId = Convert.ToInt32(Session["UserId"]);
            int LeadId = objsale.GetLeadIdfromUserId(UserId);
            if (LeadId > 0)
            {
                int ContactId = objsale.GetContactIdfromLeadId(LeadId);
                if (ContactId == 0)
                {
                    objsale.CreateContact(LeadId);
                    objsale.LeadId = LeadId;
                    objsale.LeadStatus = "Qualified";
                    objsale.ChangeLeadStatus(objsale);
                }
            }
           
            foreach (RepeaterItem item in rptrProdInfo.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rbList = item.FindControl("rblSize") as RadioButtonList;
                    SelectedSize = rbList.SelectedValue;
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "";
                    var txtQty = item.FindControl("txtQty") as TextBox;
                    SelectedQty = txtQty.Text;
                }
            }
            string User = Session["Username"].ToString();
            if (SelectedSize != "")
            {
                
                int newQty = 0;
                int PID = Convert.ToInt32(Request.QueryString["PID"]);               
                if (Request.Cookies["CartP"] != null)
                {
                    
                    string CookiePID = Request.Cookies["CartP"].Value.Split('=')[1];
                    string CookiePIDWithQty = Request.Cookies["CartPID"].Value.Split('=')[1];
                    string CookiePIDOld = string.Empty;
                    string CookiePIDWithQtyOld = string.Empty;
                    CookiePIDOld = CookiePID;
                    CookiePIDWithQtyOld = CookiePIDWithQty;

                    CookiePID = CookiePID + "," + PID + "-" + SelectedSize + "-" + User;
                    CookiePIDWithQty =CookiePIDWithQty+","+ PID + "-" + SelectedSize + "-" + SelectedQty+"-"+User;
                    

                    List<string> CookiePIDList = CookiePIDOld.Split(',').Where(i => i != string.Empty).ToList();
                    string currentProduct = PID + "-" + SelectedSize + "-" + User;
                    string curProd = PID + "-" + SelectedSize;
                    var checkduplicateProwithSize = CookiePIDList.Where(x => x == currentProduct).FirstOrDefault();
                    if (checkduplicateProwithSize != null)
                    {
                        List<string> CookiePIDWithQtyList = CookiePIDWithQtyOld.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
                        var checkduplicatetoremoveupdate = CookiePIDWithQtyList.Where(i => i.Contains(curProd)).FirstOrDefault();
                        if (checkduplicatetoremoveupdate == null)
                        {

                        }
                        else
                        {
                            CookiePIDWithQtyList.Remove(checkduplicatetoremoveupdate.ToString());
                             string CookiePIDWithQtyUpdated = String.Join(",", CookiePIDWithQtyList.ToArray());
                            string OldQty = checkduplicatetoremoveupdate.Split('-')[2].ToString();
                            int NewQty = int.Parse(OldQty) + int.Parse(SelectedQty);
                            if (CookiePIDWithQtyUpdated == "")
                            {
                                CookiePIDWithQty = PID + "-" + SelectedSize + "-" + NewQty + "-" + User;
                            }
                            else
                            {
                                CookiePIDWithQty = CookiePIDWithQtyUpdated + "," + PID + "-" + SelectedSize + "-" + NewQty + "-" + User;
                            }
                            
                           
                            HttpCookie CartProductswithQty = new HttpCookie("CartPID");
                            CartProductswithQty.Values["CartPID"] = CookiePIDWithQty.ToString();
                            CartProductswithQty.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(CartProductswithQty);
                        }
                        

                    }
                    else
                    {
                        HttpCookie CartProductswithQty = new HttpCookie("CartPID");
                        CartProductswithQty.Values["CartPID"] = CookiePIDWithQty.ToString();
                        CartProductswithQty.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(CartProductswithQty);

                        HttpCookie CartProducts = new HttpCookie("CartP");
                        CartProducts.Values["CartP"] = CookiePID.ToString();
                        CartProducts.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(CartProducts);
                    }
                   

                }
                else
                {
                    HttpCookie CartProductswithQty = new HttpCookie("CartPID");                
                    CartProductswithQty.Values["CartPID"] = PID.ToString()+ "-" +SelectedSize + "-" + SelectedQty+"-"+User;           
                    CartProductswithQty.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(CartProductswithQty);

                    HttpCookie CartProducts = new HttpCookie("CartP");
                    CartProducts.Values["CartP"] = PID.ToString() + "-" + SelectedSize + "-" + User;
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