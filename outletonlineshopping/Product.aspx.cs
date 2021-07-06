using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class Product : System.Web.UI.Page
    {
        bool isUnitEdited;
        int UnitId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindUnit();
                BindBrands();
                BindCat();
                BindSubCat();
                ddlsubcategory.Enabled = false;
                ddlgender.Enabled = false;
                BindGender();
                BindVendor();

                if (Request.QueryString["Id"] != null)
                {
                    GetDataToEdit(Convert.ToInt32(Request.QueryString["Id"]));
                    ddlsubcategory.Enabled = true;
                    ddlgender.Enabled = true;
                }
                if (Session["Showpopup"] != null)
                {
                    Session["Showpopup"] = null;
                    BindUnitList();
                    upModal.Update();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                }
            }
        }

        Connection obj = new Connection();
        public void GetDataToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr=obj.DataReaderwithparam("Select * from tblProduct where ProductId=@Id",Id))
            {
                sdr.Read();
                txtProductname.Text = sdr["ProductName"].ToString();
                txtprice.Text = sdr["SalesPrice"].ToString();
                txtcost.Text = sdr["Cost"].ToString();
                txtQty.Text = sdr["Quantity"].ToString();
                ddluom.SelectedValue = sdr["Uom"].ToString();
                ddlbrand.SelectedValue = sdr["BrandID"].ToString();
                ddlcategory.SelectedValue = sdr["CategoryID"].ToString();
                ddlsubcategory.SelectedValue = sdr["SubCatID"].ToString();
                ddlgender.SelectedValue = sdr["GenderID"].ToString();
                txtdescription.Text = sdr["Description"].ToString();
                txtproductdetails.Text = sdr["ProductDetails"].ToString();
                txtMatcare.Text = sdr["MaterialCare"].ToString();
                ChkFD.Checked = Convert.ToBoolean(sdr["FreeDelivery"]);
                ddlvendor.SelectedValue = sdr["VendorID"].ToString();
             
            }
            obj.CloseConnection();

        }
        public void GetDataToEditUnit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select * from tblUom where UomId=@Id",Id))
            {
                sdr.Read();
                txtunit.Text = sdr["Unitofmeasure"].ToString();
                
            }
            obj.CloseConnection();

        }
        public void BindUnit()
        {
            obj.OpenConection();
            ddluom.DataSource = obj.DataReader("select UomId,Unitofmeasure from tblUom");
            ddluom.DataTextField = "Unitofmeasure";
            ddluom.DataValueField = "UomId";          
            ddluom.DataBind();
            this.ddluom.Items.Insert(0, "Select Unit");
            obj.CloseConnection();
        }
        public void BindUnitList()
        {
            DataTable data = obj.ShowDataInGridView("select UomId,Unitofmeasure from tblUom");


            if (data.Rows.Count > 0)
            {
                dgvunit.DataSource = data;
                dgvunit.DataBind();
              
            }
            else
            {
                DataTable dt = new DataTable();
                dgvunit.DataSource = dt;
                dgvunit.DataBind();
                
            }

        }

        public void BindCat()
        {
            obj.OpenConection();
            ddlcategory.DataSource = obj.DataReader("select CatID,CatName from tblCategory");
            ddlcategory.DataTextField = "CatName";
            ddlcategory.DataValueField = "CatID";
            ddlcategory.DataBind();
            this.ddlcategory.Items.Insert(0, "Select Category");
            obj.CloseConnection();
        }
       
        public void BindSubCat()
        {
            obj.OpenConection();
            ddlsubcategory.DataSource = obj.DataReader("select SubCatID,SubCatName from tblSubCategory");
            ddlsubcategory.DataTextField = "SubCatName";
            ddlsubcategory.DataValueField = "SubCatID";
            ddlsubcategory.DataBind();
            this.ddlsubcategory.Items.Insert(0, "Select Sub Category");
            obj.CloseConnection();
        }
        public void BindBrands()
        {
            obj.OpenConection();
            ddlbrand.DataSource = obj.DataReader("select BrandID,Name from tblBrands");
            ddlbrand.DataTextField = "Name";
            ddlbrand.DataValueField = "BrandID";
            ddlbrand.DataBind();
            this.ddlbrand.Items.Insert(0, "Select Brand");
            obj.CloseConnection();
        }
        public void BindGender()
        {
            obj.OpenConection();
            ddlgender.DataSource = obj.DataReader("select GenderID,GenderName from tblGender");
            ddlgender.DataTextField = "GenderName";
            ddlgender.DataValueField = "GenderID";
            ddlgender.DataBind();
            this.ddlgender.Items.Insert(0, "Select Gender");
            obj.CloseConnection();
        }
        public void BindVendor()
        {
            obj.OpenConection();
            ddlvendor.DataSource = obj.DataReader("select VendorID,VendorName from tblVendor");
            ddlvendor.DataTextField = "VendorName";
            ddlvendor.DataValueField = "VendorID";
            ddlvendor.DataBind();
            this.ddlvendor.Items.Insert(0, "Select Vendor");
            obj.CloseConnection();
        }




        protected void btnopen_Click(object sender, EventArgs e)
        {
                BindUnitList();
                lblModalTitle.Text = "Unit of Measure";
                lblModalBody.Text = "";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            
        }

        protected void btnunitsave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtunit.Text)){
                Products obj = new Products();
                obj.Unitofmeasure = txtunit.Text;
                if (ViewState["UnitId"] == null)
                {
                   
                    obj.CreateUnit(obj);
                    BindUnitList();             
                    upModal.Update();
                    BindUnit();
                    
                }
                else
                {
                    obj.UomId = (int)ViewState["UnitId"];
                    obj.UpdateUnit(obj);
                    ViewState["UnitId"] = null;                   
                    BindUnitList();                                    
                    BindUnit();
                    Session["Showpopup"] = true;
                    Response.Redirect("Product.aspx");
                   
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertemptyunit()", true);
            }
            
        }

        protected void dgvunit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Products obj = new Products();
            obj.DeleteUnits(Convert.ToInt32(dgvunit.DataKeys[e.RowIndex].Value.ToString()));        
            BindUnitList();         
            upModal.Update();
            BindUnit();
            Session["Showpopup"] = true;
            Response.Redirect("Product.aspx");
           

        }

        protected void dgvunit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvunit.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvunit.DataKeys[e.NewEditIndex].Value.ToString());
            GetDataToEditUnit(id);
            upModal.Update();
            isUnitEdited = true;
            ViewState["UnitId"] = id;

        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlsubcategory.Enabled = true;
            obj.OpenConection();
            ddlsubcategory.DataSource = obj.DataReader("select SubCatID,SubCatName from tblSubCategory where MainCatID="+ddlcategory.SelectedItem.Value+"");
            ddlsubcategory.DataTextField = "SubCatName";
            ddlsubcategory.DataValueField = "SubCatID";
            ddlsubcategory.DataBind();
            this.ddlsubcategory.Items.Insert(0, "Select Sub Category");
            obj.CloseConnection();
        }

        protected void ddlgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlgender.Enabled = true;
            obj.OpenConection();
            cblSize.DataSource = obj.DataReader("select SizeID,SizeName from tblSizes where BrandID=" + ddlgender.SelectedItem.Value + " and CategoryID="+ddlcategory.SelectedItem.Value+" and SubCategoryID="+ddlsubcategory.SelectedItem.Value+" and GenderID="+ddlgender.SelectedItem.Value+"");
            cblSize.DataTextField = "SizeName";
            cblSize.DataValueField = "SizeID";
            cblSize.DataBind();
            obj.CloseConnection();
        }

        protected void ddlsubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsubcategory.SelectedIndex != 0)
            {
                ddlgender.Enabled = true;
            }
            else
            {
                ddlgender.Enabled = false;
            }
            
        }
        private bool isformvalidProduct()
        {
            if (txtProductname.Text == "")
            {

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Product Name is not Valid');", true);
                txtProductname.Focus();
                return false;
            }
            else if (txtprice.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Price is not Valid');", true);
                txtprice.Focus();
                return false;
            }
            else if (txtcost.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Cost is not Valid');", true);
                txtcost.Focus();
                return false;
            }
            else if (txtQty.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Quantity is not Valid');", true);
                txtQty.Focus();
                return false;
            }
            else if (ddluom.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Unit is not Valid');", true);
                ddlgender.Focus();
                return false;
            }
            else if (ddlvendor.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Vendor is not Valid');", true);
                ddlvendor.Focus();
                return false;
            }
            else if (ddlbrand.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Brand is not Valid');", true);
                ddlbrand.Focus();
                return false;
            }
            else if (ddlcategory.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Category is not Valid');", true);
                ddlcategory.Focus();
                return false;
            }
            else if (ddlsubcategory.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sub Category is not Valid');", true);
                ddlsubcategory.Focus();
                return false;
            }
            else if (ddlgender.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Gender is not Valid');", true);
                ddlgender.Focus();
                return false;
            }

            else if (txtdescription.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Description is not Valid');", true);
                txtdescription.Focus();
                return false;
            }
            else if (txtMatcare.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Material Care is not Valid');", true);
                txtMatcare.Focus();
                return false;
            }
            else if (txtproductdetails.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Product Details is not Valid');", true);
                txtproductdetails.Focus();
                return false;

            }
            else if (txtReorderPoint.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Reorder Point is not Valid');", true);
                txtReorderPoint.Focus();
                return false;

            }
            else if (txtcstleadtime.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Customer Lead Time is not Valid');", true);
                txtcstleadtime.Focus();
                return false;

            }
            return true;
        }
        protected void btnProdsave_Click(object sender, EventArgs e)
        {
            if (isformvalidProduct())
            {
                Products pro = new Products();

                pro.ProductName = txtProductname.Text;
                pro.Uom = Convert.ToInt32(ddluom.SelectedValue);
                pro.SalesPrice = Convert.ToDecimal(txtprice.Text);
                pro.Cost = Convert.ToDecimal(txtcost.Text);
                pro.BrandId = Convert.ToInt32(ddlbrand.SelectedValue);
                pro.CatID = Convert.ToInt32(ddlcategory.SelectedValue);
                pro.SubCatID = Convert.ToInt32(ddlsubcategory.SelectedValue);
                pro.GenderID = Convert.ToInt32(ddlgender.SelectedValue);
                pro.desc = txtdescription.Text;
                pro.productdetail = txtproductdetails.Text;
                pro.matcare = txtMatcare.Text;
                pro.ReorderPoint = Convert.ToInt32(txtReorderPoint.Text);
                pro.CustomerLeadTime = Convert.ToInt32(txtcstleadtime.Text);
                pro.VendorID= Convert.ToInt32(ddlvendor.SelectedValue);
                if (ChkFD.Checked)
                {
                    pro.Freedelivery = 1;
                }
                else
                {
                    pro.Freedelivery = 0;
                }
                if (Request.QueryString["Id"] == null)
                {

                    int ProductId = pro.CreateProducts(pro);
                    pro.ProductId = ProductId;
                    for (int i = 0; i < cblSize.Items.Count; i++)
                    {

                        int SizeID = Convert.ToInt32(cblSize.Items[i].Value);
                        int Quantity = Convert.ToInt32(txtQty.Text);
                        pro.SizeID = SizeID;
                        pro.Quantity = Quantity;
                        pro.CreateSizeQty(pro);
                    }
                    if (fuImg01.HasFile)
                    {
                        string SavePath = Server.MapPath("ecommerceOutletShop/Img/ProductImages/") + ProductId;
                        string newPth = SavePath.Remove(51, 21);
                        if (!Directory.Exists(newPth))
                        {
                            Directory.CreateDirectory(newPth);
                        }
                        string Extension = Path.GetExtension(fuImg01.PostedFile.FileName);
                        fuImg01.SaveAs(newPth + "\\" + txtProductname.Text.Trim() + "01" + Extension);
                        pro.ImgName = txtProductname.Text.Trim() + "01";
                        pro.Extension = Extension;
                        pro.CreateImg(pro);
                    }
                    if (fuImg02.HasFile)
                    {
                        string SavePath = Server.MapPath("ecommerceOutletShop/Img/ProductImages/") + ProductId;
                        String newPth = SavePath.Remove(51, 21);
                        if (!Directory.Exists(newPth))
                        {
                            Directory.CreateDirectory(newPth);
                        }
                        string Extension = Path.GetExtension(fuImg02.PostedFile.FileName);
                        fuImg02.SaveAs(newPth + "\\" + txtProductname.Text.Trim() + "02" + Extension);
                        pro.ImgName = txtProductname.Text.Trim() + "02";
                        pro.Extension = Extension;
                        pro.CreateImg(pro);
                    }
                    if (fuImg03.HasFile)
                    {
                        string SavePath = Server.MapPath("~/ecommerceOutletShop/Img/ProductImages/") + ProductId;
                        String newPth = SavePath.Remove(51, 21);
                        if (!Directory.Exists(newPth))
                        {
                            Directory.CreateDirectory(newPth);
                        }
                        string Extension = Path.GetExtension(fuImg03.PostedFile.FileName);
                        fuImg03.SaveAs(newPth + "\\" + txtProductname.Text.Trim() + "03" + Extension);
                        pro.ImgName = txtProductname.Text.Trim() + "03";
                        pro.Extension = Extension;
                        pro.CreateImg(pro);
                    }
                    ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertproduct()", true);

                }
                else
                {
                    pro.Quantity = Convert.ToInt32(txtQty.Text);
                    pro.ProductId = Convert.ToInt32(Request.QueryString["Id"]);
                    pro.UpdateProduct(pro);
                    pro.UpdateProductSizeQty(pro);
                    ClientScript.RegisterStartupScript(GetType(), "randomtext", "alerteditproduct()", true);

                }
            }
            
        }
    }
}