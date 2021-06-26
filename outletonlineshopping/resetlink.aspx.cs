using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class resetlink : System.Web.UI.Page
    {
        User obj = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            string user = Request.QueryString["Username"].ToString();
            obj.Email = user;
            obj.Pass = txtcpass.Text;
            DataTable dt = obj.GetloginId(obj);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    obj.Id = Convert.ToInt32(row["LoginId"]);
                }
   
                obj.ChangePassword(obj);
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertreset()", true);
            }
        }
    }
}