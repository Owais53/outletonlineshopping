using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class PONew : System.Web.UI.Page
    {
        Purchase obj = new Purchase();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindVendorddl();
                BindPODetList();
            }
            if (Request.QueryString["Id"] != null)
            {
                GetDataToEdit(Convert.ToInt32(Request.QueryString["Id"]));
                DisableControls();
            }
        }
        protected void DisableControls()
        {
            
                
                ddlproduct.Visible = false;
                txtqty.Visible = false;
                ddlsize.Visible = false;
                btnAdd.Visible = false;
                btnsave.Visible = false;
                lblProd.Visible = false;
                lblQty.Visible = false;
                lblSize.Visible = false;
                dgvPODet.Enabled = false;
               // DisableControls(c, State);
            
        }
        public void GetDataToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("select v.VendorID from tblPO po inner join tblVendor v on po.VendorID=v.VendorID where po.POID=@Id", Id))
            {
                sdr.Read();
               
                ddlvendor.SelectedValue = sdr["VendorID"].ToString();
                

            }
            obj.CloseConnection();
            DataTable dt = obj.GetPOItemNew(Id);
            if (dt.Rows.Count > 0)
            {
                dgvPODet.DataSource = dt;
                dgvPODet.DataBind();

            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvPODet.DataSource = dt1;
                dgvPODet.DataBind();

            }
        }
        public void BindPODetList()
        {

            if (ViewState["Records"] == null)
            {
                dt.Columns.Add("ProductName");
                dt.Columns.Add("SizeName");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");
                ViewState["Records"] = dt;
                dgvPODet.DataSource = dt;
                dgvPODet.DataBind();
            }


        }
        public void BindVendorddl()
        {
            obj.OpenConection();
            ddlvendor.DataSource = obj.DataReader("select VendorID,VendorName from tblVendor");
            ddlvendor.DataTextField = "VendorName";
            ddlvendor.DataValueField = "VendorID";
            ddlvendor.DataBind();
            this.ddlvendor.Items.Insert(0, "Select Vendor");
            obj.CloseConnection();
        }
        protected void ddlvendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.OpenConection();
            ddlproduct.DataSource = obj.DataReader("select ProductId,ProductName from tblProduct where VendorID=" + ddlvendor.SelectedValue + "");
            ddlproduct.DataTextField = "ProductName";
            ddlproduct.DataValueField = "ProductId";
            ddlproduct.DataBind();
            this.ddlproduct.Items.Insert(0, "Select Product");
            obj.CloseConnection();
        }

        protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj.OpenConection();
            ddlsize.DataSource = obj.DataReader("select s.SizeID,s.SizeName from tblSizes s inner join tblProduct p on s.BrandID=p.BrandID and s.CategoryID=p.CategoryID and s.SubCategoryID=p.SubCatID and s.GenderID=p.GenderID where p.ProductId=" + ddlproduct.SelectedValue + "");
            ddlsize.DataTextField = "SizeName";
            ddlsize.DataValueField = "SizeID";
            ddlsize.DataBind();
            this.ddlsize.Items.Insert(0, "Select Size");
            obj.CloseConnection();
        }
        private bool isformvalid()
        {
            if (ddlproduct.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Product Name is not valid');", true);

                ddlproduct.Focus();
                return false;
            }
            else if (ddlsize.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Size is not valid');", true);

                ddlsize.Focus();
                return false;
            }
            else if (txtqty.Text == "" || txtqty.Text == 0.ToString())
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Quantity is not valid');", true);

                txtqty.Focus();
                return false;
            }

            return true;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (isformvalid())
            {
                dt = (DataTable)ViewState["Records"];
                ViewState["AddRow"] = "no";
                decimal price = obj.GetPriceProduct(Convert.ToInt32(ddlproduct.SelectedValue), Convert.ToInt32(txtqty.Text));
                if (dgvPODet.Rows.Count == 0)
                {
                    dt.Rows.Add(ddlproduct.SelectedItem.Text, ddlsize.SelectedItem.Text, txtqty.Text, price.ToString());
                }
                int iteration = 0;
                foreach (GridViewRow row in dgvPODet.Rows)
                {

                    iteration++;
                    string Product = row.Cells[0].Text;
                    string Size = row.Cells[1].Text;

                    if (Product != "")
                    {
                        int VID = obj.GetVendorProduct(Product);
                        if (ddlvendor.SelectedValue != VID.ToString())
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Product " + Product + " has different Vendor');", true);
                        }
                        else
                        {
                            if (ddlproduct.SelectedItem.Text == Product && ddlsize.SelectedItem.Text == Size)
                            {
                                int Qty = int.Parse(txtqty.Text) + int.Parse(row.Cells[2].Text);

                                for (int x = dt.Rows.Count - 1; x >= 0; x--)
                                {
                                    DataRow dr = dt.Rows[x];
                                    if (dr["ProductName"].ToString() == ddlproduct.SelectedItem.Text && dr["SizeName"].ToString() == ddlsize.SelectedItem.Text)
                                    {
                                        dr.Delete();
                                    }

                                }
                                dt.AcceptChanges();

                                dt.Rows.Add(ddlproduct.SelectedItem.Text, ddlsize.SelectedItem.Text, Qty.ToString(), price.ToString());
                                dgvPODet.DataSource = dt;
                                dgvPODet.DataBind();
                                break;
                            }
                            else
                            {
                                if (iteration < dgvPODet.Rows.Count)
                                {
                                    continue;
                                }

                                ViewState["AddRow"] = "yes";
                            }

                        }
                    }


                }
                if (ViewState["AddRow"].ToString() == "yes")
                {
                    dt.Rows.Add(ddlproduct.SelectedItem.Text, ddlsize.SelectedItem.Text, txtqty.Text, price.ToString());

                    ViewState["AddRow"] = "no";
                }
                dgvPODet.DataSource = dt;
                dgvPODet.DataBind();

            }
        }
        protected void dgvPODet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[4].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }

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
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = ViewState["Records"] as DataTable;
            dt1.Rows[index].Delete();
            ViewState["Records"] = dt1;
            dgvPODet.DataSource = dt1;
            dgvPODet.DataBind();
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (dgvPODet.Rows.Count > 0 && ddlvendor.SelectedIndex>0)
            {
                int VendorID = Convert.ToInt32(ddlvendor.SelectedValue);
                int POId = 0;
                obj.SOref = 0;
                obj.PONo = GenerateNoPO("PO");
                obj.Createdon = DateTime.Now;
                obj.VendorID = VendorID;
                obj.PurchaseStatus = "To Receive";
                POId = obj.CreatePO(obj);

                foreach(GridViewRow gr in dgvPODet.Rows)
                {
                    int PID = obj.GetProductId(gr.Cells[0].Text);
                    int SizeID = obj.GetSizeId(gr.Cells[1].Text);
                    obj.POID = POId;
                    obj.PID = PID;
                    obj.SizeID = SizeID;
                    obj.Quantity = Convert.ToInt32(gr.Cells[2].Text);
                    obj.Price = Convert.ToDecimal(gr.Cells[3].Text);
                    obj.CreatePODet(obj);
                    
                }
                ScriptManager.RegisterStartupScript(this.Page, GetType(), "randomtext", "alertaddpo()", true);
            }
            else
            {
                if (ddlvendor.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please select Vendor');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('No Product Added');", true);
                }
               
            }
        }
        public string GenerateNoGR(string GRno)
        {
            Inventory objinv = new Inventory();
            string a = "";
            int SoID = objinv.GetLastSmovePoId();
            if (SoID > 0)
            {
                DataTable dt = objinv.GetLastGRNo();
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
        protected void btnGrinPonew_ServerClick(object sender, EventArgs e)
        {
            Inventory objinv = new Inventory();
            objinv.DocNo = GenerateNoGR("GR");
            objinv.SOID = 0;
            objinv.POID = Convert.ToInt32(Request.QueryString["Id"]);
            objinv.MoveType = "Stock In";
            objinv.Status = "Received";
            int GRID = objinv.CreateGR(objinv);
            int POID = Convert.ToInt32(Request.QueryString["Id"]);
            if (Request.QueryString["Id"] != null)
            {

                foreach (GridViewRow row in dgvPODet.Rows)
                {
                    int PID = obj.GetProductId(row.Cells[0].Text);
                    int SizeID = obj.GetSizeId(row.Cells[1].Text);

                    objinv.PID = PID;
                    objinv.SizeID = SizeID;
                    objinv.Quantity = Convert.ToInt32(row.Cells[2].Text);
                    objinv.Price = Convert.ToDecimal(row.Cells[3].Text);
                    objinv.ChangeQuantityPlus(objinv);
                }
                Response.Redirect("GR.aspx?POID=" + POID + "&GR=" + GRID + "");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Good Receipt can not be created while Creating Purchase Order');", true);
            }
        }
    }
}
