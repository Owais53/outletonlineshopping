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
    public partial class Product : System.Web.UI.Page
    {
        bool isUnitEdited;
        int UnitId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindUnit();
                if (Request.QueryString["Id"] != null)
                {
                    GetDataToEdit(Convert.ToInt32(Request.QueryString["Id"]));
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
                ddluom.SelectedValue = sdr["Uom"].ToString();
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
            this.ddluom.Items.Insert(0, "Select Unit");
            ddluom.DataBind();
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


        protected void btnProdsave_Click(object sender, EventArgs e)
        {
            Products pro = new Products();

            pro.ProductName = txtProductname.Text;
            pro.Uom = Convert.ToInt32(ddluom.SelectedValue);
            pro.SalesPrice = Convert.ToDecimal(txtprice.Text);
            pro.Cost = Convert.ToDecimal(txtcost.Text);
            if (Request.QueryString["Id"] == null)
            {
              
                pro.CreateProducts(pro);
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertproduct()", true);

            }
            else
            {
                pro.ProductId = Convert.ToInt32(Request.QueryString["Id"]);
                pro.UpdateProduct(pro);
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alerteditproduct()", true);

            }


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

       
    }
}