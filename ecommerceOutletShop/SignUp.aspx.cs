using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class SignUp : System.Web.UI.Page
    {
        Ecomm obj = new Ecomm();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private bool isformvalid()
        {
            if (txtUname.Text == "")
            {
                Response.Write("<script> alert('UserName is not valid'); </script>");
                txtUname.Focus();
                return false;
            }else if (txtpass.Text == "")
            {

                Response.Write("<script> alert('Password is not valid'); </script>");
                txtpass.Focus();
                return false;
            }else if(txtpass.Text != txtcpass.Text)
            {
                Response.Write("<script> alert('Confirm Password is not valid'); </script>");
                txtcpass.Focus();
                return false;
            }
            else if (txtemail.Text == "")
            {
                Response.Write("<script> alert('Email is not valid'); </script>");
                txtemail.Focus();
                return false;
            }
            else if (txtfname.Text == "")
            {
                Response.Write("<script> alert('Full Name is not valid'); </script>");
                txtfname.Focus();
                return false;
            }else if(chkadm.Checked && txtcode.Text == "")
            {
                Response.Write("<script> alert('Code is not valid'); </script>");
                txtcode.Focus();
                return false;
            }
            return true;
        }
        protected void btnsignup_Click(object sender, EventArgs e)
        {
            if (isformvalid())
            {
                bool isCorrect=false;
                obj.Username = txtUname.Text;
                obj.Password = txtpass.Text;
                obj.Email = txtemail.Text;
                obj.FullName = txtfname.Text;
                if (chkadm.Checked)
                {
                    obj.isAdmin = true;
                    if (txtcode.Text != "")
                    {
                        obj.Code = txtcode.Text;
                        DataTable tab = obj.CheckCode(obj);
                        if (tab.Rows.Count != 0)
                        {
                            isCorrect = true;
                        }
                        else
                        {
                            isCorrect = false;
                        }
                    }
                }
                else
                {
                    obj.isAdmin = false;
                }
                if(chkadm.Checked==true && isCorrect == false)
                {
                    Response.Write("<script> alert('Code is not valid'); </script>");
                    txtcode.Focus();
                    return;
                }
                else
                {
                    DataTable dt = obj.CheckUser(obj);
                    if (dt.Rows.Count == 0)
                    {
                       int UserId= obj.CreateSignUp(obj);
                        
                        Sale objsale = new Sale();
                        if (chkadm.Checked != true)
                        {
                            string Email = txtemail.Text;
                            string LeadEmail = objsale.CheckEmailfromLead(Email);
                            if (LeadEmail == null)
                            {
                                int ActiveCampId = objsale.GetActiveCampId();
                                if (ActiveCampId > 0)
                                {
                                    objsale.CampaignId = ActiveCampId;
                                    objsale.UserID = UserId;
                                    objsale.Name = txtfname.Text;
                                    objsale.Email = txtemail.Text;
                                    objsale.LeadSource = "Website";
                                    objsale.LeadStatus = "Pending";
                                    objsale.Contact = txtcontact.Text;
                                    objsale.Address = txtaddress.Text;
                                    objsale.CreateLead(objsale);
                                }
                            }
                            else
                            {

                                objsale.UpdateLeadUserIDbyEmail(LeadEmail, UserId);
                            }
                        }

                        clr();
                        ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertsignup()", true);
                        txtcode.Text = string.Empty;
                        txtcode.Visible = false;
                    }
                    else
                    {
                        txtUname.Text = string.Empty;
                        ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertcheckuser()", true);
                    }
                   

                }

            }
            
        }
        private void clr()
        {
            txtUname.Text = string.Empty;
            txtpass.Text = string.Empty;
            txtcpass.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtfname.Text = string.Empty;
        }

        protected void chkadm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkadm.Checked)
            {
                lblcode.Visible = true;
                txtcode.Visible = true;
            }
            else
            {
                lblcode.Visible = false;
                txtcode.Visible = false;
            }
        }
    }
}