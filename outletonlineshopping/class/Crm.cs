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
        public void DeleteContactfromContactId(Crm obj)
        {
            OpenConection();
            ExecuteDeleteQueries("delete from tblContacts where ContactId=@Id", obj.LeadId);
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
        public void ChangeCampStatus(Crm obj)
        {
            OpenConection();
            UpdateCampStatus("Update tblCampaigns set Status=@Status where CampaignId=@CampId", obj.CampaignId, obj.Status);
            CloseConnection();
        }
        public int CheckDupLeadinContact(Crm obj)
        {
            OpenConection();
            int Id=selectId("Select LeadId from tblContacts where LeadId=@Id", obj.LeadId);
            CloseConnection();
            return Id;
        }
        public string GetCampaignStartDate()
        {
            OpenConection();
            string Date = GetDate("Select StartDate from tblCampaigns where Status='Not Active'");
            CloseConnection();
            return Date;
        }
        public string GetCampaignEndDate(int Id)
        {
            OpenConection();
            string Date = GetDatewithparam("Select EndDate from tblCampaigns where CampaignId=@CampId", Id);
            CloseConnection();
            return Date;
        }
        public decimal GetExpRevenue(int Id)
        {
            OpenConection();
            decimal ExpRev = GetExpRevenuewithparam("Select ExpectedRevenue from tblCampaigns where CampaignId=@CampId", Id);
            CloseConnection();
            return ExpRev;
        }
        public decimal GetSalesRevenue(int Id)
        {
            OpenConection();
            decimal ExpRev = GetExpRevenuewithparam("select SUM(TotalAmount) as TotalAmt from tblPay p inner join tblSO so on p.SOID=so.SOID inner join tblLeads ld on so.UserID=ld.UserId inner join tblCampaigns camp on ld.CampaignId=camp.CampaignId where ld.CampaignId=@CampId and camp.Status='Active'", Id);
            CloseConnection();
            return ExpRev;
        }
        public int GetCampIdActive()
        {
            OpenConection();
            int campid = GetLastId("Select CampaignId from tblCampaigns where Status='Active'");
            CloseConnection();
            return campid;
        }
        public int GetCampIdNotActive()
        {
            OpenConection();
            int campid = GetLastId("Select CampaignId from tblCampaigns where Status='Not Active'");
            CloseConnection();
            return campid;
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