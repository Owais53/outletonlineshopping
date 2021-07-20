using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace outletonlineshopping
{
    public partial class ListGoodsIssue : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGIList();
            }
        }
        Inventory obj = new Inventory();
        public void BindGIList()
        {
            DataTable data = obj.ShowDataInGridView("select sm.SOID,so.SONo,DocNo,MoveType,sm.Status from tblStockMove sm inner join tblSO so on sm.SOID=so.SOID where sm.SOID >0");


            if (data.Rows.Count > 0)
            {
                dgvGI.DataSource = data;
                dgvGI.DataBind();
                dgvGI.UseAccessibleHeader = true;
                dgvGI.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvGI.DataSource = dt;
                dgvGI.DataBind();
                dgvGI.UseAccessibleHeader = true;
                dgvGI.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }


        protected void dgvGI_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Inventory objinv = new Inventory();
            dgvGI.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvGI.DataKeys[e.NewEditIndex].Value.ToString());
            int GIid = objinv.GetGIIdfromSOId(id);
            Response.Redirect("GI.aspx?SOID=" + id + "&GI=" + GIid + "");
        }
    }
}