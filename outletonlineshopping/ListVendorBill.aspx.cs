using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class ListVendorBill : System.Web.UI.Page
    {
        Purchase obj = new Purchase();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindVBList();
            }
        }
        public void BindVBList()
        {
            DataTable data = obj.ShowDataInGridView("select Id,po.PONo,TotalAmount from tblVendorBill vb inner join tblPO po on vb.POID=po.POID");


            if (data.Rows.Count > 0)
            {
                dgvVB.DataSource = data;
                dgvVB.DataBind();
                dgvVB.UseAccessibleHeader = true;
                dgvVB.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvVB.DataSource = dt;
                dgvVB.DataBind();
                dgvVB.UseAccessibleHeader = true;
                dgvVB.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void dgvVB_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvVB.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvVB.DataKeys[e.NewEditIndex].Value.ToString());
            Response.Redirect("VendorBill.aspx?Id=" + id + "");
        }
    }
}