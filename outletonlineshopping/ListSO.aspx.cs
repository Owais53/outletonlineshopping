using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
	public partial class ListSO1 : System.Web.UI.Page
	{
        Sale obj = new Sale();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                BindSOList();
            }
        }
        public void BindSOList()
        {
            DataTable data = obj.ShowDataInGridView("select SOID,SONo,Createdon,Status from tblSO");


            if (data.Rows.Count > 0)
            {
                dgvSO.DataSource = data;
                dgvSO.DataBind();
                dgvSO.UseAccessibleHeader = true;
                dgvSO.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvSO.DataSource = dt;
                dgvSO.DataBind();
                dgvSO.UseAccessibleHeader = true;
                dgvSO.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        protected void dgvSO_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvSO.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvSO.DataKeys[e.NewEditIndex].Value.ToString());
            Response.Redirect("SO.aspx?Id=" + id + "");
        }

        protected void dgvSO_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void dgvSO_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}