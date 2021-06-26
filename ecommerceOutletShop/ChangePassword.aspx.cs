using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerceOutletShop
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        Ecomm obj = new Ecomm();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            obj.OldPass = txtc_pass.Text;
            obj.Password = txtconfirmpass.Text;
            obj.Username = Session["Username"].ToString();
            DataTable dt = obj.CheckOldPass(obj);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    obj.LoginId = Convert.ToInt32(row["LoginId"]);
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