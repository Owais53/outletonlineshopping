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
    public partial class Vendor : System.Web.UI.Page
    {
        Purchase obj = new Purchase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVendorList();

            }
        }
        public void BindVendorList()
        {
            DataTable data = obj.ShowDataInGridView("select * from tblVendor");


            if (data.Rows.Count > 0)
            {
                dgvVendor.DataSource = data;
                dgvVendor.DataBind();

            }
            else
            {
                DataTable dt = new DataTable();
                dgvVendor.DataSource = dt;
                dgvVendor.DataBind();

            }

        }

        protected void btnVendorSave_Click(object sender, EventArgs e)
        {
            DataTable dt = obj.CheckDuplicateVendor(txtVendorname.Text);
            if (dt.Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertVendor()", true);
            }
            else
            {
                obj.VendorName = txtVendorname.Text;
                obj.Address = txtaddress.Text;
                obj.Contact = txtContact.Text;
                obj.Email = txtemail.Text;
                if (ViewState["VendorID"] == null)
                {

                    obj.CreateVendor(obj);
                    BindVendorList();
                    txtVendorname.Text = string.Empty;
                    ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertvendorsave()", true);
                }
                else
                {

                    obj.VendorID = (int)ViewState["VendorID"];
                    obj.UpdateVendor(obj);
                    BindVendorList();
                    ViewState["VendorID"] = null;
                    ClientScript.RegisterStartupScript(GetType(), "randomtext", "alertbrandedit()", true);
                }

            }
        }

        protected void dgvVendor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvVendor.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvVendor.DataKeys[e.NewEditIndex].Value.ToString());
            ViewState["VendorID"] = id;
            GetDataToEdit(id);
        }
        public void GetDataToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("Select * from tblVendor where VendorID=@Id", Id))
            {
                sdr.Read();
                txtVendorname.Text = sdr["VendorName"].ToString();
                txtContact.Text = sdr["Contact"].ToString();
                txtemail.Text = sdr["Email"].ToString();
                txtaddress.Text = sdr["Address"].ToString();

            }
            obj.CloseConnection();

        }
    }
}