using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class ListCustomerInvoice : System.Web.UI.Page
    {
        Inventory obj = new Inventory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCIList();
            }
        }
        public void BindCIList()
        {
            DataTable data = obj.ShowDataInGridView("select p.PaymentId,so.SONo,TotalAmount,PaymentType from tblPay p inner join tblSO so on p.SOID=so.SOID");


            if (data.Rows.Count > 0)
            {
                dgvCI.DataSource = data;
                dgvCI.DataBind();
                dgvCI.UseAccessibleHeader = true;
                dgvCI.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvCI.DataSource = dt;
                dgvCI.DataBind();
                dgvCI.UseAccessibleHeader = true;
                dgvCI.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
        protected void dgvCI_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvCI.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvCI.DataKeys[e.NewEditIndex].Value.ToString());
            Response.Redirect("CustomerInvoice.aspx?Id=" + id + "");
        }
    }
}