using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

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
                int ItemsCount = 0;
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    SessionName = CookieDataArray[i].ToString().Split('-')[3];

                    if (CookieDataArray.Length > 0 && currentSession == SessionName)
                    {
                        
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
        public string GenerateNoGI(string GIno)
        {
            Sale objsale = new Sale();
            string a = "";
            int SoID = objsale.GetLastSmoveSoId();
            if (SoID > 0)
            {
                DataTable dt = objsale.GetLastGINo();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string lastNo = string.Empty;
                        foreach (DataRow row in dt.Rows)
                        {
                            lastNo = row["DocNo"].ToString();

                        }
                        string LastNo = lastNo.Split('-')[1].ToString();
                        int No = Convert.ToInt32(LastNo);
                        int Num = No + 1;
                        a = GIno + "-000" + Num;

                    }
                }
            }
            else
            {
                a = GIno + "-0001";
            }
            return a;

        }
        public string GenerateNoGR(string GRno)
        {
            Sale objsale = new Sale();
            string a = "";
            int SoID = objsale.GetLastSmovePoId();
            if (SoID > 0)
            {
                DataTable dt = objsale.GetLastGRNo();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string lastNo = string.Empty;
                        foreach (DataRow row in dt.Rows)
                        {
                            lastNo = row["DocNo"].ToString();

                        }
                        string LastNo = lastNo.Split('-')[1].ToString();
                        int No = Convert.ToInt32(LastNo);
                        int Num = No + 1;
                        a = GRno + "-000" + Num;

                    }
                }
            }
            else
            {
                a = GRno + "-0001";
            }
            return a;

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
        public string GetVendorEmail(int Id)
        {
            Purchase obj = new Purchase();
            string PONo = obj.GetPONOfromEmail(Id);
            return PONo;
        }
        public string PONOforEmail(int Id)
        {
            Purchase obj = new Purchase();
            string PONo = obj.GetPONOfromEmail(Id);
            return PONo;
        }
        public DataTable POLineitemforEmail(int ID)
        {
            Purchase obj = new Purchase();
            DataTable dt=obj.GetPOLineItemforEmail(ID);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                DataTable data = new DataTable();
                return data;
            }
            
        }
        private void SendPDFEmail(DataTable dt,int POID)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    string companyName = "OutLet Shopping";
                    string orderNo = PONOforEmail(POID);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Order No:</b>");
                    sb.Append(orderNo);
                    sb.Append("</td><td><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Company Name :</b> ");
                    sb.Append(companyName);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    
                        sb.Append("<th>");
                        sb.Append("Product Name");
                        sb.Append("</th>");
                        sb.Append("<th>");
                        sb.Append("Size");
                        sb.Append("</th>");
                        sb.Append("<th>");
                        sb.Append("Quantity");
                        sb.Append("</th>");
                        sb.Append("<th>");
                        sb.Append("Price");
                        sb.Append("</th>");

                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        Purchase obj = new Purchase();
                        string Email = obj.GetVendorEmailfromPO(POID);

                        MailMessage mm = new MailMessage("onlineoutletshopping2021@gmail.com", Email);
                        mm.Subject = "Order ";
                        mm.Body = "Order Attachment";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Order "+orderNo+".pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = "onlineoutletshopping2021@gmail.com";
                        NetworkCred.Password = "2262801abcxyz";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
        }
        public void SavePOIDforEmail(int PurchID)
        {
            if (Request.Cookies["POIDEmail"] != null)
            {
                string POID = Request.Cookies["POIDEmail"].Value.Split('=')[1];
                POID = POID + "," + PurchID;
                HttpCookie PO = Request.Cookies["POIDEmail"];
                PO.Values["POIDEmail"] = POID.ToString();
                PO.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(PO);
            }
            else
            {
                HttpCookie PO = new HttpCookie("POIDEmail");
                PO.Values["POIDEmail"] = PurchID.ToString();
                PO.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(PO);
            }
                

        }
        protected void btnpay_Click(object sender, EventArgs e)
        {
            Sale objsale = new Sale();
            if (Request.Cookies["CartPID"] != null)
            {
                if (isformvalidPay())
                {
                    string currentSession = Session["Username"].ToString();
                    string SessionName = string.Empty;
                    string Sessionname = string.Empty;
                    string CookiePIDWithQty = Request.Cookies["CartPID"].Value.Split('=')[1];
                    string CookiePID = Request.Cookies["CartP"].Value.Split('=')[1];

                    string[] CookieDataArray = CookiePIDWithQty.Split(',');
                    List<string> CookiePIDListCheck = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i.Contains(currentSession)).ToList();

                    if (CookiePIDListCheck.Count > 0)
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

                        int Countpurofuser = objsale.CountSOofUser(UserId);
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
                                    decimal price = objsale.GetPriceProduct(objsale);
                                    objsale.salePrice = price;
                                    objsale.SizeID = Size;
                                    objsale.DevStatus = "Not Delivered";
                                    objsale.CreateSODet(objsale);
                                    string PurchasedProductWithQty = PID + "-" + Size + "-" + Qty + "-" + SessionName;
                                    string PurchasedProduct = PID + "-" + Size + "-" + SessionName;
                                    List<string> CookiePIDWithQtyList = CookiePIDWithQtynew.Split(',').Select(x => x.Trim()).Where(x => x != string.Empty).ToList();
                                    List<string> CookiePIDList = CookiePIDnew.Split(',').Select(x => x.Trim()).Where(x => x != string.Empty).ToList();
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
                                    int PrdQtyID = objsale.CheckQuantity(PID, Size, Qty);
                                    int CustLeadTime = objsale.GetCustomerLeadTime(objsale);
                                    if (PrdQtyID > 0)
                                    {
                                        SavePOItemsCookie(PurchasedProductWithQty);
                                        ViewState["CreatePO"] = true;
                                    }
                                    else
                                    {
                                        Inventory objinv = new Inventory();
                                        objinv.DOCNo = GenerateNoGI("GI");
                                        objinv.SOID = SOID;
                                        objinv.POID = 0;
                                        objinv.StockMoveStatus = "Stock Picking";
                                        objinv.MoveType = "Stock Out";
                                        objinv.GiCount = 1;
                                       int id=objinv.CreateStockMove(objinv);

                                        objinv.PID = PID;
                                        objinv.SizeID = Size;
                                        objinv.Quantity = Qty;
                                        objinv.StockMoveID = id;
                                        objinv.StockMoveStatus = "Stock Picking";
                                        objinv.ChangeQuantityMinus(objinv);
                                        objinv.CreateStockMoveDet(objinv);

                                        if (CustLeadTime > 0)
                                        {
                                            DateTime CurrentDate = DateTime.Now.Date;
                                            DateTime ScheduledDeliveryDate = CurrentDate.AddDays(CustLeadTime);
                                            objsale.SOID = SOID;
                                            objsale.ScheduledDeliveryDate = ScheduledDeliveryDate;
                                            objsale.AddScheduledDate(objsale);
                                        }

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
                               
                                int POID = 0;
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
                                    objpur.SizeID = POSize;
                                    objsale.PID = POPId;
                                    objsale.SizeID = POSize;

                                    decimal price = objpur.GetPriceProduct(objpur);
                                    int VID = objpur.GetVendorId(POPId);
                                    if (VID > 0)
                                    {


                                        if (ViewState["FirstPO"].ToString() == "yes")
                                        {
                                            objpur.SOref = SOID;
                                            objpur.PONo = GenerateNoPO("PO");
                                            objpur.Createdon = DateTime.Now;
                                            objpur.VendorId = VID;
                                            objpur.PurchaseStatus = "To Receive";
                                            POID = objpur.CreatePO(objpur);
                                            SavePOIDforEmail(POID);
                                        }

                                        int VIDfromPO = objpur.GetVendorIdbyPO(POID);

                                        if (VID == VIDfromPO)
                                        {
                                            ViewState["FirstPO"] = "no";
                                            //objpur.POID = POID;
                                            // objpur.CreatePODet(objpur);
                                            objpur.VendorId = VIDfromPO;
                                            int CustLeadTime = objsale.GetCustomerLeadTime(objsale);
                                            int DevLeadTime = objpur.GetDeliveryLeadTime(objpur);
                                            int TotalTime = DevLeadTime + CustLeadTime;
                                            DateTime CurrentDate = DateTime.Now.Date;
                                            DateTime ScheduledDeliveryDate = CurrentDate.AddDays(TotalTime);
                                            objsale.SOID = SOID;
                                            objsale.ScheduledDeliveryDate = ScheduledDeliveryDate;
                                            objsale.AddScheduledDate(objsale);
                                        }
                                        else
                                        {
                                            int POIDnew = 0;
                                            if (ViewState["FirstPO"].ToString() == "no" || ViewState["CreatenewPO"].ToString() == "yes")
                                            {
                                                objpur.SOref = SOID;
                                                objpur.PONo = GenerateNoPO("PO");
                                                objpur.Createdon = DateTime.Now;
                                                objpur.VendorId = VID;
                                                objpur.PurchaseStatus = "To Receive";
                                                POIDnew = objpur.CreatePO(objpur);
                                                // objpur.POID = POIDnew;
                                                //objpur.CreatePODet(objpur);
                                                SavePOIDforEmail(POIDnew);
                                            }
                                            ViewState["FirstPO"] = "no";
                                            ViewState["CreatenewPO"] = "yes";
                                            int CustLeadTime = objsale.GetCustomerLeadTime(objsale);
                                            int DevLeadTime = objpur.GetDeliveryLeadTime(objpur);
                                            int TotalTime = DevLeadTime + CustLeadTime;
                                            DateTime CurrentDate = DateTime.Now.Date;
                                            DateTime ScheduledDeliveryDate = CurrentDate.AddDays(TotalTime);
                                            objsale.SOID = SOID;
                                            objsale.ScheduledDeliveryDate = ScheduledDeliveryDate;
                                            objsale.AddScheduledDate(objsale);
                                        }
                                        //for PO Items
                                        string currentdate = DateTime.Now.ToString("yyyy-MM-dd");
                                        int POIDfromVendor = objpur.GetPOIdbyVendor(VID, currentdate);
                                        if (POIDfromVendor > 0)
                                        {
                                            objpur.POID = POIDfromVendor;
                                            objpur.Price = price;
                                            objpur.CreatePODet(objpur);
                                        }
                                                                  
                                       
                                    }
                                    
                                    string currentProduct = POPId + "-" + POSize + "-" + POQty + "-" + SessionnameforPO;
                                    List<string> POCookiePIDWithQtyList = POCookiePID.Split(',').Select(x => x.Trim()).Where(x => x != string.Empty).ToList();
                                    POCookiePIDWithQtyList.Remove(currentProduct);
                                    string POCookiePIDWithQtyUpdated = String.Join(",", POCookiePIDWithQtyList.ToArray());

                                    if (POCookiePIDWithQtyUpdated == "")
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
                                if (Request.Cookies["POIDEmail"] != null)
                                {
                                    string POEID = Request.Cookies["POIDEmail"].Value.Split('=')[1];
                                    string[] POIDDataArray = POEID.Split(',');
                                    for (int x = 0; x < POIDDataArray.Length; x++)
                                    {
                                        string POIDforEmail = POIDDataArray[x].ToString();
                                        int ID = Convert.ToInt32(POIDforEmail);
                                        DataTable dataitem = POLineitemforEmail(ID);
                                        SendPDFEmail(dataitem, ID);
                                        RemovePOItemforEmail(ID);
                                    }

                                }
                            }
                            //Payment Code

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
                            if (txtDebitCard.Text == "" && txtCreditCard.Text == "")
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
                            int userId =Convert.ToInt32(Session["UserId"]);
                            int CustomerId = objsale.GetCustomerExistfromUserId(userId);
                            if (CustomerId == 0)
                            {
                                objsale.CreateCustomer(userId);
                            }
                        }
                        ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertpaysave()", true);
                        Response.Redirect("~/Cart.aspx");


                    }
                   
                }
                else
                {
                    
                    upModalPay.Update();
                }
            }
            else
            {
                lblerror.Text = "Your Shopping Cart is Empty";
                upModalPay.Update();
            }
        }
        public void RemovePOItemforEmail(int ID)
        {
            if (Request.Cookies["POIDEmail"] != null)
            {
                string POEID = Request.Cookies["POIDEmail"].Value.Split('=')[1];
                List<string> POPIDList = POEID.Split(',').Select(x => x.Trim()).Where(x => x != string.Empty).ToList();
                POPIDList.Remove(ID.ToString());
                string POPIDUpdated = String.Join(",", POPIDList.ToArray());

                if (POPIDUpdated == "")
                {
                    HttpCookie ProductsWithQty = Request.Cookies["POIDEmail"];
                    ProductsWithQty.Values["POIDEmail"] = null;
                    ProductsWithQty.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(ProductsWithQty);

                }
                else
                {
                    HttpCookie ProductsWithQty = Request.Cookies["POIDEmail"];
                    ProductsWithQty.Values["POIDEmail"] = POPIDUpdated;
                    ProductsWithQty.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(ProductsWithQty);

                }
            }
        }
    }
}