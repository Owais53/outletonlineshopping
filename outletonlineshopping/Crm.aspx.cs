using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class Crm : System.Web.UI.Page
    {
        Connection obj = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCampaignList();
            }
        }
        public void BindCampaignList()
        {
            DataTable data = obj.ShowDataInGridView("select CampaignId,CampaignName,CampaignType,StartDate,EndDate,Status from tblCampaigns");

            if (data.Rows.Count > 0)
            {
                dgvcampaign.DataSource = data;
                dgvcampaign.DataBind();
                dgvcampaign.UseAccessibleHeader = true;
                dgvcampaign.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvcampaign.DataSource = dt;
                dgvcampaign.DataBind();
                dgvcampaign.UseAccessibleHeader = true;
                dgvcampaign.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void dgvcampaign_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}