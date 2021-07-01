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
    public partial class Brands : System.Web.UI.Page
    {
        Products obj = new Products();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                BindBrandList();
                
            }
           
        }

        protected void btnbrandsave_Click(object sender, EventArgs e)
        {
            if (txtBrandname.Text != "")
            {
                DataTable dt = obj.CheckDuplicateBrand(txtBrandname.Text);
                if (dt.Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertbranddup()", true);
                }
                else
                {
                    obj.BrandName = txtBrandname.Text;
                    if (ViewState["BrandID"] == null)
                    {
                        
                        obj.CreateBrand(obj);
                        BindBrandList();
                        txtBrandname.Text = string.Empty;
                        ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertbrandsave()", true);
                    }
                    else
                    {

                        obj.BrandId = (int)ViewState["BrandID"];
                        obj.UpdateBrand(obj);
                        BindBrandList();
                        ViewState["BrandID"]= null;
                        ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertbrandedit()", true);
                    }
                   
                }
                

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

        protected void dgvbrand_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
            dgvbrand.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvbrand.DataKeys[e.NewEditIndex].Value.ToString());
            ViewState["BrandID"] = id;
            GetDataToEdit(id);
            //ViewState["BrandID"] = id;
            //Response.Redirect("~/Brands.aspx");
            
        }
        public void GetDataToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select * from tblBrands where BrandID=@Id", Id))
            {
                sdr.Read();             
                txtBrandname.Text = sdr["Name"].ToString();
                             
               
            }
            obj.CloseConnection();

        }
      
    }
}