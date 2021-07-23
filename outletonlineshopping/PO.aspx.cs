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
	public partial class PO : System.Web.UI.Page
	{
        Purchase obj = new Purchase();
        Inventory objinv = new Inventory();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Request.QueryString["Id"] != null)
            {
                int ID = Convert.ToInt32(Request.QueryString["Id"]);
                GetDataToEdit(ID);
                DisableControls(Page, false);
                DataTable dtgr = objinv.CheckGRExists(ID);
                DataTable dtvb = objinv.CheckVBExists(ID);
                if (dtgr.Rows.Count > 0)
                {
                    btnGr.Visible = false;
                }
                if (dtvb.Rows.Count > 0)
                {
                    btnvb.Visible = false;
                }
            }
            
        }
        protected void DisableControls(Control parent, bool State)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)(c)).Enabled = State;
                }

                DisableControls(c, State);
            }
        }
        public void GetDataToEdit(int Id)
        {
            obj.OpenConection();
            using (SqlDataReader sdr = obj.DataReaderwithparam("select po.SOref,po.POID,po.PONo,so.SONo,po.Createdon,v.VendorName,po.Status from tblPO po inner join tblSO so on po.SOref=so.SOID inner join tblVendor v on po.VendorID=v.VendorID where po.POID=@Id", Id))
            {
                sdr.Read();
                txtSoref.Text = sdr["SONo"].ToString();
                txtPONo.Text = sdr["PONo"].ToString();
                txtorderdate.Text = sdr["Createdon"].ToString();
                txtStatus.Text = sdr["Status"].ToString();
                txtVendor.Text = sdr["VendorName"].ToString();
                hdsoid.Value = sdr["SOref"].ToString();

            }
            obj.CloseConnection();
            DataTable dt = obj.GetPOItem(Id);
            if (dt.Rows.Count > 0)
            {
                dgvPODet.DataSource = dt;
                dgvPODet.DataBind();

            }
            else
            {
                DataTable dt1 = new DataTable();
                dgvPODet.DataSource = dt1;
                dgvPODet.DataBind();

            }
        }
      
        protected void btnsaletrack_ServerClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(hdsoid.Value);
            Response.Redirect("SO.aspx?Id=" + ID + "");
        }
        
       
        public string GenerateNoGR(string GRno)
        {
            Inventory objinv = new Inventory();
            string a = "";
            int SoID = objinv.GetLastSmovePoId();
            if (SoID > 0)
            {
                DataTable dt = objinv.GetLastGRNo();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string lastNo = string.Empty;
                        foreach (DataRow row in dt.Rows)
                        {
                            lastNo = row["DocNo"].ToString();

                        }
                        string LastNo = lastNo.Split('-')[1].ToString();
                        int No = Convert.ToInt32(LastNo);
                        int Num = No + 1;
                        a = GRno + "-000" + Num;

                    }
                }
            }
            else
            {
                a = GRno + "-0001";
            }
            return a;

        }
        protected void btnGr_ServerClick(object sender, EventArgs e)
        {
            Inventory objinv = new Inventory();
            objinv.DocNo = GenerateNoGR("GR");
            objinv.SOID = 0;
            objinv.POID = Convert.ToInt32(Request.QueryString["Id"]);
            objinv.MoveType = "Stock In";
            objinv.Status = "Received";
            Purchase objpur = new Purchase();
            objpur.PurchaseStatus = "Received";
            objpur.POID= Convert.ToInt32(Request.QueryString["Id"]);
            objpur.UpdatePoStatus(objpur);
            if (Request.QueryString["Id"] != null)
            {
                int GRID = objinv.CreateGR(objinv);
                int POID = Convert.ToInt32(Request.QueryString["Id"]);

                foreach (GridViewRow row in dgvPODet.Rows)
                {
                    Label lblProd = row.Cells[0].Controls[1] as Label;
                    Label lblQty = row.Cells[2].Controls[1] as Label;
                    Label lblPrice = row.Cells[3].Controls[1] as Label;
                    Label lblSize = row.Cells[1].Controls[1] as Label;

                    int PID = obj.GetProductId(lblProd.Text);
                    int SizeID = obj.GetSizeId(lblSize.Text);
                    
                    objinv.PID = PID;
                    objinv.SizeID = SizeID;
                    objinv.Quantity = Convert.ToInt32(lblQty.Text);
                    objinv.Price = Convert.ToDecimal(lblPrice.Text);
                    objinv.StockMoveID = GRID;
                    objinv.StockMoveStatus = "Received";
                    objinv.CreateStockMoveDet(objinv);
                    objinv.ChangeQuantityPlus(objinv);
                }
                Response.Redirect("GR.aspx?POID="+POID+"&GR="+GRID+"");
            }
            else
            {

            }
        }

        protected void btnvb_ServerClick(object sender, EventArgs e)
        {
            Purchase obj = new Purchase();
            int id= Convert.ToInt32(Request.QueryString["Id"]);
            obj.POID = id;
            decimal TotalAmt = obj.GetTotalAmt(id);
            obj.TotalAmt = TotalAmt;
            int Id=obj.CreateVendorBill(obj);
            Response.Redirect("VendorBill.aspx?Id="+Id+"");
        }
    }
}
