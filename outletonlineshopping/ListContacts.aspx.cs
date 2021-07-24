using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class ListContacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindContactsList();
            }
        }
        public void BindContactsList()
        {
            Purchase obj = new Purchase();
            DataTable data = obj.ShowDataInGridView("select c.ContactId,ld.Name,ld.Address,ld.Email,ld.ContactNo from tblContacts c inner join tblLeads ld on c.LeadId=ld.LeadId where ld.Status='Qualified'");


            if (data.Rows.Count > 0)
            {
                dgvContacts.DataSource = data;
                dgvContacts.DataBind();
                dgvContacts.UseAccessibleHeader = true;
                dgvContacts.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvContacts.DataSource = dt;
                dgvContacts.DataBind();
                dgvContacts.UseAccessibleHeader = true;
                dgvContacts.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void dgvContacts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Crm obj = new Crm();

            dgvContacts.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvContacts.DataKeys[e.NewEditIndex].Value.ToString());

             obj.LeadId = id;
             obj.DeleteContactfromContactId(obj);
             ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertdeletecont()", true);
            Response.Redirect("ListContacts.aspx");
            
        }
    }
}