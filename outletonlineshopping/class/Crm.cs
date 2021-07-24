using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace outletonlineshopping
{
    public class Crm : Connection
    {
        public int CampaignId { get; set; }
        public int LeadId { get; set; }
        public string CampaignName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal ExpectedRevenue { get; set; }
        public string Status { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string LeadSource { get; set; }
        public string Contact { get; set; }
        public string LeadStatus { get; set; }

        public void CreateCampaign(Crm obj)
        {
            OpenConection();
            InsertCampaign("Insert into tblCampaigns(CampaignName,StartDate,EndDate,ExpectedRevenue,Status) values(@Campaignname,@strtdate,@enddate,@ExpRev,@Status)", obj.CampaignName,obj.StartDate,obj.EndDate,obj.ExpectedRevenue,obj.Status);
            CloseConnection();
        }
        public void CreateLead(Crm obj)
        {
            OpenConection();
            InsertLead("Insert into tblLeads values(@Campid,@UserId,@Name,@Address,@Email,@Leadsource,@contact,@status)", obj.CampaignId, obj.UserID,obj.Name, obj.Address, obj.Email, obj.LeadSource,obj.Contact,obj.LeadStatus);
            CloseConnection();
        }
        public void CreateContact(Crm obj)
        {
            OpenConection();
            InsertContacts("Insert into tblContacts values(@LeadId)", obj.LeadId);
            CloseConnection();
        }
        public void DeleteContact(Crm obj)
        {
            OpenConection();
            ExecuteDeleteQueries("delete from tblContacts where LeadId=@Id)", obj.LeadId);
            CloseConnection();
        }
        public void UpdateCampaign(Crm obj)
        {
            OpenConection();
            EditCampaign("Update tblCampaigns set CampaignName=@Campaignname,EndDate=@enddate,ExpectedRevenue=@ExpRev where CampaignId=@Id", obj.CampaignId,obj.CampaignName, obj.EndDate, obj.ExpectedRevenue);
            CloseConnection();
        }
        public void ChangeLeadStatus(Crm obj)
        {
            OpenConection();
            UpateLeadStatus("Update tblLeads set Status=@LeadStatus where LeadId=@LeadId", obj.LeadId,obj.LeadStatus);
            CloseConnection();
        }
        public int CheckDupLeadinContact(Crm obj)
        {
            OpenConection();
            int Id=selectId("Select LeadId from tblContacts where LeadId=@Id", obj.LeadId);
            CloseConnection();
            return Id;
        }
        public string GetLeadEmail(Crm obj)
        {
            OpenConection();
            string email = GetEmailfromLead("Select Email from tblLeads where LeadId=@Id", obj.LeadId);
            CloseConnection();
            return email;
        }
        public int GetActiveCampId(int Id)
        {
            OpenConection();
            int CampId=selectId("select CampaignId from tblCampaigns where CampaignId=@Id and Status='Active'", Id);
            CloseConnection();
            return CampId;
        }
        public int GetCampId()
        {
            OpenConection();
            int CampId = GetLastId("select CampaignId from tblCampaigns where Status='Successfull' OR Status='UnSuccesfull'");
            CloseConnection();
            return CampId;
        }
    }
}