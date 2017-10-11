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
    public partial class frmChucVu : System.Web.UI.Page
    {
        QuanLyDoanVienDataContext database = new QuanLyDoanVienDataContext();
        Table<ChucVu> chucVu;
        StringBuilder sbTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayOnTable("");
            txtSearchChucVu.Focus();
        }
        private void DisplayOnTable(String key)
        {
            sbTable.Clear();
            tblChucVu.Controls.Clear();
            chucVu = database.GetTable<ChucVu>();
            var query = from cv in chucVu
                        where (cv.MaChucVu.Contains(key) || cv.TenChucVu.Contains(key))
                        orderby cv.ChucVuID
                        select new
                        {
                            cv.MaChucVu,
                            cv.TenChucVu
                        };
            sbTable.Append("<table class='table table-striped table-bordered table-hover' id='sample'>");
            sbTable.Append("<tr><th style='width: 60px; text-align: center;'>STT</th><th>Mã Chức Vụ</th><th>Chức Vụ</th><th style='width: 150px;'>Tùy Chỉnh</th></tr>");
            if (query.Count() > 0)
            {
                int i = 0;
                foreach(var item in query)
                {
                    i++;
                    sbTable.Append("<tr>");
                    sbTable.Append("<td style='text-align: center'>" + i.ToString() + "</td>");
                    sbTable.Append("<td>" + item.MaChucVu + "</td>");
                    sbTable.Append("<td>" + item.TenChucVu + "</td>");
                    sbTable.Append("<td><a href='frmChucVuCU.aspx?id=" + item.MaChucVu + "' class='btn btn-block btn-default'>Tùy Chỉnh</a>");
                    sbTable.Append("</td>");
                    sbTable.Append("</tr>");
                }
            }
            sbTable.Append("</table >");
            tblChucVu.Controls.Add(new Literal { Text = sbTable.ToString() });
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayOnTable(txtSearchChucVu.Text);
            txtSearchChucVu.Focus();
        }
        protected void btnReset_Click(Object sender, EventArgs e)
        {
            txtSearchChucVu.Text = "";
            DisplayOnTable("");
            txtSearchChucVu.Focus();
        }
    }
}