using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class ListCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomersList();
            }
        }
        public void BindCustomersList()
        {
            Purchase obj = new Purchase();
            DataTable data = obj.ShowDataInGridView("select ld.Name,ld.Address,ld.Email,ld.ContactNo from tblCustomer c inner join tblLeads ld on c.UserId=ld.UserId");


            if (data.Rows.Count > 0)
            {
                dgvCust.DataSource = data;
                dgvCust.DataBind();
                dgvCust.UseAccessibleHeader = true;
                dgvCust.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvCust.DataSource = dt;
                dgvCust.DataBind();
                dgvCust.UseAccessibleHeader = true;
                dgvCust.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
    }
}