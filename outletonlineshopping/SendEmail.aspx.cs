using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                { Crm obj = new Crm();
                    obj.LeadId = Convert.ToInt32(Request.QueryString["Id"]);
                    txtto.Text = obj.GetLeadEmail(obj);
                }
            }
           
        }
        private void SendMarketingEmail()
        {

            try
            {

        

                MailMessage message = new MailMessage("onlineoutletshopping2021@gmail.com", txtto.Text.Trim());

                message.Subject =txtsub.Text;
                message.Body = txtmessage.Text;
                message.IsBodyHtml = false;
                // SmtpClient smtp = new SmtpClient();

                // smtp.Host = "smtp.gmail.com";
                // smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "onlineoutletshopping2021@gmail.com";
                NetworkCred.Password = "2262801abcxyz";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = NetworkCred,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 20000,

                };
                // smtp.UseDefaultCredentials = false;
                // smtp.Credentials = NetworkCred;
                // smtp.Port = 587;
                smtp.Send(message);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool isformvalidsendemail()
        {
            if (txtto.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Email is not valid');", true);
                txtto.Focus();
                return false;
            }
            else if (txtsub.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Subject is not valid');", true);
                txtsub.Focus();
                return false;
            }
            else if (txtmessage.Text=="")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Message is not valid');", true);
                txtmessage.Focus();
                return false;
            }
           

            return true;
        }
        protected void btnsendemail_Click(object sender, EventArgs e)
        {
            if (isformvalidsendemail())
            {
                SendMarketingEmail();
            }            
        }
    }
}