using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class ListPO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int ID = Convert.ToInt32(Request.QueryString["Id"]);
                    BindPOListWithParam(ID);

                }
                else
                {
                    BindPOList();
                }
               
            }
        }
        public void BindPOListWithParam(int ID)
        {
            Purchase obj = new Purchase();
            DataTable data = obj.ShowDataInGridView("select po.POID,po.PONo,so.SONo,po.Createdon,v.VendorName,po.Status from tblPO po inner join tblSO so on po.SOref=so.SOID inner join tblVendor v on po.VendorID=v.VendorID where po.SOref="+ID+"");


            if (data.Rows.Count > 0)
            {
                dgvPO.DataSource = data;
                dgvPO.DataBind();
                dgvPO.UseAccessibleHeader = true;
                dgvPO.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvPO.DataSource = dt;
                dgvPO.DataBind();
                dgvPO.UseAccessibleHeader = true;
                dgvPO.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
        public void BindPOList()
        {
            Purchase obj = new Purchase();
            DataTable data = obj.ShowDataInGridView("select po.POID,po.PONo,so.SONo,po.Createdon,v.VendorName,po.Status from tblPO po left join tblSO so on po.SOref=so.SOID inner join tblVendor v on po.VendorID=v.VendorID");


            if (data.Rows.Count > 0)
            {
                dgvPO.DataSource = data;
                dgvPO.DataBind();
                dgvPO.UseAccessibleHeader = true;
                dgvPO.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvPO.DataSource = dt;
                dgvPO.DataBind();
                dgvPO.UseAccessibleHeader = true;
                dgvPO.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
        protected void dgvPO_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvPO.EditIndex = e.NewEditIndex;
            int id = Convert.ToInt32(dgvPO.DataKeys[e.NewEditIndex].Value.ToString());
           
                if (dgvPO.Rows[dgvPO.EditIndex].Cells[1].Text == DBNull.Value.ToString())
                {
                  Response.Redirect("PONew.aspx?Id=" + id + "");
                }
                else
                {
                  Response.Redirect("PO.aspx?Id=" + id + "");
                }

            
        }
    }
}