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
        Sale objSale = new Sale();
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
           string CustType= objSale.GetCustomerTypebyuser(UserId);
            if (CustType == "New")
            {
                rblPayType.Items[0].Attributes.CssStyle.Add("display", "none");
            }
            else
            {
                rblPayType.Items[0].Attributes.CssStyle.Add("display", "block");
            }
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
                spancartTotal.InnerText = "Rs." +carttotal.ToString();
                spanTotalAmt.InnerText = "Rs." + carttotal.ToString();
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
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PayModal", "$('#PayModal').modal();", true);
            upModalPay.Update();
        }

        protected void rblPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblPayType.SelectedValue == "0")
            {
                txtCreditCard.Visible = true;
                txtDebitCard.Visible = false;
                lblCreditcd.Visible = true;
                lblDebitcd.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PayModal", "$('#PayModal').modal();", true);
                upModalPay.Update();
                
            }
            else if (rblPayType.SelectedValue == "1")
            {
                txtDebitCard.Visible = true;
                txtCreditCard.Visible = false;
                lblCreditcd.Visible = false;
                lblDebitcd.Visible = true;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PayModal", "$('#PayModal').modal();", true);
                upModalPay.Update();
            }
            else
            {
                txtDebitCard.Visible = false;
                txtCreditCard.Visible = false;
                lblCreditcd.Visible = false;
                lblDebitcd.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "PayModal", "$('#PayModal').modal();", true);
                upModalPay.Update();
            }
        }
        public string GenerateNoSO(string Sono)
        {
            Sale objsale = new Sale();
            string a = "";
            int SoID = objsale.GetLastSOId();
            if (SoID > 0)
            {
                DataTable dt = objsale.GetLastSONo();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string lastNo = string.Empty;
                        foreach (DataRow row in dt.Rows)
                        {
                            lastNo = row["SONo"].ToString();

                        }
                        string LastNo = lastNo.Split('-')[1].ToString();
                        int No = Convert.ToInt32(LastNo);
                        int Num = No + 1;
                        a = Sono + "-000" + Num;

                    }
                }
            }
            else
            {
                a = Sono + "-0001";
            }            
            return a;

        }
        public string GenerateNoPO(string Pono)
        {
            Purchase objpur = new Purchase();
            string a = "";
            int PoID = objpur.GetLastPOId();
            if (PoID > 0)
            {
                DataTable dt = objpur.GetLastPONo();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string lastNo = string.Empty;
                        foreach (DataRow row in dt.Rows)
                        {
                            lastNo = row["PONo"].ToString();

                        }
                        string LastNo = lastNo.Split('-')[1].ToString();
                        int No = Convert.ToInt32(LastNo);
                        int Num = No + 1;
                        a = Pono + "-000" + Num;

                    }
                }
            }
            else
            {
                a = Pono + "-0001";
            }
            return a;

        }
        private bool isformvalidPay()
        {
            if (rblPayType.SelectedValue != "0" && rblPayType.SelectedValue != "1" && rblPayType.SelectedValue != "2")            
            {
                lblerror.Text = "Please Select Payment Method";
                upModalPay.Update();
                return false;
            }
            else if (txtdeladdress.Text == "")
            {
                lblerror.Text = "Please Enter Delivery Address";
                upModalPay.Update();
                return false;
            }
         
            return true;
        }
        public void SavePOItemsCookie(string SaleProduct)
        {
            HttpCookie CartProductsWithQty = new HttpCookie("POCartPID");
            if (Request.Cookies["POCartPID"] != null)
            {
                string POCookiePID = Request.Cookies["POCartPID"].Value.Split('=')[1];
                POCookiePID = POCookiePID + "," + SaleProduct;
                HttpCookie CartProducts = Request.Cookies["POCartPID"];
                CartProducts.Values["POCartPID"] = POCookiePID.ToString();
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            else
            {
                string POCookiePID = SaleProduct;
               
                CartProductsWithQty.Values["POCartPID"] = POCookiePID.ToString();
                CartProductsWithQty.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProductsWithQty);
            }
                     

        }
        protected void btnpay_Click(object sender, EventArgs e)
        {
            Sale objsale = new Sale();
            if (Request.Cookies["CartPID"] != null)
            {
                string currentSession = Session["Username"].ToString();
                string SessionName = string.Empty;
                string Sessionname = string.Empty;
                string CookiePIDWithQty = Request.Cookies["CartPID"].Value.Split('=')[1];
                string CookiePID = Request.Cookies["CartP"].Value.Split('=')[1];

                string[] CookieDataArray = CookiePIDWithQty.Split(',');
                List<string> CookiePIDListCheck = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i.Contains(currentSession)).ToList();

                if (CookiePIDListCheck.Count >0)
                {
                    DataTable dt = objsale.GetUserId(currentSession);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            objsale.UserID = Convert.ToInt32(row["LoginId"]);
                        }

                    }
                    string SoNo = GenerateNoSO("SO");
                    objsale.SONo = SoNo;
                    objsale.Createdon = DateTime.Now;
                    objsale.POref = 0;
                    objsale.Status = "To Deliver";
                   
                    int UserId = Convert.ToInt32(Session["UserId"]);
                   
                    int Countpurofuser=objsale.CountSOofUser(UserId);
                    if (Countpurofuser >= 3)
                    {
                        objsale.CustomerType = "Regular";
                    }
                    else
                    {
                        objsale.CustomerType = "New";
                    }
                    
                    int SOID = objsale.CreateSO(objsale);
                    if (SOID > 0)
                    {
                        objsale.SOID = SOID;

                        int PID = 0;
                        int Qty = 0;
                        int Size = 0;
                        string CookiePIDWithQtyUpdated = string.Empty;
                        string CookiePIDUpdated = string.Empty;
                        ViewState["EmptyCookiePO"] = "yes";
                        for (int i = 0; i < CookieDataArray.Length; i++)
                        {
                            string CookiePIDWithQtynew = Request.Cookies["CartPID"].Value.Split('=')[1];
                            string CookiePIDnew = Request.Cookies["CartP"].Value.Split('=')[1];

                            SessionName = CookieDataArray[i].ToString().Split('-')[3];
                            if (currentSession == SessionName)
                            {
                                string Product = CookieDataArray[i].ToString().Split('-')[0];
                                PID = Convert.ToInt32(Product);
                                string Quantity = CookieDataArray[i].ToString().Split('-')[2];
                                Qty = Convert.ToInt32(Quantity);
                                string size = CookieDataArray[i].ToString().Split('-')[1];
                                Size = Convert.ToInt32(size);
                                objsale.PID = PID;
                                objsale.Quantity = Qty;
                                objsale.CreateSODet(objsale);
                                string PurchasedProductWithQty = PID + "-" + Size + "-" + Qty + "-" + SessionName;
                                string PurchasedProduct = PID + "-" + Size + "-" + SessionName;
                                List<string> CookiePIDWithQtyList = CookiePIDWithQtynew.Split(',').Select(x => x.Trim()).Where(x => x!= string.Empty).ToList();
                                List<string> CookiePIDList = CookiePIDnew.Split(',').Select(x => x.Trim()).Where(x => x!= string.Empty).ToList();
                                CookiePIDWithQtyList.Remove(PurchasedProductWithQty);
                                CookiePIDList.Remove(PurchasedProduct);
                                CookiePIDWithQtyUpdated = String.Join(",", CookiePIDWithQtyList.ToArray());
                                CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
                                if (CookiePIDWithQtyUpdated == "" && CookiePIDUpdated == "")
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
                                int PrdQtyID = objsale.CheckQuantity(PID,Size,Qty);

                                if (PrdQtyID > 0)
                                {                                 
                                    SavePOItemsCookie(PurchasedProductWithQty);
                                    ViewState["CreatePO"] = true;
                                }
                                else
                                {
                                    Inventory objinv = new Inventory();
                                    objinv.SOID = SOID;
                                    objinv.StockMoveStatus = "Stock Picking";
                                    objinv.MoveType = "Stock Out";
                                    objinv.CreateStockMove(objinv);

                                    objinv.PID = PID;
                                    objinv.SizeID = Size;
                                    objinv.Quantity = Qty;
                                    objinv.ChangeQuantityMinus(objinv);


                                }
                            }
                            



                        }

                        //PO Code
                        if (ViewState["CreatePO"] != null)
                        {
                            //PO Header
                         
                           
                            string POCookiePID = Request.Cookies["POCartPID"].Value.Split('=')[1];
                            string[] POCookieDataArray = POCookiePID.Split(',');
                            int POPId = 0;
                            int POSize = 0;
                            int POQty = 0;
                            ViewState["FirstPO"] = "yes";
                            ViewState["CreatenewPO"] = "no";
                            for (int i = 0; i < POCookieDataArray.Length; i++)
                            {
                                string Product = POCookieDataArray[i].ToString().Split('-')[0];
                                POPId = Convert.ToInt32(Product);
                                string Quantity = POCookieDataArray[i].ToString().Split('-')[2];
                                POQty = Convert.ToInt32(Quantity);
                                string size = POCookieDataArray[i].ToString().Split('-')[1];
                                POSize = Convert.ToInt32(size);
                                string SessionnameforPO = POCookieDataArray[i].ToString().Split('-')[3];

                               
                                Purchase objpur = new Purchase();
                                objpur.PID = POPId;
                                objpur.Quantity = POQty;

                                int VID = objpur.GetVendorId(POPId);
                                if (VID > 0)
                                {
                                                                      
                                    int POID = 0;
                                    if (ViewState["FirstPO"].ToString() == "yes")
                                    {
                                        objpur.SOref = SOID;
                                        objpur.PONo = GenerateNoPO("PO");
                                        objpur.Createdon = DateTime.Now;
                                        objpur.VendorId = VID;
                                        objpur.PurchaseStatus = "To Receive";
                                        POID = objpur.CreatePO(objpur);
                                    }
                                    
                                    int VIDfromPO = objpur.GetVendorIdbyPO(POID);
                                    if (VID == VIDfromPO)
                                    {
                                        ViewState["FirstPO"] = "no";
                                        //objpur.POID = POID;
                                       // objpur.CreatePODet(objpur);
                                    }
                                    else
                                    {
                                        if (ViewState["FirstPO"].ToString() == "no"|| ViewState["CreatenewPO"].ToString()=="yes")
                                        {
                                            objpur.SOref = SOID;
                                            objpur.PONo = GenerateNoPO("PO");
                                            objpur.Createdon = DateTime.Now;
                                            objpur.VendorId = VID;
                                            objpur.PurchaseStatus = "To Receive";
                                            int POIDnew = objpur.CreatePO(objpur);
                                            // objpur.POID = POIDnew;
                                            //objpur.CreatePODet(objpur);
                                        }
                                        ViewState["FirstPO"] = "no";
                                        ViewState["CreatenewPO"] = "yes";
                                    }
                                    //for PO Items
                                    string currentdate = DateTime.Now.ToString("yyyy-MM-dd");
                                    int POIDfromVendor = objpur.GetPOIdbyVendor(VID, currentdate);
                                    if (POIDfromVendor > 0)
                                    {
                                        objpur.POID = POIDfromVendor;
                                        objpur.CreatePODet(objpur);
                                    }
                                }
                                string currentProduct = POPId + "," + POSize + "," + POQty + "," + SessionnameforPO;
                                List<string> POCookiePIDWithQtyList = POCookiePID.Split(',').Select(x => x.Trim()).Where(x => x != string.Empty).ToList();
                                POCookiePIDWithQtyList.Remove(currentProduct);
                                string POCookiePIDWithQtyUpdated = String.Join(",", POCookiePIDWithQtyList.ToArray());
                              
                                if (POCookiePIDWithQtyUpdated == "" )
                                {
                                    HttpCookie CartProductsWithQty = Request.Cookies["POCartPID"];
                                    CartProductsWithQty.Values["POCartPID"] = null;
                                    CartProductsWithQty.Expires = DateTime.Now.AddDays(-1);
                                    Response.Cookies.Add(CartProductsWithQty);

                                }
                                else
                                {
                                    HttpCookie CartProductsWithQty = Request.Cookies["POCartPID"];
                                    CartProductsWithQty.Values["POCartPID"] = POCookiePIDWithQtyUpdated;
                                    CartProductsWithQty.Expires = DateTime.Now.AddDays(30);
                                    Response.Cookies.Add(CartProductsWithQty);

                                }

                            }
                            ViewState["CreatePO"] = null;
                        }
                            //Payment Code
                            if (isformvalidPay())
                        {
                            string TotalAmount = spanTotalAmt.InnerText;
                            string TotalAmt = TotalAmount.Split('.')[1].ToString();
                            objsale.TotalAmount = Convert.ToDecimal(TotalAmt);
                            if (txtCreditCard.Text != "")
                            {
                                objsale.CreditCardNumber = txtCreditCard.Text;
                                objsale.DebitCardNumber = DBNull.Value.ToString();
                            }
                            if (txtDebitCard.Text != "")
                            {
                                objsale.CreditCardNumber = DBNull.Value.ToString();
                                objsale.DebitCardNumber = txtDebitCard.Text;
                            }
                            if (txtDebitCard.Text != "" && txtCreditCard.Text != "")
                            {
                                objsale.CreditCardNumber = DBNull.Value.ToString();
                                objsale.DebitCardNumber = DBNull.Value.ToString();
                            }
                            if (rblPayType.SelectedValue == "0" || rblPayType.SelectedValue == "1")
                            {
                                objsale.PaymentType = "Credit/Debit";
                                lblerror.Text = "";
                                upModalPay.Update();
                            }
                            else if (rblPayType.SelectedValue == "2")
                            {
                                objsale.PaymentType = "Cash on Delivery";
                                lblerror.Text = "";
                                upModalPay.Update();
                            }

                            if (txtdeladdress.Text != "")
                            {
                                objsale.DeliveryAddress = txtdeladdress.Text;
                                lblerror.Text = "";
                                upModalPay.Update();
                            }


                            objsale.PayStatus = "Paid";
                            objsale.CreatePay(objsale);
                        }
                        ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertpaysave()", true);

                        Response.Redirect("~/Cart.aspx");
                       
                    }

                }
                else
                {
                    lblerror.Text = "Your Shopping Cart is Empty";
                    upModalPay.Update();
                }
            }
            else
            {

            }
        }
    }
}