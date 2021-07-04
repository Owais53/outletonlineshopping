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
    public partial class Cart : System.Web.UI.Page
    {
        Ecomm obj = new Ecomm();
       // string ConnectionString = "Data source=.; initial catalog=outlet; integrated security=true;";
        SqlConnection con=  new SqlConnection("Data source=.; initial catalog=outlet; integrated security=true;");
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductCart();
            }
        }
        public void BindProductCart()
        {  
            if (Request.Cookies["CartPID"] != null)
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                int carttotal = 0;
                string SessionName = string.Empty;
                string currentSession = Session["Username"].ToString();
                string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] CookieDataArray = CookieData.Split(',');
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    SessionName = CookieDataArray[i].ToString().Split('-')[3];

                    if (CookieDataArray.Length > 0 && currentSession == SessionName)
                    {
                        int ItemsCount = 0;
                        if (currentSession == SessionName)
                        {
                            ItemsCount++;
                            h4Noitems.InnerText = "My Cart(" + ItemsCount + " items)";
                        }
                        else
                        {
                            h4Noitems.InnerText = h4Noitems.InnerText + 0;
                            h4Noitems.InnerText = "Your Shopping Cart is Empty";
                            divpriceDetail.Visible = false;
                        }
                     
                       
                            string PID = CookieDataArray[i].ToString().Split('-')[0];
                            string SizeID = CookieDataArray[i].ToString().Split('-')[1];
                            string Qty = CookieDataArray[i].ToString().Split('-')[2];

                            int SizeId = Convert.ToInt32(SizeID);
                            int QtyPrd = Convert.ToInt32(Qty);
                            string Query_ = "select A.*,[dbo].getSizeName(" + SizeId + ") as SizeNamee," + SizeId + " as SizeIDD," + QtyPrd + " as Qty,A.SalesPrice*" + QtyPrd + " as SalesPricee,SizeData.Name,SizeData.*,Extension from tblProduct A cross apply(select top 1 B.Name,Extension from tblProductImages B where B.PID=A.ProductId)SizeData where ProductId=@PID";
                            SqlCommand cmd = new SqlCommand(Query_, con);
                            cmd.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                            SqlDataAdapter dr = new SqlDataAdapter(cmd);
                            dr.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                carttotal += Convert.ToInt32(row["SalesPricee"]);
                            }
                        }
                           
                           
                    }
                   
                       
                    
                }
                rptrCartProducts.DataSource = dt;
                rptrCartProducts.DataBind();
                divpriceDetail.Visible = true;
                spancartTotal.InnerText = carttotal.ToString();
            }
            else
            {
                h4Noitems.InnerText = "Your Shopping Cart is Empty";
                divpriceDetail.Visible = false;
                
            }
        }
        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {
            string CookiePIDWithQty=Request.Cookies["CartPID"].Value.Split('=')[1];
            string CookiePID = Request.Cookies["CartP"].Value.Split('=')[1];
            string User = Session["Username"].ToString();
            Button btn = (Button)(sender);

            string PIDWithQty = btn.CommandArgument +"-"+ User;
            string PID=PIDWithQty.ToString().Split('-')[0];
            string SizeID = PIDWithQty.ToString().Split('-')[1];
            string PIDSize = PID + "-" + SizeID + "-" + User;


            List<string> CookiePIDWithQtyList = CookiePIDWithQty.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            List<string> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            CookiePIDWithQtyList.Remove(PIDWithQty);
            CookiePIDList.Remove(PIDSize);
            string CookiePIDWithQtyUpdated = String.Join(",", CookiePIDWithQtyList.ToArray());
            string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());

            if (CookiePIDWithQtyUpdated == "" && CookiePIDUpdated=="")
            {
                HttpCookie CartProductsWithQty = Request.Cookies["CartPID"];
                CartProductsWithQty.Values["CartPID"] = null;
                CartProductsWithQty.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProductsWithQty);

                HttpCookie CartProducts = Request.Cookies["CartP"];
                CartProducts.Values["CartP"] = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);

            }
            else
            {
                HttpCookie CartProductsWithQty = Request.Cookies["CartPID"];
                CartProductsWithQty.Values["CartPID"] = CookiePIDWithQtyUpdated;
                CartProductsWithQty.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProductsWithQty);

                HttpCookie CartProducts = Request.Cookies["CartP"];
                CartProducts.Values["CartP"] = CookiePIDUpdated;
                CartProducts.Expires = DateTime.Now.AddDays(30);              
                Response.Cookies.Add(CartProducts);
            }
            Response.Redirect("~/Cart.aspx");
        }
        protected void btnBuy_Click(object sender, EventArgs e)
        {

        }

       
    }
}