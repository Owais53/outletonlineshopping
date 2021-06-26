using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data;

namespace outletonlineshopping
{
    public partial class Settings : System.Web.UI.Page
    {
        User obj = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btngeneratecode_Click(object sender, EventArgs e)
        {
           string Code= Membership.GeneratePassword(12, 1);
            txtscode.Text = Code;
            if (txtscode.Text != "")
            {
                obj.Code = txtscode.Text;
                obj.UpdateSecurityCode(obj);
            }
           
            
        }

        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            obj.OldPass = txt_cpassword.Text;
            obj.Pass = txt_ccpassword.Text;
            obj.Username = Session["Username"].ToString();
            DataTable dt = obj.CheckOldPass(obj);
            if (dt.Rows.Count != 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    obj.Id = Convert.ToInt32(row["LoginId"]);
                }
                obj.ChangePassword(obj);
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertchangepass()", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertoldpassincorrect()", true);
            }
        }
    }
}