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

    }
}