using Net2.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Net2.Forms
{
    public partial class frmTinhTrangHocTap : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<TinhTrangHocTap> tinhTrang;
        StringBuilder sbTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayOnTable("");
            txtSearchTTHT.Focus();
        }
        private void DisplayOnTable(String key)
        {
            sbTable.Clear();
            tblTTHT.Controls.Clear();
            tinhTrang = database.GetTable<TinhTrangHocTap>();
            var query = from ttht in tinhTrang
                        where (ttht.MaTinhTrangHocTap.Contains(key) || ttht.TenTinhTrangHocTap.Contains(key))
                        orderby ttht.TinhTrangHocTapID
                        select new
                        {
                            ttht.MaTinhTrangHocTap,
                            ttht.TenTinhTrangHocTap
                        };
            sbTable.Append("<table class='table table-striped table-bordered table-hover'>");
            sbTable.Append("<tr><th style='width: 60px; text-align: center;'>STT</th><th>Mã TTHT</th><th>Tình Trạng</th><th style='width: 150px;'>Tùy Chỉnh</th></tr>");
            if (query.Count() > 0)
            {
                int i = 0;
                foreach (var item in query)
                {
                    i++;
                    i++;
                    sbTable.Append("<tr>");
                    sbTable.Append("<td style='text-align: center'>" + i.ToString() + "</td>");
                    sbTable.Append("<td>" + item.MaTinhTrangHocTap + "</td>");
                    sbTable.Append("<td>" + item.TenTinhTrangHocTap + "</td>");
                    sbTable.Append("<td><a href='frmTinhTrangHocTapCU.aspx?id=" + item.MaTinhTrangHocTap + "' class='btn btn-block btn-default'>Tùy Chỉnh</a>");
                    sbTable.Append("</td>");
                    sbTable.Append("</tr>");
                }
                sbTable.Append("</table>");
                tblTTHT.Controls.Add(new Literal { Text = sbTable.ToString() });
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayOnTable(txtSearchTTHT.Text);
            txtSearchTTHT.Focus();
        }
        protected void btnReset_Click(Object sender, EventArgs e)
        {
            txtSearchTTHT.Text = "";
            DisplayOnTable("");
            txtSearchTTHT.Focus();
        }
    }
}