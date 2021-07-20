using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class ListGR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGRList();
            }
        }
        Inventory obj = new Inventory();
        public void BindGRList()
        {
            DataTable data = obj.ShowDataInGridView("select sm.POID,po.PONo,DocNo,MoveType,sm.Status from tblStockMove sm inner join tblPO po on sm.POID=po.POID where sm.POID >0");


            if (data.Rows.Count > 0)
            {
                dgvGR.DataSource = data;
                dgvGR.DataBind();
                dgvGR.UseAccessibleHeader = true;
                dgvGR.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvGR.DataSource = dt;
                dgvGR.DataBind();
                dgvGR.UseAccessibleHeader = true;
                dgvGR.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
        protected void dgvGR_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Inventory obj = new Inventory();
            dgvGR.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvGR.DataKeys[e.NewEditIndex].Value.ToString());
            int GRid = obj.GetGRIdfromPOId(id);
            Response.Redirect("GR.aspx?POID=" + id + "&GR=" + GRid + "");
        }
    }
}