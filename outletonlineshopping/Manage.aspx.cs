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
    public partial class Manage : System.Web.UI.Page
    {
        Products obj = new Products();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandList();
                BindBrands();
                BindCat();
                BindCatforSize();
                BindSubCatforSize();
                BindGender();
                BindCategoryList();
                BindSubCategoryList();
                BindSizeList();
            }
        }
        public void BindBrandList()
        {
            DataTable data = obj.ShowDataInGridView("select BrandID,Name from tblBrands");


            if (data.Rows.Count > 0)
            {
                dgvbrand.DataSource = data;
                dgvbrand.DataBind();

            }
            else
            {
                DataTable dt = new DataTable();
                dgvbrand.DataSource = dt;
                dgvbrand.DataBind();

            }

        }
        public void BindCategoryList()
        {
            DataTable data = obj.ShowDataInGridView("select CatID,CatName from tblCategory");


            if (data.Rows.Count > 0)
            {
                dgvcat.DataSource = data;
                dgvcat.DataBind();

            }
            else
            {
                DataTable dt = new DataTable();
                dgvcat.DataSource = dt;
                dgvcat.DataBind();

            }

        }
        public void BindSubCategoryList()
        {
            DataTable data = obj.ShowDataInGridView("select c.CatName,sc.SubCatID,sc.SubCatName from tblSubCategory sc inner join tblCategory c on sc.MainCatID=c.CatID");


            if (data.Rows.Count > 0)
            {
                dgvsubcat.DataSource = data;
                dgvsubcat.DataBind();

            }
            else
            {
                DataTable dt = new DataTable();
                 dgvsubcat.DataSource = dt;
                 dgvsubcat.DataBind();

            }

        }
        public void BindSizeList()
        {
            DataTable data = obj.ShowDataInGridView("select s.SizeID,s.SizeName,b.Name,c.CatName,sc.SubCatName,g.GenderName from tblSizes s inner join tblBrands b on s.BrandID=b.BrandID inner join tblCategory c on s.CategoryID=c.CatID inner join tblSubCategory sc on s.SubCategoryID=sc.SubCatID inner join tblGender g on s.GenderID=g.GenderID");


            if (data.Rows.Count > 0)
            {
                dgvsize.DataSource = data;
                dgvsize.DataBind();

            }
            else
            {
                DataTable dt = new DataTable();
                dgvsize.DataSource = dt;
                dgvsize.DataBind();

            }

        }

        protected void dgvbrand_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvbrand.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvbrand.DataKeys[e.NewEditIndex].Value.ToString());
            ViewState["BrandID"] = id;
            GetBrandToEdit(id);
        }
        protected void dgvcat_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvcat.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvcat.DataKeys[e.NewEditIndex].Value.ToString());
            ViewState["CatID"] = id;
            GetCatToEdit(id);
        }
        protected void dgvsubcat_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvsubcat.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvsubcat.DataKeys[e.NewEditIndex].Value.ToString());
            ViewState["SubCatID"] = id;
            GetSubCatToEdit(id);
        }
        private bool isformvalidBrand()
        {
            if (txtBrandname.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Brand Name is not valid');", true);
                txtBrandname.Focus();
                return false;
            }
            
            return true;
        }
        private bool isformvalidCat()
        {
            if (txtcatname.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Category Name is not valid');", true);
                txtcatname.Focus();
                return false;
            }

            return true;
        }
        private bool isformvalidSubCat()
        {
            if (ddlcatname.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Category Name is not valid');", true);
                
                ddlcatname.Focus();
                return false;
            }
           else if (txtsubcatname.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sub Category Name is not valid');", true);

                txtsubcatname.Focus();
                return false;
            }

            return true;
        }
        private bool isformvalidSize()
        {
            if (txtsizename.Text == "")
            {

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Size Name is not Valid');", true);
                txtsizename.Focus();
                return false;
            }
            else if (ddlbrandnames.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Brand name is not Valid');", true);
                ddlbrandnames.Focus();
                return false;
            }
            else if (ddlcatnames.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Category is not Valid');", true);
                ddlcatnames.Focus();
                return false;
            }else if (ddlsubcatnames.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Sub Category is not Valid');", true);
                ddlsubcatnames.Focus();
                return false;
            }else if (ddlgender.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Gender is not Valid');", true);
                ddlgender.Focus();
                return false;
            }

            return true;
        }
        protected void btnbrandsave_Click(object sender, EventArgs e)
        {
            if (isformvalidBrand())
            {
                DataTable dt = obj.CheckDuplicateBrand(txtBrandname.Text);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertbranddup()", true);
                }
                else
                {
                    obj.BrandName = txtBrandname.Text;
                    if (ViewState["BrandID"] == null)
                    {

                        obj.CreateBrand(obj);
                        BindBrandList();
                        txtBrandname.Text = string.Empty;
                        BindBrands();
                        ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertbrandsave()", true);
                    }
                    else
                    {

                        obj.BrandId = (int)ViewState["BrandID"];
                        obj.UpdateBrand(obj);
                        BindBrandList();
                        BindBrands();
                        ViewState["BrandID"] = null;
                        ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertbrandedit()", true);
                    }

                }


            }
        }
        protected void btnaddcat_Click(object sender, EventArgs e)
        {
            if (isformvalidCat())
            {
                DataTable dt = obj.CheckDuplicateCat(txtcatname.Text);
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertcatdup()", true);
                }
                else
                {
                    obj.CatName = txtcatname.Text;
                    if (ViewState["CatID"] == null)
                    {

                        obj.CreateCat(obj);
                        BindCategoryList();
                        BindCat();
                        BindCatforSize();
                        txtcatname.Text = string.Empty;
                        ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertcatsave()", true);
                    }
                    else
                    {

                        obj.CatID = (int)ViewState["CatID"];
                        obj.UpdateCat(obj);
                        BindCategoryList();
                        BindCat();
                        BindCatforSize();
                        ViewState["CatID"] = null;
                        ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertcatedit()", true);
                    }

                }


            }
        }
        protected void btnsubcat_Click(object sender, EventArgs e)
        {
            if (isformvalidSubCat())
            {
                DataTable dt = obj.CheckDuplicateSubCat(txtsubcatname.Text,Convert.ToInt32(ddlcatname.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertsubcatdup()", true);
                }
                else
                {
                    obj.SubCatName = txtsubcatname.Text;
                    obj.CatID = Convert.ToInt32(ddlcatname.SelectedValue);
                    if (ViewState["SubCatID"] == null)
                    {

                        obj.CreateSubCat(obj);
                        BindSubCategoryList();
                        BindSubCatforSize();
                        txtsubcatname.Text = string.Empty;
                        ddlcatname.SelectedIndex = 0;
                         ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertsubcatsave()", true);
                    }
                    else
                    {

                        obj.SubCatID = (int)ViewState["SubCatID"];
                        obj.UpdateSubCat(obj);
                        BindSubCategoryList();
                        BindSubCatforSize();
                        ViewState["SubCatID"] = null;
                        ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertsubcatedit()", true);
                    }

                }


            }
        }
        public void GetBrandToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select * from tblBrands where BrandID=@Id", Id))
            {
                sdr.Read();
                txtBrandname.Text = sdr["Name"].ToString();


            }
            obj.CloseConnection();

        }
        public void GetCatToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select * from tblCategory where CatID=@Id", Id))
            {
                sdr.Read();
                txtcatname.Text = sdr["CatName"].ToString();


            }
            obj.CloseConnection();

        }
        public void GetSubCatToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select * from tblSubCategory where SubCatID=@Id", Id))
            {
                sdr.Read();
                ddlcatname.SelectedValue = sdr["MainCatID"].ToString();
                txtsubcatname.Text = sdr["SubCatName"].ToString();


            }
            obj.CloseConnection();

        }
        public void GetSizeToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select * from tblSizes where SizeID=@Id", Id))
            {
                sdr.Read();
                txtsizename.Text = sdr["SizeName"].ToString();
                ddlbrandnames.SelectedValue = sdr["BrandID"].ToString();
                ddlcatnames.SelectedValue = sdr["CategoryID"].ToString();
                ddlsubcatnames.SelectedValue = sdr["SubCategoryID"].ToString();
                ddlgender.SelectedValue = sdr["GenderID"].ToString();


            }
            obj.CloseConnection();

        }
        public void BindCat()
        {
            obj.OpenConection();
            ddlcatname.DataSource = obj.DataReader("select CatID,CatName from tblCategory");
            ddlcatname.DataTextField = "CatName";
            ddlcatname.DataValueField = "CatID";
            ddlcatname.DataBind();
            this.ddlcatname.Items.Insert(0, "Select Category");
            obj.CloseConnection();
        }
        public void BindCatforSize()
        {
            obj.OpenConection();
            ddlcatnames.DataSource = obj.DataReader("select CatID,CatName from tblCategory");
            ddlcatnames.DataTextField = "CatName";
            ddlcatnames.DataValueField = "CatID";
            ddlcatnames.DataBind();
            this.ddlcatnames.Items.Insert(0, "Select Category");
            obj.CloseConnection();
        }
        public void BindSubCatforSize()
        {
            obj.OpenConection();
            ddlsubcatnames.DataSource = obj.DataReader("select SubCatID,SubCatName from tblSubCategory");
            ddlsubcatnames.DataTextField = "SubCatName";
            ddlsubcatnames.DataValueField = "SubCatID";
            ddlsubcatnames.DataBind();
            this.ddlsubcatnames.Items.Insert(0, "Select Sub Category");
            obj.CloseConnection();
        }
        public void BindBrands()
        {
            obj.OpenConection();
            ddlbrandnames.DataSource = obj.DataReader("select BrandID,Name from tblBrands");
            ddlbrandnames.DataTextField = "Name";
            ddlbrandnames.DataValueField = "BrandID";
            ddlbrandnames.DataBind();
            this.ddlbrandnames.Items.Insert(0, "Select Brand");
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

        protected void mnu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            ViewState["ViewId"] = index;
            MultiView1.ActiveViewIndex = index;
        }

        protected void btnsize_Click(object sender, EventArgs e)
        {
            if (isformvalidSize())
            {
                DataTable dt = obj.CheckDuplicateSize(txtsizename.Text, Convert.ToInt32(ddlbrandnames.SelectedValue), Convert.ToInt32(ddlcatnames.SelectedValue), Convert.ToInt32(ddlsubcatnames.SelectedValue), Convert.ToInt32(ddlgender.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertsizedup()", true);
                }
                else
                {
                    obj.Sizename = txtsizename.Text;
                    obj.BrandId= Convert.ToInt32(ddlbrandnames.SelectedValue);
                    obj.SubCatID = Convert.ToInt32(ddlsubcatnames.SelectedValue);
                    obj.CatID = Convert.ToInt32(ddlcatnames.SelectedValue);
                    obj.GenderID= Convert.ToInt32(ddlgender.SelectedValue);
                    if (ViewState["SizeID"] == null)
                    {

                        obj.CreateSize(obj);
                        BindSizeList();   
                        txtsizename.Text = string.Empty;
                       ddlbrandnames.SelectedIndex =0;
                        ddlsubcatnames.SelectedIndex = 0;
                        ddlcatnames.SelectedIndex = 0;
                        ddlgender.SelectedIndex = 0;

                        ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertsizesave()", true);
                    }
                    else
                    {

                        obj.SizeID = (int)ViewState["SizeID"];
                        obj.UpdateSize(obj);
                        BindSizeList();
                        ViewState["SizeID"] = null;
                        ScriptManager.RegisterStartupScript(this.Page,GetType(), "randomtext", "alertsizeedit()", true);
                    }

                }


            }
        }

        protected void dgvsize_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvsize.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvsize.DataKeys[e.NewEditIndex].Value.ToString());
            ViewState["SizeID"] = id;
            GetSizeToEdit(id);
        }
    }
}