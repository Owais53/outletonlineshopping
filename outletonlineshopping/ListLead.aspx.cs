using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class ListLead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLeadList();
            }
        }
        public void BindLeadList()
        {
            Purchase obj = new Purchase();
            DataTable data = obj.ShowDataInGridView("select ld.LeadId,c.CampaignName,ld.Name,ld.Address,ld.Email,ld.LeadSource,ld.ContactNo,ld.Status from tblLeads ld inner join tblCampaigns c on ld.CampaignId=c.CampaignId");


            if (data.Rows.Count > 0)
            {
                dgvLead.DataSource = data;
                dgvLead.DataBind();
                dgvLead.UseAccessibleHeader = true;
                dgvLead.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvLead.DataSource = dt;
                dgvLead.DataBind();
                dgvLead.UseAccessibleHeader = true;
                dgvLead.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void dgvLead_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Crm obj = new Crm();

            dgvLead.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvLead.DataKeys[e.NewEditIndex].Value.ToString());
            
            obj.LeadId = id;
           int Id=obj.CheckDupLeadinContact(obj);
            if (Id > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertContactDup()", true);
            }
            else
            {
                obj.LeadStatus = "Qualified";
                obj.CreateContact(obj);
                obj.ChangeLeadStatus(obj);
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertcontactcreate()", true);
            }
           
        }

        protected void dgvLead_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Crm obj = new Crm();
            if (e.CommandName == "Add")
            {
                
                int Id = Convert.ToInt32(e.CommandArgument);
                obj.LeadId = Id;
                obj.LeadStatus = "Junk";
                obj.ChangeLeadStatus(obj);
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertLeadtojunk()", true);
            }
            if (e.CommandName == "SendEmail")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("SendEmail.aspx?Id="+Id+"");
            }
        }
    }
}