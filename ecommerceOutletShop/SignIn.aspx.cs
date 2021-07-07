using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class SignIn : System.Web.UI.Page
    {
        Ecomm obj = new Ecomm();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UNAME"] != null && Request.Cookies["UPWD"]!=null)
                {
                    txtUname.Text = Request.Cookies["UNAME"].Value;
                    txtpass.Text = Request.Cookies["UPWD"].Value;
                    chkrem.Checked = true;
                }
            }
        }

        protected void btnsignin_Click(object sender, EventArgs e)
        {
            obj.Username = txtUname.Text;
            obj.Password = txtpass.Text;
            DataTable dt=obj.SignIn(obj);
            if (dt.Rows.Count != 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Session["UserId"] = row["LoginId"].ToString();
                    Session["Username"] = row["UserName"].ToString();
                }
                if (chkrem.Checked)
                {
                    Response.Cookies["UNAME"].Value = txtUname.Text;
                    Response.Cookies["UPWD"].Value = txtpass.Text;

                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);
                    Response.Cookies["UPWD"].Expires= DateTime.Now.AddDays(10);
                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Redirect("~/UserHome.aspx");
            }
            else
            {
                lblError.Text = "Invalid Username or Password";
            }
            clr();
        }
        public void clr()
        {
            txtUname.Text = string.Empty;
            txtpass.Text = string.Empty;
            txtUname.Focus();
        }

        protected void btnemailsend_Click(object sender, EventArgs e)
        {
            if (txtemailforget.Text == "")
            {
                lblerroremail.Visible = true;
                lblerroremail.Text = "Enter your Email";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ASET", "<script type='text/javascript'>alert('Enter your Email');</script>", false);

            }
            else
            {
                Session["email"] = txtemailforget.Text;
                obj.Email = txtemailforget.Text;
                lblerroremail.Text = "";
                DataTable dt = obj.ForgotPass(obj);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string useremail = row["Email"].ToString();
                        SendEmail(useremail);
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ASET", "<script type='text/javascript'>alert('Password reset Link has been sent to your Email');</script>", false);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ASET", "<script type='text/javascript'>alert('Email you entered is not Registered with any User!');</script>", false);


                }
            }
        }
        private void SendEmail(string useremail)
        {

            try
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("Hi,<br/> Click on below given link to Reset Your Password<br/>");
                sb.Append("<a href=http://localhost:12620//resetlink.aspx?username=" + useremail);


                sb.Append("&email=" + txtemailforget.Text + ">Click here to change your password</a><br/>");


                sb.Append("<b>Thanks</b>,<br> OutLet Shopping <br/>");


                MailMessage message = new MailMessage("onlineoutletshopping2021@gmail.com", txtemailforget.Text.Trim());

                message.Subject = "Reset Your Password";
                message.Body = sb.ToString();
                message.IsBodyHtml = true;
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

        protected void Linkforgetpass_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modalforgetpass", "$('#Modalforgetpass').modal();", true);
        }
    }
}