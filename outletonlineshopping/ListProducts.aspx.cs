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
    public partial class ListProducts : System.Web.UI.Page
    {
        Connection obj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindProductList();             
            }
           
        }
        public void BindProductList()
        {
                DataTable data = obj.ShowDataInGridView("select ProductId,ProductName,SalesPrice,u.Unitofmeasure from tblProduct p inner join tblUom u on p.Uom=u.UomId");
            

            if (data.Rows.Count> 0)
            {
                dgvproduct.DataSource = data;
                dgvproduct.DataBind();
                dgvproduct.UseAccessibleHeader = true;
                dgvproduct.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvproduct.DataSource = dt;
                dgvproduct.DataBind();
                dgvproduct.UseAccessibleHeader = true;
                dgvproduct.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
           
        }
        protected void dgvproduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvproduct.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvproduct.DataKeys[e.NewEditIndex].Value.ToString());
            Response.Redirect("Product.aspx?Id=" + id + "");

        }
        protected void dgvproduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        }

        protected void dgvproduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Products obj = new Products();
            obj.DeleteProducts(Convert.ToInt32(dgvproduct.DataKeys[e.RowIndex].Value.ToString()));
            ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertdelproduct()", true);
            BindProductList();
        }
        public void GetDataToEditQuantity(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select Quantity from tblProduct where ProductId=@Id", Id))
            {
                sdr.Read();
                txtqty.Text = sdr["Quantity"].ToString();

            }
            obj.CloseConnection();

        }
        protected void dgvproduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                ViewState["ProductId"] = Id;
                GetDataToEditQuantity(Id);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalQty", "$('#ModalQty').modal();", true);
            }
        }

        protected void btnqtysave_Click(object sender, EventArgs e)
        {
            if (ViewState["ProductId"] != null)
            {
                Products obj = new Products();
                obj.ProductId = Convert.ToInt32(ViewState["ProductId"]);
                obj.Quantity = Convert.ToInt32(txtqty.Text);
                obj.AddQuantity(obj);
                alertbox();
            }
        }
        public void alertbox()
        {
            string message = "Quantity Added Successfully.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}