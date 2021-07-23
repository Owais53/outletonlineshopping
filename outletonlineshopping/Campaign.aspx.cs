using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class Campaign : System.Web.UI.Page
    {
        Crm obj = new Crm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    GetData(Convert.ToInt32(Request.QueryString["Id"]));
                    // dgvGIDet.Enabled = false;
                    txtstartdate.Enabled = false;

                }
                else
                {
                    DateTime Date = DateTime.Now;
                    txtstartdate.Text = Date.ToString("yyyy-MM-dd");
                    txtEnddate.Text = Date.ToString("yyyy-MM-dd");
                    txtstartdate.Attributes["min"] = Date.ToString("yyyy-MM-dd");
                }
            }
           
           
        }
        public void GetData(int CampId)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("select CampaignName,StartDate,EndDate,ExpectedRevenue from tblCampaigns where CampaignId=@Id", CampId))
            {
                sdr.Read();
                txtcampname.Text = sdr["CampaignName"].ToString();
                DateTime DateStart = Convert.ToDateTime(sdr["StartDate"]);
                DateTime EndDate = Convert.ToDateTime(sdr["EndDate"]);
                txtexpRev.Text = sdr["ExpectedRevenue"].ToString();
                txtstartdate.Text = DateStart.ToString("yyyy-MM-dd");
                txtEnddate.Text=EndDate.ToString("yyyy-MM-dd");
            }
            obj.CloseConnection();

        }
        private bool isformvalidCampaign()
        {
            if (txtcampname.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Campaign Name is not valid');", true);
                txtcampname.Focus();
                return false;
            }
            else if (txtstartdate.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('StartDate is not valid');", true);
                txtcampname.Focus();
                return false;
            }
            else if (txtEnddate.Text == "" || txtEnddate.Text == DateTime.Now.Date.ToString())
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('End Date is not valid');", true);
                txtEnddate.Focus();
                return false;
            }else if(txtexpRev.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Expected Revenue is not valid');", true);
                txtexpRev.Focus();
                return false;
            }

            return true;
        }
        protected void btnAddCamp_Click(object sender, EventArgs e)
        {
            if (isformvalidCampaign())
            {
                obj.CampaignName = txtcampname.Text;
                obj.StartDate = txtstartdate.Text;
                obj.EndDate = txtEnddate.Text;
                obj.ExpectedRevenue = Convert.ToDecimal(txtexpRev.Text);
                string currentdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                if (txtstartdate.Text !=currentdate )
                {
                    obj.Status = "Not Active";
                }
                else
                {
                    obj.Status = "Active";
                }
                

                if (Request.QueryString["Id"] != null)
                {
                    obj.CampaignId = Convert.ToInt32(Request.QueryString["Id"]);
                    obj.CampaignName = txtcampname.Text;
                    obj.EndDate = txtEnddate.Text;
                    obj.ExpectedRevenue = Convert.ToDecimal(txtexpRev.Text);
                    obj.UpdateCampaign(obj);
                    ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertcamedit()", true);
                }
                else
                {
                    obj.CreateCampaign(obj);
                    ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertcam()", true);
                }
            }
           
        }
    }
}