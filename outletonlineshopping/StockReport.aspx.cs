using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace outletonlineshopping
{
    public partial class StockReport : System.Web.UI.Page
    {
        Inventory obj = new Inventory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSRList();
            }
        }
        public void BindSRList()
        {
            DataTable data = obj.ShowDataInGridView("select p.ProductName,s.SizeName,psq.Quantity from tblProductSizeQuantity psq inner join tblProduct p on psq.PID=p.ProductId inner join tblSizes s on psq.SizeID=s.SizeID");


            if (data.Rows.Count > 0)
            {
                dgvSR.DataSource = data;
                dgvSR.DataBind();
                dgvSR.UseAccessibleHeader = true;
                dgvSR.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataTable dt = new DataTable();
                dgvSR.DataSource = dt;
                dgvSR.DataBind();
                dgvSR.UseAccessibleHeader = true;
                dgvSR.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
    }
}