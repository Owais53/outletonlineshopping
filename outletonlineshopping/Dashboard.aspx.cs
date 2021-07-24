using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class Dashboard1 : System.Web.UI.Page
    {
        Crm obj = new Crm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string currentDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                string StartDate = obj.GetCampaignStartDate();              
                DateTime startDate = Convert.ToDateTime(StartDate);               
                string formattedStartDate = startDate.ToString("yyyy-MM-dd");
                int camidnotactive = obj.GetCampIdNotActive();
               
                if (Convert.ToDateTime(formattedStartDate) >= Convert.ToDateTime(currentDate))
                {
                    obj.CampaignId = camidnotactive;
                    obj.Status = "Active";
                    obj.ChangeCampStatus(obj);
                }
                int Campid = obj.GetCampIdActive();
                string EndDate = obj.GetCampaignEndDate(Campid);
                DateTime endDate = Convert.ToDateTime(EndDate);
                string formattedEndDate = endDate.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(currentDate) >= Convert.ToDateTime(formattedEndDate) )
                {
                    decimal ExpectedRevenue = obj.GetExpRevenue(Campid);
                    decimal CampaignSalesRevenue = obj.GetSalesRevenue(Campid);
                    if (CampaignSalesRevenue > 0)
                    {
                        if (CampaignSalesRevenue >= ExpectedRevenue)
                        {
                            obj.Status = "Successfull";
                        }
                        else
                        {
                            obj.Status = "Not Successfull";
                        }
                        obj.CampaignId = Campid;
                        obj.ChangeCampStatus(obj);
                    }
                    
                }
            }
        }
    }
}